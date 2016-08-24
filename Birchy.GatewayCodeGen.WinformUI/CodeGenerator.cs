using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Birchy.GatewayCodeGen.Core;
using Birchy.GatewayCodeGen.Engine;
using Birchy.GatewayCodeGen.Engine.SQL;
using Birchy.GatewayCodeGen.Repository;

namespace Birchy.GatewayCodeGen.WinformUI
{
    public partial class CodeGenerator : Form
    {
        public CodeGenerator()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void GenerateCodeButton_Click(object sender, EventArgs e)
        {
            var includeTables = IncludeTablesBox.Text.Split(',').Select(s => s.Trim()).ToArray();
            if (IncludeTablesBox.Text.Trim().Length == 0)
                includeTables = new string[0];
            var excludeSchemas = ExcludeSchemasBox?.Text?.Split(',')?.Select(s => s.Trim())?.ToArray() ?? new string[0];
            if (ExcludeSchemasBox.Text.Trim().Length == 0)
                excludeSchemas = new string[0];
            var codeGenerationConfiguration = new CodeGenerationConfiguration
            {
                DatabaseName = DBNameBox.Text,
                ConnectionString = ConnectionStringBox.Text,
                CoreNamespace = CoreNamespaceBox.Text,
                ShouldMakeSql = GenerateSqlCk.Checked,
                ShouldMakeDtos = GenerateDtosCk.Checked,
                IncludeTables = includeTables,
                ExcludeSchemas = excludeSchemas
            };
            var di = new DirectoryInfo(WhereToSave.Text);
            if (!di.Exists)
            {
                MessageBox.Show(@"Your directory doesnt exist. Create it");
                return;
            }
            var codeGenerationRepository = new CodeGenerationRepository(new DatabaseTableInfoRepository(),
                new DataTransferObjectGenerator(),
                new SqlGenerator());
            try
            {
                var generatedCodes = codeGenerationRepository.GenerateCode(codeGenerationConfiguration);
                foreach (var generatedCode in generatedCodes)
                {
                    var csPath = Path.Combine(di.FullName, generatedCode.EntityName + ".cs");
                    var sqlPath = Path.Combine(di.FullName, generatedCode.EntityName + ".sql");
                    SafeWriteFile(csPath, generatedCode.DataTransferObjectCode);
                    SafeWriteFile(sqlPath, generatedCode.SqlCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(@"Done");
        }

        private static void SafeWriteFile(string csPath, string generatedCode)
        {
            try
            {
                File.WriteAllText(csPath, generatedCode);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldnt write file: " + csPath);
            }
        }

        private void CodeGenerator_Load(object sender, EventArgs e)
        {
        }
    }
}