using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Repository;

namespace Birchy.GatewayCodeGen.WinformUI
{
    public partial class CodeGenerator : Form
    {
        private readonly CodeGenerationRepository _codeGenerationRepository;

        public CodeGenerator(CodeGenerationRepository codeGenerationRepository)
        {
            _codeGenerationRepository = codeGenerationRepository;            
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            WhereToSave.Click += WhereToSave_TextChanged;
            WhereToSave.KeyPress += WhereToSave_KeyPress;
            GenerateDtosCk.Checked = true;
            GenerateSqlCk.Checked = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            EnableGenerateButton();
        }

        private void EnableGenerateButton()
        {
            GenerateCodeButton.Text = @"Generate Code";
            GenerateCodeButton.BackColor = Color.Bisque;
            GenerateCodeButton.Enabled = true;
        }

        private void WhereToSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
                InvokeFileDialog();
        }        

        private void GenerateCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                DisableButton();
                var codeGenerationConfiguration = GetConfigurationFromFormInput();
                var di = new DirectoryInfo(WhereToSave.Text);
                if (!di.Exists)
                {
                    MessageBox.Show(@"Your directory doesnt exist. Create it");
                    return;
                }
                var csDir = InitCsDir(di);
                var sqlDir = InitSqlDir(di);
                try
                {
                    var generatedCodes = _codeGenerationRepository.GenerateCode(codeGenerationConfiguration);
                    foreach (var generatedCode in generatedCodes)
                    {
                        var csPath = Path.Combine(csDir, generatedCode.EntityName + "Dto" + ".cs");
                        var sqlPath = Path.Combine(sqlDir, generatedCode.EntityName + ".sql");
                        SafeWriteFile(csPath, generatedCode.DataTransferObjectCode);
                        SafeWriteFile(sqlPath, generatedCode.SqlCode);
                    }
                    Process.Start(di.FullName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                EnableGenerateButton();
            }
        }

        private static string InitCsDir(DirectoryInfo rootDir)
        {
            var csDir = Path.Combine(rootDir.FullName, @"cs");
            var csDirInfo = new DirectoryInfo(csDir);
            if (!csDirInfo.Exists)
                csDirInfo.Create();
            return csDir;
        }

        private static string InitSqlDir(DirectoryInfo rootDir)
        {
            var sqlDir = Path.Combine(rootDir.FullName, @"sql");
            var directoryInfo = new DirectoryInfo(sqlDir);
            if (!directoryInfo.Exists)
                directoryInfo.Create();
            return sqlDir;
        }

        private void DisableButton()
        {
            GenerateCodeButton.Enabled = false;
            GenerateCodeButton.Text = @"In Progress";
            GenerateCodeButton.BackColor = Color.Chartreuse;
        }

        private CodeGenerationConfiguration GetConfigurationFromFormInput()
        {
            var includeTables = IncludeTablesBox.Text.Split(',').Select(s => s.Trim()).ToArray();
            if (IncludeTablesBox.Text.Trim().Length == 0)
                includeTables = new string[0];
            var excludeSchemas = ExcludeSchemasBox?.Text?.Split(',')?.Select(s => s.Trim())?.ToArray() ?? new string[0];
            if (ExcludeSchemasBox.Text.Trim().Length == 0)
                excludeSchemas = new string[0];
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = ServerNameBox.Text,
                InitialCatalog = DBNameBox.Text,
                IntegratedSecurity = true
            }.ToString();
            var codeGenerationConfiguration = new CodeGenerationConfiguration
            {
                DatabaseName = DBNameBox.Text,
                ConnectionString = connectionString,
                CoreNamespace = CoreNamespaceBox.Text.Replace(" ", string.Empty),
                ShouldMakeSql = GenerateSqlCk.Checked,
                ShouldMakeDtos = GenerateDtosCk.Checked,
                IncludeTables = includeTables,
                ExcludeSchemas = excludeSchemas
            };
            return codeGenerationConfiguration;
        }

        private static void SafeWriteFile(string csPath, string generatedCode)
        {
            try
            {
                File.WriteAllText(csPath, generatedCode);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Couldnt write file: " + csPath);
            }
        }

        private void CodeGenerator_Load(object sender, EventArgs e)
        {
        }

        private void WhereToSave_TextChanged(object sender, EventArgs e)
        {
            InvokeFileDialog();
        }

        private void InvokeFileDialog()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog {ShowNewFolderButton = true})
            {
                var dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    WhereToSave.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}