using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    public void OnGet()
    {

    }

    public IActionResult OnGetMilesToKilometers(string input)
    {
        return RedirectToPage(ConversionTypes.MilesToKilometers, input);
    }
}
