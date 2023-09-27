namespace DotNetCore.Previous;

using System.Globalization;

using JetBrains.Annotations;

public static class RoundAmount
{

    #region Properties

    public static double OneEighth => .125;

    public static int OneEighthLength => LengthOfDecimal(OneEighth);

    public static int OneFourthLength => LengthOfDecimal(OneFourth);

    public static double OneHalf => .5;

    public static int OneHalfLength => LengthOfDecimal(OneHalf);

    public static double OneSixTeenth => .0625;

    public static double OneSixTeenthInFeet => OneSixTeenth / 12;

    public static int OneSixTeenthLength => LengthOfDecimal(OneSixTeenth);

    public static int OneSixtyFourthLength => LengthOfDecimal(OneSixtyFourth);

    public static double OneThirtySecond => .03125;

    public static int OneThirtySecondLength => LengthOfDecimal(OneThirtySecond);

    public static int OneTwoFiftySixthLength => LengthOfDecimal(OneTwoFiftySixth);

    private static double OneFourth => .25;

    private static double OneSixtyFourth => .015625;

    private static double OneTwoFiftySixth => .00390625;

    #endregion

    #region Methods


    public static int LengthOfDecimal([NotNull] double number)
    {
        var s = number.ToString(CultureInfo.InvariantCulture);

        var length = s.Substring(s.IndexOf(".", StringComparison.Ordinal) + 1).Length;

        return length;
    }


    public static int LengthOfDecimalOld(double number)
    {
        var s = number.ToString(CultureInfo.InvariantCulture);

        return s.StartsWith("0.") ? s.Remove(0, 2).Length : 15;
    }

    #endregion

}