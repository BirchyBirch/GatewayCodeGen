﻿namespace Birchy.GatewayCodeGen.Core
{
    public class CodeGenerationConfiguration
    {
        private string _dalBaseClassName;
        public string CoreNamespace { get; set; }
        public string DataNamespace { get; set; }
        public string ContractNamespace { get; set; }
        public string DatabaseName { get; set; }

        public string[] IncludeTables { get; set; }
        public string[] ExcludeSchemas { get; set; }

        public string ConnectionString { get; set; }

        public bool ShouldMakeDtos { get; set; }
        public bool ShouldMakeSql { get; set; }

        public string DalBaseClassName
        {
            get { return _dalBaseClassName ?? "GatewayBase"; }
            set { _dalBaseClassName = value; }
        }

        public string ConnectionStringName => DatabaseName + "ConnectionString";
    }
}