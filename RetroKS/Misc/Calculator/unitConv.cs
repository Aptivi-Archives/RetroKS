//
// RetroKS  Copyright (C) 2022  Aptivi
//
// This file is part of RetroKS
//
// RetroKS is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// RetroKS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

namespace RetroKS
{
    static class unitConv
    {

        private static object resultVal;

        public static void Converter(string sourceUnit, string targetUnit, object value)
        {

            // Begin with size conversion first...
            if (sourceUnit == "B" & targetUnit == "TB")
            {
                resultVal = (long)value / 1099511627776L;
            }
            else if (sourceUnit == "B" & targetUnit == "GB")
            {
                resultVal = (long)value / 1073741824;
            }
            else if (sourceUnit == "B" & targetUnit == "MB")
            {
                resultVal = (long)value / 1048576;
            }
            else if (sourceUnit == "B" & targetUnit == "KB")
            {
                resultVal = (long)value / 1024;
            }
            else if (sourceUnit == "B" & targetUnit == "Bits")
            {
                resultVal = (long)value * 8;
            }
            else if (sourceUnit == "KB" & targetUnit == "TB")
            {
                resultVal = (long)value / 1073741824;
            }
            else if (sourceUnit == "KB" & targetUnit == "GB")
            {
                resultVal = (long)value / 1048576;
            }
            else if (sourceUnit == "KB" & targetUnit == "MB")
            {
                resultVal = (long)value / 1024;
            }
            else if (sourceUnit == "KB" & targetUnit == "B")
            {
                resultVal = (long)value * 1024;
            }
            else if (sourceUnit == "KB" & targetUnit == "Bits")
            {
                resultVal = (long)value * 8192;
            }
            else if (sourceUnit == "MB" & targetUnit == "TB")
            {
                resultVal = (long)value / 1048576;
            }
            else if (sourceUnit == "MB" & targetUnit == "GB")
            {
                resultVal = (long)value / 1024;
            }
            else if (sourceUnit == "MB" & targetUnit == "KB")
            {
                resultVal = (long)value * 1024;
            }
            else if (sourceUnit == "MB" & targetUnit == "B")
            {
                resultVal = (long)value * 1048576;
            }
            else if (sourceUnit == "MB" & targetUnit == "Bits")
            {
                resultVal = (long)value * 8388608;
            }
            else if (sourceUnit == "GB" & targetUnit == "TB")
            {
                resultVal = (long)value / 1024;
            }
            else if (sourceUnit == "GB" & targetUnit == "MB")
            {
                resultVal = (long)value * 1024;
            }
            else if (sourceUnit == "GB" & targetUnit == "KB")
            {
                resultVal = (long)value * 1048576;
            }
            else if (sourceUnit == "GB" & targetUnit == "B")
            {
                resultVal = (long)value * 1073741824;
            }
            else if (sourceUnit == "GB" & targetUnit == "Bits")
            {
                resultVal = (long)value * 8589934592L;
            }
            else if (sourceUnit == "TB" & targetUnit == "GB")
            {
                resultVal = (long)value * 1024;
            }
            else if (sourceUnit == "TB" & targetUnit == "MB")
            {
                resultVal = (long)value * 1048576;
            }
            else if (sourceUnit == "TB" & targetUnit == "KB")
            {
                resultVal = (long)value * 1073741824;
            }
            else if (sourceUnit == "TB" & targetUnit == "B")
            {
                resultVal = (long)value * 1099511627776L;
            }
            else if (sourceUnit == "TB" & targetUnit == "Bits")
            {
                resultVal = (long)value * 8796093022208L;
            }
            else if (sourceUnit == "Bits" & targetUnit == "TB")
            {
                resultVal = (long)value / 8796093022208L;
            }
            else if (sourceUnit == "Bits" & targetUnit == "GB")
            {
                resultVal = (long)value / 8589934592L;
            }
            else if (sourceUnit == "Bits" & targetUnit == "MB")
            {
                resultVal = (long)value / 8388608;
            }
            else if (sourceUnit == "Bits" & targetUnit == "KB")
            {
                resultVal = (long)value / 8192;
            }
            else if (sourceUnit == "Bits" & targetUnit == "B")
            {
                resultVal = (long)value / 8;
            }
            else if (sourceUnit == "mm" & targetUnit == "cm") // ... then to measurements ...
            {
                resultVal = (long)value / 10;
            }
            else if (sourceUnit == "mm" & targetUnit == "m")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "mm" & targetUnit == "km")
            {
                resultVal = (long)value / 1000000;
            }
            else if (sourceUnit == "cm" & targetUnit == "mm")
            {
                resultVal = (long)value * 10;
            }
            else if (sourceUnit == "cm" & targetUnit == "m")
            {
                resultVal = (long)value / 100;
            }
            else if (sourceUnit == "cm" & targetUnit == "km")
            {
                resultVal = (long)value / 100000;
            }
            else if (sourceUnit == "m" & targetUnit == "mm")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "m" & targetUnit == "cm")
            {
                resultVal = (long)value * 100;
            }
            else if (sourceUnit == "m" & targetUnit == "km")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "km" & targetUnit == "mm")
            {
                resultVal = (long)value * 1000000;
            }
            else if (sourceUnit == "km" & targetUnit == "cm")
            {
                resultVal = (long)value * 100000;
            }
            else if (sourceUnit == "km" & targetUnit == "m")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Celsius" & targetUnit == "Fahrenheit") // ... then to temperature ...
            {
                resultVal = (long)value * 9 / 5 + 32;
            }
            else if (sourceUnit == "Celsius" & targetUnit == "Kelvin")
            {
                resultVal = (double)value + 273.15d;
            }
            else if (sourceUnit == "Fahrenheit" & targetUnit == "Celsius")
            {
                resultVal = (long)value - 32 * 5 / 9;
            }
            else if (sourceUnit == "Fahrenheit" & targetUnit == "Kelvin")
            {
                resultVal = (double)value - 459.67d * 5 / 9;
            }
            else if (sourceUnit == "Kelvin" & targetUnit == "Celsius")
            {
                resultVal = (double)value - 273.15d;
            }
            else if (sourceUnit == "Kelvin" & targetUnit == "Fahrenheit")
            {
                resultVal = (long)value * 9 / 5 - 459.67d;
            }
            else if (sourceUnit == "j" & targetUnit == "kj") // ... then to energy ...
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "kj" & targetUnit == "j")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "m/s" & targetUnit == "km/h")
            {
                resultVal = (long)value * 3.6d;
            }
            else if (sourceUnit == "m/s" & targetUnit == "cm/ms") // Note that cm/ms is Centimeters per Millisecond
            {
                resultVal = (long)value / 10;
            }
            else if (sourceUnit == "cm/ms" & targetUnit == "km/h")
            {
                resultVal = (long)value * 36;
            }
            else if (sourceUnit == "cm/ms" & targetUnit == "m/s")
            {
                resultVal = (long)value * 10;
            }
            else if (sourceUnit == "km/h" & targetUnit == "m/s")
            {
                resultVal = (long)value / 3.6d;
            }
            else if (sourceUnit == "km/h" & targetUnit == "cm/ms")
            {
                resultVal = (long)value / 36;
            }
            else if (sourceUnit == "Grams" & targetUnit == "Kilograms") // ... then to mass ...
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Grams" & targetUnit == "Tons")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "Grams" & targetUnit == "Kilotons")
            {
                resultVal = (long)value / 1000 / 1000 / 1000;
            }
            else if (sourceUnit == "Grams" & targetUnit == "Megatons")
            {
                resultVal = (long)value / 1000 / 1000 / 1000 / 1000;
            }
            else if (sourceUnit == "Kilograms" & targetUnit == "Grams")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Kilograms" & targetUnit == "Tons")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Kilograms" & targetUnit == "Kilotons")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "Kilograms" & targetUnit == "Megatons")
            {
                resultVal = (long)value / 1000 / 1000 / 1000;
            }
            else if (sourceUnit == "Tons" & targetUnit == "Grams")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "Tons" & targetUnit == "Kilograms")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Tons" & targetUnit == "Kilotons")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Tons" & targetUnit == "Megatons")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "Kilotons" & targetUnit == "Grams")
            {
                resultVal = (long)value * 1000 * 1000 * 1000;
            }
            else if (sourceUnit == "Kilotons" & targetUnit == "Kilograms")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "Kilotons" & targetUnit == "Tons")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Kilotons" & targetUnit == "Megatons")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Megatons" & targetUnit == "Grams")
            {
                resultVal = (long)value * 1000 * 1000 * 1000 * 1000;
            }
            else if (sourceUnit == "Megatons" & targetUnit == "Kilograms")
            {
                resultVal = (long)value * 1000 * 1000 * 1000;
            }
            else if (sourceUnit == "Megatons" & targetUnit == "Tons")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "Megatons" & targetUnit == "Kilotons")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "n" & targetUnit == "kn") // ... then to force ... | Note: kn is Kilonewtons
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "kn" & targetUnit == "n")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Hz" & targetUnit == "kHz") // ... then to frequency ...
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Hz" & targetUnit == "MHz")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "Hz" & targetUnit == "GHz")
            {
                resultVal = (long)value / 1000 / 1000 / 1000;
            }
            else if (sourceUnit == "kHz" & targetUnit == "Hz")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "kHz" & targetUnit == "MHz")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "kHz" & targetUnit == "GHz")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "MHz" & targetUnit == "Hz")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "MHz" & targetUnit == "kHz")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "MHz" & targetUnit == "GHz")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "GHz" & targetUnit == "Hz")
            {
                resultVal = (long)value * 1000 * 1000 * 1000;
            }
            else if (sourceUnit == "GHz" & targetUnit == "kHz")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "GHz" & targetUnit == "MHz")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Centivolts" & targetUnit == "Volts") // ... then to electricity ...
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Centivolts" & targetUnit == "Kilovolts")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "Volts" & targetUnit == "Centivolts")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Volts" & targetUnit == "Kilovolts")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Kilovolts" & targetUnit == "Centivolts")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "Kilovolts" & targetUnit == "Volts")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Watts" & targetUnit == "Kilowatts") // ... then to electricity's wattage ...
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Kilowatts" & targetUnit == "Watts")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Milliliters" & targetUnit == "Liters") // ... then to liquid's volume ...
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Milliliters" & targetUnit == "Kiloliters")
            {
                resultVal = (long)value / 1000 / 1000;
            }
            else if (sourceUnit == "Liters" & targetUnit == "Milliliters")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Liters" & targetUnit == "Kiloliters")
            {
                resultVal = (long)value / 1000;
            }
            else if (sourceUnit == "Kiloliters" & targetUnit == "Milliliters")
            {
                resultVal = (long)value * 1000 * 1000;
            }
            else if (sourceUnit == "Kiloliters" & targetUnit == "Liters")
            {
                resultVal = (long)value * 1000;
            }
            else if (sourceUnit == "Ounces" & targetUnit == "Gallons") // ... then to more liquid's volume ...
            {
                resultVal = (long)value * 0.0078125d;
            }
            else if (sourceUnit == "Gallons" & targetUnit == "Ounces")
            {
                resultVal = (long)value * 128.0d;
            }
            else if (sourceUnit == "Feet" & targetUnit == "Inches") // ... then finally to more measurements.
            {
                resultVal = (long)value * 12;
            }
            else if (sourceUnit == "Feet" & targetUnit == "Yards")
            {
                resultVal = (long)value * 0.3333333333d;
            }
            else if (sourceUnit == "Feet" & targetUnit == "Miles")
            {
                resultVal = (long)value * 0.0001893939d;
            }
            else if (sourceUnit == "Inches" & targetUnit == "Feet")
            {
                resultVal = (long)value * 0.0833333333d;
            }
            else if (sourceUnit == "Inches" & targetUnit == "Yards")
            {
                resultVal = (long)value * 0.0277777778d;
            }
            else if (sourceUnit == "Inches" & targetUnit == "Miles")
            {
                resultVal = (long)value * 0.0000157828d;
            }
            else if (sourceUnit == "Yards" & targetUnit == "Feet")
            {
                resultVal = (long)value * 3;
            }
            else if (sourceUnit == "Yards" & targetUnit == "Inches")
            {
                resultVal = (long)value * 36;
            }
            else if (sourceUnit == "Yards" & targetUnit == "Miles")
            {
                resultVal = (long)value * 0.0005681818d;
            }
            else if (sourceUnit == "Miles" & targetUnit == "Feet")
            {
                resultVal = (long)value * 5280;
            }
            else if (sourceUnit == "Miles" & targetUnit == "Inches")
            {
                resultVal = (long)value * 63360;
            }
            else if (sourceUnit == "Miles" & targetUnit == "Yards")
            {
                resultVal = (long)value * 1760;
            }
            else
            {
                TextWriterColor.Wln("{0} cannot be converted to {1}.", "neutralText");
                return;
            }
            TextWriterColor.Wln("{0} to {1}: {2}", "neutralText", sourceUnit, targetUnit, resultVal);

        }

    }
}