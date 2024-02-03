namespace RoyalLibrary.API.Helpers
{
    public abstract class PaginatedResultBase
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalRegisters { get; set; }
        public int FirstLinePage
        {
            get { return (Page - 1) * ItemsPerPage + 1; }
        }
        public int LastLinePage
        {
            get { return Math.Min(Page * ItemsPerPage, TotalRegisters); }
        }
    }
}
