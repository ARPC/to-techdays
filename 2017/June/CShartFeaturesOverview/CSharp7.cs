using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class CSharp7
    {
        //  binary literals
        public const int One = 0b0001;
        public const int Two = 0b0010;
        public const int Four = 0b0100;
        public const int Eight = 0b1000;

        //  binary literals and digit separator
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000______________0000;

        //  digit separator 
        public const long BillionsAndBillions = 100_000_000_000;
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
    }
}
