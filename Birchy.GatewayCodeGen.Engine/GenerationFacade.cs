using System.IO;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Engine
{
    public class GenerationFacade : ICodeGenerationRepository, IFileSystemCodeExporer
    {
        private readonly ICodeGenerationRepository _repository;
        private readonly IFileSystemCodeExporer _codeExporter;

        public GenerationFacade(ICodeGenerationRepository repository, IFileSystemCodeExporer codeExporter)
        {
            _repository = repository;
            _codeExporter = codeExporter;
        }
        public GeneratedDataAccessLayer GenerateDataAccessLayer(CodeGenerationConfiguration configuration)
        {
            return _repository.GenerateDataAccessLayer(configuration);
        }

        public GeneratedCode[] GenerateCode(CodeGenerationConfiguration configuration)
        {
            return _repository.GenerateCode(configuration);
        }

        public DiagnosticResults ExportCode(GeneratedDataAccessLayer generatedCode, DirectoryInfo baseDirectory)
        {
            return _codeExporter.ExportCode(generatedCode, baseDirectory);
        }
    }
}
