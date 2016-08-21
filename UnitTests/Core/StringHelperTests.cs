using Birchy.GatewayCodeGen.Core;
using Xunit;

namespace UnitTests.Core
{
    public class StringHelperTests
    {
        public static object[][] CamelCaseMappings
        {
            get
            {
                return new object[][]
                {
                    new[] {"it_was_the_best_of_Times", "itWasTheBestOfTimes"},
                    new[] {"ItWasTheWorstOfTimes", "itWasTheWorstOfTimes"},
                    new[] {"arma virumque cano", "armaVirumqueCano"}
                };
            }
        }
        public static object[][] PascalCaseMappings
        {
            get
            {
                return new object[][]
                {
                    new[] {"it_was_the_best_of_Times", "ItWasTheBestOfTimes"},
                    new[] {"ItWasTheWorstOfTimes", "ItWasTheWorstOfTimes"},
                    new[] {"arma virumque cano", "ArmaVirumqueCano"}
                };
            }
        }

        [Theory]
        [MemberData(nameof(CamelCaseMappings))]
        public void ToCamelCase_ConvertesTheMappings(string input, string output)
        {
            Assert.Equal(output, input.ToCamelCase());
        }

        [Theory]
        [MemberData(nameof(PascalCaseMappings))]
        public void ToPascalCase_ConvertesTheMappings(string input, string output)
        {
            Assert.Equal(output, input.ToPascalCase());
        }
    }
}