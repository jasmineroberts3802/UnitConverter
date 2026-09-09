using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public string ConversionType { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "[BindProperty(SupportsGet = true)]";

        ConversionType = "[BindProperty(SupportsGet = true)]";

        ViewData["ConversionType"] = "Miles to Kilometers";

        ViewData["Title"] = "Conversions";

        Output = new UnitOf.Length().FromMiles(Convert.ToDouble(Input)).ToKilometers().ToString();

    }
}
