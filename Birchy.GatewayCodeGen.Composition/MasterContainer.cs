using Birchy.GatewayCodeGen.Data;
using Birchy.GatewayCodeGen.Engine;
using Birchy.GatewayCodeGen.Engine.SQL;
using Birchy.GatewayCodeGen.Repository;

namespace Birchy.GatewayCodeGen.Composition
{
    public class MasterContainer
    {
        public MasterContainer()
        {
            var codeGenerationRepository = new CodeGenerationRepository(
                new DatabaseTableInfoRepository(),
                new DataTransferObjectGenerator(),
                new HackyGatewayBaseObjectGenerator(),
                new HackyGatewayGenerator(new SqlGenerator()),
                new SqlGenerator());
            var fileSystemCodeExporter = new FileSystemCodeExporter();
            Facade = new GenerationFacade(codeGenerationRepository, fileSystemCodeExporter);
        }

        public GenerationFacade Facade { get; }
    }
}