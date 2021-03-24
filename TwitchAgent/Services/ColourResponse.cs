using System;

namespace TwitchAgent
{
    public partial class ColourResponse
    {
        public Hex Hex { get; set; }
        public Rgb Rgb { get; set; }
        public Hsl Hsl { get; set; }
        public Hsv Hsv { get; set; }
        public Name Name { get; set; }
        public Cmyk Cmyk { get; set; }
        public Xyz Xyz { get; set; }
        public Image Image { get; set; }
        public Contrast Contrast { get; set; }
        public Links Links { get; set; }
        public Embedded Embedded { get; set; }
    }

    public partial class Cmyk
    {
        public CmykFraction Fraction { get; set; }
        public string Value { get; set; }
        public long C { get; set; }
        public long M { get; set; }
        public long Y { get; set; }
        public long K { get; set; }
    }

    public partial class CmykFraction
    {
        public long C { get; set; }
        public double M { get; set; }
        public long Y { get; set; }
        public long K { get; set; }
    }

    public partial class Contrast
    {
        public string Value { get; set; }
    }

    public partial class Embedded
    {
    }

    public partial class Hex
    {
        public string Value { get; set; }
        public string Clean { get; set; }
    }

    public partial class Hsl
    {
        public HslFraction Fraction { get; set; }
        public long H { get; set; }
        public long S { get; set; }
        public long L { get; set; }
        public string Value { get; set; }
    }

    public partial class HslFraction
    {
        public double H { get; set; }
        public long S { get; set; }
        public double L { get; set; }
    }

    public partial class Hsv
    {
        public HsvFraction Fraction { get; set; }
        public string Value { get; set; }
        public long H { get; set; }
        public long S { get; set; }
        public long V { get; set; }
    }

    public partial class HsvFraction
    {
        public double H { get; set; }
        public long S { get; set; }
        public long V { get; set; }
    }

    public partial class Image
    {
        public Uri Bare { get; set; }
        public Uri Named { get; set; }
    }

    public partial class Links
    {
        public Self Self { get; set; }
    }

    public partial class Self
    {
        public string Href { get; set; }
    }

    public partial class Name
    {
        public string Value { get; set; }
        public string ClosestNamedHex { get; set; }
        public bool ExactMatchName { get; set; }
        public long Distance { get; set; }
    }

    public partial class Rgb
    {
        public RgbFraction Fraction { get; set; }
        public long R { get; set; }
        public long G { get; set; }
        public long B { get; set; }
        public string Value { get; set; }
    }

    public partial class RgbFraction
    {
        public long R { get; set; }
        public double G { get; set; }
        public long B { get; set; }
    }

    public partial class Xyz
    {
        public XyzFraction Fraction { get; set; }
        public string Value { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
    }

    public partial class XyzFraction
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
