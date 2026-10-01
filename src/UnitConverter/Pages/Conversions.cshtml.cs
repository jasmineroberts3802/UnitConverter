using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

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

    private ConversionModel _conversionModel = new ConversionModel();

    // added parameters for input and conversiontype for route binding
    public void OnGet(string conversionType, string input) // flip parameters
    {
        double value;

        Input = "3.1415";

        // route bound input parameter
        Input = input;

        // route bound conversiontype parameter
        ConversionType = conversionType;

        // updated view data to display the conversiontype parameter instead of hard coded miles to kilometers
        ViewData["ConversionType"] = _conversionModel.ConversionType;

        ViewData["Title"] = "Conversions";

        try
        {
            value = Convert.ToDouble(_conversionModel.Input);
        }
        catch (Exception e)
        {
            // Put the error in ViewData
            ViewData["InputErrorMessage"] = "Error: Input must be a valid number.";
            inputErrorIsThrown = true;

            // Then
            return;
        }

        switch (_conversionModel.ConversionType)
        {
            case ConversionTypes.MilesToKilometers:
                _conversionModel.Output = new UnitOf.Length().FromMiles(value).ToKilometers().ToString();
                break;
            case ConversionTypes.KilometersToMiles:
                // convert kilometers to miles
                _conversionModel.Output = new UnitOf.Length().FromKilometers(value).ToMiles().ToString();
                break;
            case ConversionTypes.FahrenheitToCelsius:
                // convert fahrenheit to celsius
                _conversionModel.Output = new UnitOf.Temperature().FromFahrenheit(value).ToCelsius().ToString();
                break;
            case ConversionTypes.CelsiusToFahrenheit:
                // convert celsius to fahrenheit
                _conversionModel.Output = new UnitOf.Temperature().FromCelsius(value).ToFahrenheit().ToString();
                break;
            case ConversionTypes.PoundsToKilograms:
                // convert pounds to kilograms
                _conversionModel.Output = new UnitOf.Mass().FromPounds(value).ToKilograms().ToString();
                break;
            case ConversionTypes.KilogramsToPounds:
                // convert kilograms to pounds
                _conversionModel.Output = new UnitOf.Mass().FromKilograms(value).ToPounds().ToString();
                break;
            case ConversionTypes.BitsToBytes /* conversion supported by UnitOf */ :
                // unitof conversion operation
                _conversionModel.Output = new UnitOf.DataStorage().FromBits(value).ToBytes().ToString();
                break;
            case ConversionTypes.BytesToBits /* reverse conversion supported by UnitOf */:
                // unitof conversion operation
                _conversionModel.Output = new UnitOf.DataStorage().FromBytes(value).ToBits().ToString();
                break;
            default:
                // viewdata error message
                ViewData["ConversionTypeErrorMessage"] = "Error: Conversion type is not supported.";
                conversionTypeErrorIsThrown = true;
                break;
        }
    }
}
