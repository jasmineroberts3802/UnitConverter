using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    // created ConversionType string
    public string ConversionType { get; set; } = string.Empty;

    // added parameters for input and conversiontype for route binding
    public void OnGet(string input, string conversionType) // flip parameters
    {
        double value;
        // route bound input parameter
        Input = input;

        // route bound conversiontype parameter
        ConversionType = conversionType;

        // updated view data to display the conversiontype parameter instead of hard coded miles to kilometers
        ViewData["ConversionType"] = conversionType;

        ViewData["Title"] = "Conversions";

        try
        {
            value = Convert.ToDouble(input);
        }
        catch (Exception /* either InvalidCast, Format, or Argument exception? */ )
        {
            // Put the error in ViewData

            // Then
            return;
        }

        switch (conversionType.ToLower())
        {
            case "milestokilometers":
                Output = new UnitOf.Length().FromMiles(value).ToKilometers().ToString();
                break;
            case "kilometers to miles":
                // convert kilometers to miles
                break;
            case "fahrenheit to celsius":
                // convert fahrenheit to celsius
                break;
            case "celsius to fahrenheit":
                // convert celsius to fahrenheit
                break;
            case "pounds to kilograms":
                // convert pounds to kilograms
                break;
            case "kilograms to pounds":
                // convert kilograms to pounds
                break;
            case /* conversion supported by UnitOf */ :
                // unitof conversion operation
                break;
            case /* reverse conversion supported by UnitOf */:
                // unitof conversion operation
                break;
            default:
                // viewdata error message
                break;
        }

        Output.ToString();

        Output = new UnitOf.Length().FromMiles(Convert.ToDouble(Input)).ToKilometers().ToString();



    }
}
