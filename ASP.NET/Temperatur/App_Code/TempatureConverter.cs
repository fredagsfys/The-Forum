using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TempatureConverter
/// </summary>
public class TempatureConverter
{
    public static int FahrenheitToCelcius(int degreesF)
    {
        return (degreesF - 32) * 5/9;
    }
    public static int CelciusToFahrenheit(int degreesC)
    {
        return degreesC * 9/5 + 32;
    }
	public TempatureConverter()
	{
	}
}