namespace TestingDotNetCore.Previous;

using System.Text.RegularExpressions;

internal class StringUtils
{

    #region Constructors

    public StringUtils(string input)
    {
        this.input = input;
    }

    #endregion

    #region Properties

    public string input { get; set; }

    #endregion

    #region Methods

    public string NormalizeWhiteSpace()
    {
        if (string.IsNullOrEmpty(this.input))
        {
            return string.Empty;
        }

        var current = 0;
        var output  = new char[this.input.Length];
        var skipped = false;

        foreach (var c in this.input)
        {
            if (char.IsWhiteSpace(c))
            {
                if (!skipped)
                {
                    if (current > 0)
                    {
                        output[current++] = ' ';
                    }

                    skipped = true;
                }
            }
            else
            {
                skipped = false;
                output[current++] = c;
            }
        }

        return new string(output, 0, current);
    }


    public string NormalizeWhiteSpaceForLoop()
    {
        int  len  = this.input.Length, index = 0, i = 0;
        var  src  = this.input.ToCharArray();
        var  skip = false;
        char ch;

        for (; i < len; i++)
        {
            ch = src[i];

            switch (ch)
            {
                case '\u0020':
                case '\u00A0':
                case '\u1680':
                case '\u2000':
                case '\u2001':
                case '\u2002':
                case '\u2003':
                case '\u2004':
                case '\u2005':
                case '\u2006':
                case '\u2007':
                case '\u2008':
                case '\u2009':
                case '\u200A':
                case '\u202F':
                case '\u205F':
                case '\u3000':
                case '\u2028':
                case '\u2029':
                case '\u0009':
                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u000D':
                case '\u0085':
                    if (skip)
                    {
                        continue;
                    }

                    src[index++] = ch;
                    skip = true;

                    continue;

                default:
                    skip = false;
                    src[index++] = ch;

                    continue;
            }
        }

        return new string(src, 0, index);
    }


    public string WithRegex()
    {
        return Regex.Replace(this.input, @"\s+", " ");
    }


    public string WithRegexCompiled(Regex compiledRegex)
    {
        return compiledRegex.Replace(this.input, " ");
    }

    #endregion

}