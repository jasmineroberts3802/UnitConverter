using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "3.1415";

        ViewData.Add("ConversionType", "Miles to Kilometers");

        ViewData["PageTitle"] = "Conversions";

        Output = new UnitOf.Length().FromMiles(Convert.ToDouble(Input)).ToKilometers().ToString();

    }
}
