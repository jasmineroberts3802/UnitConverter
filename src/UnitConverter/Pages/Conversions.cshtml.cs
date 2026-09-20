using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    // created ConversionType string
    public string ConversionType { get; set; } = string.Empty;

    public bool inputErrorIsThrown = false;
    public bool conversionTypeErrorIsThrown = false;

    private ConversionModel conversionModel = new ConversionModel();

    // added parameters for input and conversiontype for route binding
    public void OnGet() // flip parameters
    {
        double value;

        // route bound input parameter
        Input = conversionModel.Input;

        // route bound conversiontype parameter
        ConversionType = conversionModel.ConversionType;

        // updated view data to display the conversiontype parameter instead of hard coded miles to kilometers
        ViewData["ConversionType"] = conversionModel.ConversionType;

        ViewData["Title"] = "Conversions";

        try
        {
            value = Convert.ToDouble(conversionModel.Input);
        }
        catch (Exception e)
        {
            // Put the error in ViewData
            ViewData["InputErrorMessage"] = "Error: Input must be a valid number.";
            inputErrorIsThrown = true;

            // Then
            return;
        }

        switch (conversionModel.ConversionType)
        {
            case ConversionTypes.MilesToKilometers:
                conversionModel.Output = new UnitOf.Length().FromMiles(value).ToKilometers().ToString();
                break;
            case ConversionTypes.KilometersToMiles:
                // convert kilometers to miles
                conversionModel.Output = new UnitOf.Length().FromKilometers(value).ToMiles().ToString();
                break;
            case ConversionTypes.FahrenheitToCelsius:
                // convert fahrenheit to celsius
                conversionModel.Output = new UnitOf.Temperature().FromFahrenheit(value).ToCelsius().ToString();
                break;
            case ConversionTypes.CelsiusToFahrenheit:
                // convert celsius to fahrenheit
                conversionModel.Output = new UnitOf.Temperature().FromCelsius(value).ToFahrenheit().ToString();
                break;
            case ConversionTypes.PoundsToKilograms:
                // convert pounds to kilograms
                conversionModel.Output = new UnitOf.Mass().FromPounds(value).ToKilograms().ToString();
                break;
            case ConversionTypes.KilogramsToPounds:
                // convert kilograms to pounds
                conversionModel.Output = new UnitOf.Mass().FromKilograms(value).ToPounds().ToString();
                break;
            case ConversionTypes.BitsToBytes /* conversion supported by UnitOf */ :
                // unitof conversion operation
                conversionModel.Output = new UnitOf.DataStorage().FromBits(value).ToBytes().ToString();
                break;
            case ConversionTypes.BytesToBits /* reverse conversion supported by UnitOf */:
                // unitof conversion operation
                conversionModel.Output = new UnitOf.DataStorage().FromBytes(value).ToBits().ToString();
                break;
            default:
                // viewdata error message
                ViewData["ConversionTypeErrorMessage"] = "Error: Conversion type is not supported.";
                conversionTypeErrorIsThrown = true;
                break;
        }
    }
}
