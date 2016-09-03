namespace Birchy.GatewayCodeGen.Core
{
    public class GeneratedCode
    {
        public string EntityName { get; set; }
        public string DataTransferObjectCode { get; set; }
        public string SqlCode { get; set; }
        public string GatewayCode { get; set; }
    }

    public class GeneratedDataAccessLayer
    {
        public GeneratedCode[] TableLevelCode { get; set; }
        public string GatewayBaseCode { get; set; }
    }
}