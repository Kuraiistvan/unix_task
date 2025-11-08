namespace Core.Specifications;

public class ProductParams
{
    private const int MaxPages = 50;

    public int CurrentPage { get; set; } = 1;

    private int _pagesize = 6;
    public int PageSize
    {
        get => _pagesize;
        set
        {
            _pagesize = value > MaxPages ? value = MaxPages : value;
        }
    }

    private List<string> _brands = [];
    public List<string> Brands
    {
        get => _brands;
        set
        {
            _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }

    private List<string> _types = [];
    public List<string> Types
    {
        get => _types;
        set
        {
            _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
        }
    }

        private string? _search;
    public string Search
    {
        get => _search ?? "";
        set
        {
            _search = value.ToLower();
        }
    }

    public int? minPrice { get; set; }

    public int? maxPrice { get; set; }

    public string? Sort { get; set; }
}