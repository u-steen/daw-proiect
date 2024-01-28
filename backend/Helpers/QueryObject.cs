namespace backend.Helpers;

public class QueryObject
{
    public string? titlu { get; set; } = null;
    public string? sortBy { get; set; } = null;
    public bool isDescending { get; set; } = false;
    public int pageSize { get; set; } = 10;
    public int pageNumber { get; set; } = 1;
}
