using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Birchy.GatewayCodeGen.Engine;
using Birchy.GatewayCodeGen.Engine.SQL;
using Birchy.GatewayCodeGen.Repository;

namespace Birchy.GatewayCodeGen.WinformUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var codeGenerationRepository = new CodeGenerationRepository(
                    new DatabaseTableInfoRepository(),
                    new DataTransferObjectGenerator(),
                    new SqlGenerator());
            Application.Run(new CodeGenerator(codeGenerationRepository));
        }
    }
}
