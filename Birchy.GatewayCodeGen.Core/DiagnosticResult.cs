using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birchy.GatewayCodeGen.Core
{
    public class DiagnosticResults
    {
        public DiagnosticResults(IEnumerable<DiagnosticResult> allResults )
        {
            Results = allResults.ToArray();
        }

        public bool IsItAllGood => Results.All(a => !a.HasError);
        public DiagnosticResult[] Results { get; }
    }

    public class DiagnosticResult
    {
        public static DiagnosticResult Ok = new DiagnosticResult(null);

        public DiagnosticResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public bool HasError => ErrorMessage != null;
        public string ErrorMessage { get; set; }
    }
}
