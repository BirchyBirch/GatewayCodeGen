using System.Collections.Generic;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Repository
{
    public class CodeGenerationRepository
    {
        private readonly IDatabaseTableInfoRepository _tableInfoRepository;
        private readonly IDataTransferObjectGenerator _dtoGenerator;
        private readonly ISqlGenerator _sqlGenerator;

        public CodeGenerationRepository(IDatabaseTableInfoRepository tableInfoRepository,
            IDataTransferObjectGenerator dtoGenerator,
            ISqlGenerator sqlGenerator)
        {
            _tableInfoRepository = tableInfoRepository;
            _dtoGenerator = dtoGenerator;
            _sqlGenerator = sqlGenerator;
        }

        public GeneratedCode[] GenerateCode(CodeGenerationConfiguration configuration)
        {
            var databaseTableDefinitions = _tableInfoRepository.GetDefinitions(configuration);
            List<GeneratedCode> generatedCode = new List<GeneratedCode>();
            foreach (var databaseTableDefinition in databaseTableDefinitions)
            {
                var generateInsert = _sqlGenerator.GenerateInsert(databaseTableDefinition);
                var generateSelect = _sqlGenerator.GenerateSelect(databaseTableDefinition);
                var generatedDto = _dtoGenerator.GenerateCode(configuration, databaseTableDefinition);
                generatedCode.Add(new GeneratedCode
                {
                    EntityName = databaseTableDefinition.FormattedName,
                    DataTransferObjectCode = generatedDto,
                    SqlCode = $"{generateSelect}\r\n--================\r\n{generateInsert}"
                });
            }
            return generatedCode.ToArray();
        }
    }
}