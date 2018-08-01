namespace RuleEngine.Core.Models
{
    public sealed class RuleResult
    {
        public RuleResult(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message { get; }
    }
}
