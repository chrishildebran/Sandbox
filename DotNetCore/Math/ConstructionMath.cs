namespace DotNetCore.Math;

using Kelly.Domain.Core.Doubles;
using Kelly.Domain.Core.Enums;
using Kelly.Domain.Core.Services;

internal class ConstructionMath
{

	public ConstructionMath()
	{
		var feet = 123.523; // 10' 3-3/8"

		Console.WriteLine("New Way");
		var d = feet * 12;
		Console.WriteLine("Floor To Feet/Inches: " + d.FloorToFeetInchFraction(1));
		Console.WriteLine("Floor To Feet/Inches: " + d.FloorToFeetInchFraction(2));
		Console.WriteLine("Floor To Feet/Inches: " + d.FloorToFeetInchFraction(4));
		Console.WriteLine("Floor To Feet/Inches: " + d.FloorToFeetInchFraction(8));
		Console.WriteLine("Floor To Feet/Inches: " + d.FloorToFeetInchFraction(16));
		Console.WriteLine("Floor To Feet/Inches: " + d.FloorToFeetInchFraction(32));
		Console.WriteLine("");
		Console.WriteLine("Ceiling Feet/Inches: " + d.CeilingToFeetInchFraction(1));
		Console.WriteLine("Ceiling Feet/Inches: " + d.CeilingToFeetInchFraction(2));
		Console.WriteLine("Ceiling Feet/Inches: " + d.CeilingToFeetInchFraction(4));
		Console.WriteLine("Ceiling Feet/Inches: " + d.CeilingToFeetInchFraction(8));
		Console.WriteLine("Ceiling Feet/Inches: " + d.CeilingToFeetInchFraction(16));
		Console.WriteLine("Ceiling Feet/Inches: " + d.CeilingToFeetInchFraction(32));


		// The Double Extensions assume the value is in decimal inches not feet as revit does

		// My Way
		Console.WriteLine("");
		Console.WriteLine("My Way");
		Console.WriteLine("Feet/Inches/Fraction: " + ConstructionServices.ConvertDecimalFeetToFractionalFormat(feet, .5,     FractionalFormat.FeetInchAndFraction));
		Console.WriteLine("Feet/Inches/Fraction: " + ConstructionServices.ConvertDecimalFeetToFractionalFormat(feet, .25,    FractionalFormat.FeetInchAndFraction));
		Console.WriteLine("Feet/Inches/Fraction: " + ConstructionServices.ConvertDecimalFeetToFractionalFormat(feet, .125,   FractionalFormat.FeetInchAndFraction));
		Console.WriteLine("Feet/Inches/Fraction: " + ConstructionServices.ConvertDecimalFeetToFractionalFormat(feet, .0625,  FractionalFormat.FeetInchAndFraction));
		Console.WriteLine("Feet/Inches/Fraction: " + ConstructionServices.ConvertDecimalFeetToFractionalFormat(feet, .03125, FractionalFormat.FeetInchAndFraction));
	}

}