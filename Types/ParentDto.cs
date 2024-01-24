namespace Ef_TestPaginationIssueApp.Types
{
    public class ParentDto
    {
        public long ParentId { get; set; }

        public int? SomeValue1 { get; set; }
        public int? SomeValue2 { get; set; }
        public int? CalculatedValue { get; set; }
        public int? CalculatedValue2 { get; set; }

        public string FullNumber { get; set; }
    }
}
