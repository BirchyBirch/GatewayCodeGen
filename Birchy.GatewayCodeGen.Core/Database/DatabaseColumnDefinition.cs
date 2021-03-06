﻿namespace Birchy.GatewayCodeGen.Core.Database
{
    public class DatabaseColumnDefinition
    {
        public string Name { get; set; }
        public string FormattedName => Name.ToPascalCase();
        public SqlDataType SqlDataType { get; set; }

        public bool IsIdentity { get; set; }
        public bool IsNullable { get; set; }

        public string FullCSharpType
        {
            get
            {
                if (SqlDataType == SqlDataType.NVarchar || SqlDataType == SqlDataType.NVarchar|| !IsNullable)
                    return SqlDataType.CSharpType;
                return SqlDataType.CSharpType + "?";
            }
        }
    }


}