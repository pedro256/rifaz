namespace Api.DTO;

public class PagedItems<T>
{
    public IList<T> Items { get; set; } = new List<T>();
    public long? Total { get; set; } = 0;
    public int Size { get; set; }
    public int Page { get; set; }

}