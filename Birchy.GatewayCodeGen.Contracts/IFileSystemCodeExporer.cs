using System.IO;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Contracts
{
    public interface IFileSystemCodeExporer
    {
        DiagnosticResults ExportCode(GeneratedDataAccessLayer generatedCode, DirectoryInfo baseDirectory);
    }
}