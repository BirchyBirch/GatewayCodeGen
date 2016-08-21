Include ".\helpers.ps1"

properties {
	$solutionDirectory = (Get-Item $solutionFile).DirectoryName
	$outputDirectory= "$solutionDirectory\.build"
	$temporaryOutputDirectory = "$outputDirectory\temp"

	$publishedxUnitTestsDirectory = "$temporaryOutputDirectory\_PublishedxUnitTests"
	$publishedWebsitesDirectory = "$temporaryOutputDirectory\_PublishedWebsites"
	$publishedApplicationsDirectory = "$temporaryOutputDirectory\_PublishedApplications"
	$publishedLibrariesDirectory = "$temporaryOutputDirectory\_PublishedLibraries\"

	$testResultsDirectory = "$outputDirectory\TestResults"
	$xUnitTestResultsDirectory = "$testResultsDirectory\xUnit"

	$testCoverageDirectory = "$outputDirectory\TestCoverage"
	$testCoverageReportPath = "$testCoverageDirectory\OpenCover.xml"
	$testCoverageFilter = "+[*]* -[xunit.*]* -[UnitTests]*"
	$testCoverageExcludeByAttribute = "*.ExcludeFromCodeCoverage*"
	$testCoverageExcludeByFile = "*\*Designer.cs;*\*.g.cs;*\*.g.i.cs"

	$packagesOutputDirectory = "$outputDirectory\Packages"
	$librariesOutputDirectory = "$packagesOutputDirectory\Libraries"
	$applicationsOutputDirectory = "$packagesOutputDirectory\Applications"

	$buildConfiguration = "Release"
	$buildPlatform = "Any CPU"

	$packagesPath = "$solutionDirectory\packages"
	$xUnitExe = (Find-PackagePath $packagesPath "xUnit.Runner.Console") + "\Tools\xunit.console.exe"
	$openCoverExe = (Find-PackagePath $packagesPath "OpenCover") + "\Tools\OpenCover.Console.exe"
	$reportGeneratorExe = (Find-PackagePath $packagesPath "ReportGenerator") + "\Tools\ReportGenerator.exe"
	$7ZipExe = (Find-PackagePath $packagesPath "7-Zip.CommandLine" ) + "\Tools\7za.exe"
	$nugetExe = (Find-PackagePath $packagesPath "NuGet.CommandLine" ) + "\Tools\NuGet.exe"
	$roundhouseExe = (Find-PackagePath $packagesPath "Roundhouse" ) +"\bin\rh.exe"

	$databaseName = "CurrencyTestDatabase"
	$server = "(local)\sqlexpress"
	$databaseFilesDir = "$solutionDirectory\Database"
}

task default -depends FullBuild

task compileWithCover -depends Test, BuildDatabase

FormatTaskName "`r`n`r`n-------- Executing {0} Task --------"

task Init `
	-description "Initialises the build by removing previous artifacts and creating output directories" `
	-requiredVariables outputDirectory, temporaryOutputDirectory `
{
	Assert ("Debug", "Release" -contains $buildConfiguration) `
		   "Invalid build configuration '$buildConfiguration'. Valid values are 'Debug' or 'Release'"

	Assert ("x86", "x64", "Any CPU" -contains $buildPlatform) `
		   "Invalid build platform '$buildPlatform'. Valid values are 'x86', 'x64' or 'Any CPU'"

	# Check that all tools are available
	Write-Host "Checking that all required tools are available"
 
	Assert (Test-Path $xUnitExe) "xUnit Console could not be found"
	Assert (Test-Path $openCoverExe) "OpenCover Console could not be found"
	Assert (Test-Path $reportGeneratorExe) "ReportGenerator Console could not be found"
	Assert (Test-Path $7ZipExe) "7-Zip Command Line could not be found"
	Assert (Test-Path $nugetExe) "NuGet Command Line could not be found"
	
	# Remove previous build results
	if (Test-Path $outputDirectory) 
	{
		Write-Host "Removing output directory located at $outputDirectory"
		Remove-Item $outputDirectory -Force -Recurse
	}

	Write-Host "Creating output directory located at $outputDirectory"
	New-Item $outputDirectory -ItemType Directory | Out-Null

	Write-Host "Creating temporary output directory located at $temporaryOutputDirectory" 
	New-Item $temporaryOutputDirectory -ItemType Directory | Out-Null
}
 
task Compile `
	-depends Init `
	-description "Compile the code" `
	-requiredVariables solutionFile, buildConfiguration, buildPlatform, temporaryOutputDirectory `
{ 
	Write-Host "Building solution $solutionFile"

	Exec { msbuild $SolutionFile "/p:Configuration=$buildConfiguration;Platform=$buildPlatform;OutDir=$temporaryOutputDirectory;NuGetExePath=$nugetExe" }
}

task TestXUnit `
	-depends Compile `
	-description "Run xUnit tests" `
	-precondition { return Test-Path $publishedxUnitTestsDirectory } `
	-requiredVariable publishedxUnitTestsDirectory, xUnitTestResultsDirectory `
{
	$testAssemblies = Prepare-Tests -testRunnerName "xUnit" `
									-publishedTestsDirectory $publishedxUnitTestsDirectory `
									-testResultsDirectory $xUnitTestResultsDirectory `
									-testCoverageDirectory $testCoverageDirectory

	$targetArgs = "$testAssemblies -xml `"`"$xUnitTestResultsDirectory\xUnit.xml`"`" -nologo -noshadow"

	# Run OpenCover, which in turn will run xUnit	
	Run-Tests -openCoverExe $openCoverExe `
			  -targetExe $xunitExe `
			  -targetArgs $targetArgs `
			  -coveragePath $testCoverageReportPath `
			  -filter $testCoverageFilter `
			  -excludebyattribute:$testCoverageExcludeByAttribute `
			  -excludebyfile: $testCoverageExcludeByFile
}

task BuildDatabase{
	Exec{
		& $roundhouseExe -d $databaseName -s $server -f $databaseFilesDir --silent
	}
}

task Test `
	-depends Compile, TestXUnit  `
	-description "Run unit tests and test coverage" `
	-requiredVariables testCoverageDirectory, testCoverageReportPath `
{
	# parse OpenCover results to extract summary
	if (Test-Path $testCoverageReportPath)
	{
		Write-Host "Parsing OpenCover results"

		# Load the coverage report as XML
		$coverage = [xml](Get-Content -Path $testCoverageReportPath)

		$coverageSummary = $coverage.CoverageSession.Summary

		# Write class coverage
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsCCovered' value='$($coverageSummary.visitedClasses)']"
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsCTotal' value='$($coverageSummary.numClasses)']"
		Write-Host ("##teamcity[buildStatisticValue key='CodeCoverageC' value='{0:N2}']" -f (($coverageSummary.visitedClasses / $coverageSummary.numClasses)*100))

		# Report method coverage
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsMCovered' value='$($coverageSummary.visitedMethods)']"
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsMTotal' value='$($coverageSummary.numMethods)']"
		Write-Host ("##teamcity[buildStatisticValue key='CodeCoverageM' value='{0:N2}']" -f (($coverageSummary.visitedMethods / $coverageSummary.numMethods)*100))
		
		# Report branch coverage
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsBCovered' value='$($coverageSummary.visitedBranchPoints)']"
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsBTotal' value='$($coverageSummary.numBranchPoints)']"
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageB' value='$($coverageSummary.branchCoverage)']"

		# Report statement coverage
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsSCovered' value='$($coverageSummary.visitedSequencePoints)']"
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageAbsSTotal' value='$($coverageSummary.numSequencePoints)']"
		Write-Host "##teamcity[buildStatisticValue key='CodeCoverageS' value='$($coverageSummary.sequenceCoverage)']"

		# Generate HTML test coverage report
		Write-Host "`r`nGenerating HTML test coverage report"
		Exec { &$reportGeneratorExe $testCoverageReportPath $testCoverageDirectory }
	}
	else
	{
		Write-Host "No coverage file found at: $testCoverageReportPath"
	}
}

task Package `
	-depends Compile, Test `
	-description "Package applications" `
	-requiredVariables publishedWebsitesDirectory, publishedApplicationsDirectory, applicationsOutputDirectory, publishedLibrariesDirectory, librariesOutputDirectory `
{
	# Merge published websites and published applications
	$applications = @(Get-ChildItem $publishedWebsitesDirectory) + @(Get-ChildItem $publishedApplicationsDirectory)
	
	if ($applications.Length -gt 0 -and !(Test-Path $applicationsOutputDirectory))
	{
		New-Item $applicationsOutputDirectory -ItemType Directory | Out-Null
	}

	foreach($application in $applications)
	{
		$nuspecPath = $application.FullName + "\" + $application.Name + ".nuspec"

		Write-Host "Looking for nuspec file at $nuspecPath"

		if (Test-Path $nuspecPath)
		{
			Write-Host "Packaging $($application.Name) as a NuGet package"

			# Load the nuspec file as XML
			$nuspec = [xml](Get-Content -Path $nuspecPath)
			$metadata = $nuspec.package.metadata

			# Edit the metadata
			$metadata.version = $metadata.version.Replace("[buildNumber]", $buildNumber)

			if(! $isMainBranch)
			{
				$metadata.version = $metadata.version + "-$branchName"
			}
			
			$metadata.releaseNotes = "Build Number: $buildNumber`r`nBranch Name: $branchName`r`nCommit Hash: $gitCommitHash"

			# Save the nuspec file
			$nuspec.Save((Get-Item $nuspecPath))

			# package as NuGet package
			exec { & $nugetExe pack $nuspecPath -OutputDirectory $applicationsOutputDirectory}
		}
		else
		{
			Write-Host "Packaging $($application.Name) as a zip file"

			$inputDirectory = "$($application.FullName)\*"
			$archivePath = "$($applicationsOutputDirectory)\$($application.Name).zip"

			Exec { & $7ZipExe a -r -mx3 $archivePath $inputDirectory }
		}

		#Moving NuGet libraries to the packages directory
		if (Test-Path $publishedLibrariesDirectory)
		{
			if (!(Test-Path $librariesOutputDirectory))
			{
				Mkdir $librariesOutputDirectory | Out-Null
			}

			Get-ChildItem -Path $publishedLibrariesDirectory -Filter "*.nupkg" -Recurse | Move-Item -Destination $librariesOutputDirectory
		}
	}
}

task Clean `
	-depends Compile, Test, Package `
	-description "Remove temporary files" `
	-requiredVariables temporaryOutputDirectory `
{ 
	if (Test-Path $temporaryOutputDirectory) 
	{
		Write-Host "Removing temporary output directory located at $temporaryOutputDirectory"

		Remove-Item $temporaryOutputDirectory -force -Recurse
	}
}