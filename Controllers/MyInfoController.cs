using Microsoft.AspNetCore.Mvc;

public class MyInfoController : Controller
{
    private readonly IConfiguration _configuration;

    public MyInfoController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var name = _configuration["Name"];
        var age = _configuration["Age"];
        var university = _configuration["University"];
        var specialty = _configuration["Specialty"];

        return Content($"Name: {name}, Age: {age}, University: {university}, Specialty: {specialty}");
    }
}
