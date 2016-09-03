using System.Collections.Generic;
using System.Linq;
using Birchy.GatewayCodeGen.Contracts;
using Birchy.GatewayCodeGen.Core;

namespace Birchy.GatewayCodeGen.Repository
{
    public class CodeGenerationRepository : ICodeGenerationRepository
    {
        private readonly IDatabaseTableInfoRepository _tableInfoRepository;
        private readonly IDataTransferObjectGenerator _dtoGenerator;
        private readonly IGatewayBaseObjectGenerator _baseObjectGenerator;
        private readonly IGatewayGenerator _gatewayGenerator;
        private readonly ISqlGenerator _sqlGenerator;

        public CodeGenerationRepository(IDatabaseTableInfoRepository tableInfoRepository,
            IDataTransferObjectGenerator dtoGenerator,
            IGatewayBaseObjectGenerator baseObjectGenerator,
            IGatewayGenerator gatewayGenerator,
            ISqlGenerator sqlGenerator)
        {
            _tableInfoRepository = tableInfoRepository;
            _dtoGenerator = dtoGenerator;
            _baseObjectGenerator = baseObjectGenerator;
            _gatewayGenerator = gatewayGenerator;
            _sqlGenerator = sqlGenerator;
        }

        public GeneratedDataAccessLayer GenerateDataAccessLayer(CodeGenerationConfiguration configuration)
        {
            var databaseTableDefinitions = _tableInfoRepository.GetDefinitions(configuration);
            var generateGatewayBaseObject = _baseObjectGenerator.GenerateGatewayBaseObject(configuration);
            return new GeneratedDataAccessLayer
            {
                GatewayBaseCode = generateGatewayBaseObject,
                TableLevelCode = databaseTableDefinitions.Select(s => new GeneratedCode
                {
                    GatewayCode = _gatewayGenerator.GenerateGatewayClass(configuration, s),
                    EntityName = s.FormattedName,
                    DataTransferObjectCode = _dtoGenerator.GenerateCode(configuration,s)
                }).ToArray()
            };
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