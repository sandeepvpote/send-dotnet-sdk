namespace SitecoreSendConsole.Models;

public class Context
{
    public Paging Paging { get; set; }
    public List<SubscribeContext> Subscribers { get; set; }
}

public class Paging
{
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalResults { get; set; }
    public int TotalPageCount { get; set; }
    public string SortExpression { get; set; }
    public bool SortIsAscending { get; set; }
}

public class SubscriberListResponse
{
    public int Code { get; set; }
    public object Error { get; set; }
    public Context Context { get; set; }
}