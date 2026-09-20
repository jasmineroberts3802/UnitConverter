namespace UnitConverter.Pages;

public static class ConversionTypes
{
    public const string MilesToKilometers = "MilesToKiolmeters";

    public const string KilometersToMiles = "KiolmetersToMiles";

    public const string FahrenheitToCelsius = "FahrenheitToCelsius";

    public const string CelsiusToFahrenheit = "CelsiusToFahrenheit";

    public const string PoundsToKilograms = "PoundsToKilograms";

    public const string KilogramsToPounds = "KilogramsToPounds";

    public const string BitsToBytes = "BitsToBytes";

    public const string BytesToBits = "BytesToBits";

    public static readonly IReadOnlyDictionary<string, string> All =
        new Dictionary<string, string>
        {
            [MilesToKilometers] = "Miles To Kilometers",
            [KilometersToMiles] = "Kilometers To Miles",
            [FahrenheitToCelsius] = "Fahrenheit To Celsius",
            [CelsiusToFahrenheit] = "Celsius To Fahrenheit",
            [PoundsToKilograms] = "Pounds To Kilograms",
            [KilogramsToPounds] = "Kilograms to Pounds",
            [BitsToBytes] = "Bits To Bytes",
            [BytesToBits] = "Bytes To Bits",
        };
}
