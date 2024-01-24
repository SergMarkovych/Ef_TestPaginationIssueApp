namespace Ef_TestPaginationIssueApp.Types
{
    public class Parent
    {
        public long Id { get; set; }

        public long? ChildId { get; set; }
        public long? PhoneId { get; set; }

        public Child Child { get; set; }
        public Phone Phone { get; set; }
    }
}
