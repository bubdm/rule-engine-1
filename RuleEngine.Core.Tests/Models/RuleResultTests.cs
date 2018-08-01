using AutoFixture;
using FluentAssertions;
using RuleEngine.Core.Models;
using Xunit;

namespace RuleEngine.Core.Tests.Models
{
    public sealed class RuleResultTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Fact]
        public void Constructor_WhenCodeAndMessageAreSpecified_ShouldConstructObject()
        {
            string code = _fixture.Create<string>();
            string message = _fixture.Create<string>();

            RuleResult ruleResult = new RuleResult(code, message);

            ruleResult.Code.Should().Be(code);
            ruleResult.Message.Should().Be(message);
        }
    }
}
