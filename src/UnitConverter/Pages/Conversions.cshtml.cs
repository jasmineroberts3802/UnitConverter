using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    // created ConversionType string
    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;

    public bool inputErrorIsThrown = false;
    public bool conversionTypeErrorIsThrown = false;

    // added parameters for input and conversiontype for route binding
    public void OnGet(string conversionType, string input) // flip parameters
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
        catch (Exception e)
        {
            // Put the error in ViewData
            ViewData["InputErrorMessage"] = "Error: Input must be a valid number.";
            inputErrorIsThrown = true;

            // Then
            return;
        }

        switch (conversionType.ToLower())
        {
            case "milestokilometers":
                Output = new UnitOf.Length().FromMiles(value).ToKilometers().ToString();
                break;
            case "kilometerstomiles":
                // convert kilometers to miles
                Output = new UnitOf.Length().FromKilometers(value).ToMiles().ToString();
                break;
            case "fahrenheittocelsius":
                // convert fahrenheit to celsius
                Output = new UnitOf.Temperature().FromFahrenheit(value).ToCelsius().ToString();
                break;
            case "celsiustofahrenheit":
                // convert celsius to fahrenheit
                Output = new UnitOf.Temperature().FromCelsius(value).ToFahrenheit().ToString();
                break;
            case "poundstokilograms":
                // convert pounds to kilograms
                Output = new UnitOf.Mass().FromPounds(value).ToKilograms().ToString();
                break;
            case "kilogramstopounds":
                // convert kilograms to pounds
                Output = new UnitOf.Mass().FromKilograms(value).ToPounds().ToString();
                break;
            case "bitstobytes"/* conversion supported by UnitOf */ :
                // unitof conversion operation
                Output = new UnitOf.DataStorage().FromBits(value).ToBytes().ToString();
                break;
            case "bytestobits"/* reverse conversion supported by UnitOf */:
                // unitof conversion operation
                Output = new UnitOf.DataStorage().FromBytes(value).ToBits().ToString();
                break;
            default:
                // viewdata error message
                ViewData["ConversionTypeErrorMessage"] = "Error: Conversion type is not supported.";
                conversionTypeErrorIsThrown = true;
                break;
        }
    }
}
