namespace Ef_TestPaginationIssueApp.Types
{
    public class Phone
    {
        public long Id { get; set; }
        public string? CountryCode { get; set; }

        public string? AreaCode { get; set; }

        public string? Number { get; set; }

        public string? Extension { get; set; }

        public string? FullNumber { get; set; }
    }
}
