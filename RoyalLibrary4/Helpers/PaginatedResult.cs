namespace RoyalLibrary.API.Helpers
{
    public class PaginatedResult<T> : PaginatedResultBase where T : class
    {
        public List<T> Result { get; set; }
        public PaginatedResult()
        {
            Result = new List<T>();
        }
    }
}
