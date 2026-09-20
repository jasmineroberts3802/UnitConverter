using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace UnitConverter.Pages;

public class IndexModel : PageModel
{

    public string Message { get; set; } = string.Empty;
    public void OnPost(string conversionType)
    {
        if (!StringValues.IsNullOrEmpty(Request.Query["conversionType"]))
        {
            Message = $"You chose to convert {Request.Query["conversionType"]}";
        }
    }
    public void OnGet()
    {

    }
}
