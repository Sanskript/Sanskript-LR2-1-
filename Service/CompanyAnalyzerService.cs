namespace LR2_1.Service
{
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

            // Читаємо дані з JSON, XML та INI файлів
            _configuration.GetSection("companies").Bind(companies);

            // Знаходимо компанію з найбільшою кількістю співробітників
            var largestCompany = companies.OrderByDescending(c => c.Employees).FirstOrDefault();
            return largestCompany?.Name;
        }
    }

}
