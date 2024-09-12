public class Company
{
    public string Name { get; set; }
    public int Employees { get; set; }
}

public class CompanyAnalyzerService
{
    private readonly IConfiguration _configuration;

    public CompanyAnalyzerService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetLargestCompany()
    {
        var companies = new List<Company>();

        _configuration.GetSection("companies").Bind(companies);

        var largestCompany = companies.OrderByDescending(c => c.Employees).FirstOrDefault();
        return largestCompany?.Name;
    }
}
