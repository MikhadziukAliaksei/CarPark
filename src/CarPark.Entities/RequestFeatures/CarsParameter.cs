namespace CarPark.Entities.RequestFeatures
{
    public class CarsParameter: RequestParameter
    {
        public CarsParameter()
        {
            OrderBy = "mark";
        }

        public uint MinYearOfIssue { get; set; }
        public uint MaxYearOfIssue { get; set; } = int.MaxValue;

        public bool ValidYearOfIssueRange => MaxYearOfIssue > MinYearOfIssue;

        public string SearchTerm { get; set; }

    }
}
