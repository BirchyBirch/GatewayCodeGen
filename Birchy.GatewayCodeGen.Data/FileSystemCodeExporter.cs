using System;
using System.Collections.Generic;
using System.IO;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Data
{
    public class FileSystemCodeExporter : IFileSystemCodeExporer
    {
        public DiagnosticResults ExportCode(GeneratedDataAccessLayer generatedCode, DirectoryInfo baseDirectory)
        {
            var dataDir = InitDataDir(baseDirectory);
            var coreDir = InitCoreDir(baseDirectory);
            var gatewayBasePath = Path.Combine(dataDir, "GatewayBase.cs");
            List<DiagnosticResult>allResults = new List<DiagnosticResult>
            {
                SafeWriteFile(gatewayBasePath, generatedCode.GatewayBaseCode)
            };                
            foreach (var tableLevelItem in generatedCode.TableLevelCode)
            {
                var dtoPath = Path.Combine(coreDir, tableLevelItem.EntityName + "Dto" + ".cs");
                var gatewayPath = Path.Combine(dataDir, tableLevelItem.EntityName + "DataGateway.cs");
                allResults.Add(SafeWriteFile(dtoPath, tableLevelItem.DataTransferObjectCode));
                allResults.Add(SafeWriteFile(gatewayPath, tableLevelItem.GatewayCode));
            }
            return new DiagnosticResults(allResults);
        }

        private static string InitDataDir(DirectoryInfo rootDir)
        {
            var csDir = Path.Combine(rootDir.FullName, @"Data");
            var csDirInfo = new DirectoryInfo(csDir);
            if (!csDirInfo.Exists)
                csDirInfo.Create();
            return csDir;
        }

        private static string InitCoreDir(DirectoryInfo rootDir)
        {
            var sqlDir = Path.Combine(rootDir.FullName, @"Core");
            var directoryInfo = new DirectoryInfo(sqlDir);
            if (!directoryInfo.Exists)
                directoryInfo.Create();
            return sqlDir;
        }

        private static DiagnosticResult SafeWriteFile(string csPath, string generatedCode)
        {
            try
            {
                File.WriteAllText(csPath, generatedCode);
                return DiagnosticResult.Ok;
            }
            catch (Exception)
            {
                return new DiagnosticResult(@"Couldnt write file: " + csPath);
            }
        }
    }
}