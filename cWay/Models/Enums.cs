using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cWay.Models
{
    public class Enums
    {
        /// <summary>
        /// Make api call to http://vpic.nhtsa.dot.gov/api/
        /// </summary>
        
        public enum TransmissionType
        {
            SELECT, Manual, Automatic
        }

        public enum Turbo
        {
            SELECT, None, Single, Twin
        }


        public enum AxleCount
        {
            SELECT, Single, Tandem, Tri, Quad
        }
        public enum SuspensionType
        {
            SELECT, Air, Spring
        }

        public enum BrakeType
        {
            SELECT, Air, Hydraulic
        }

        public enum TireCondion : long
        {
            SELECT,
            [Display(Name = "1/32")]
            OneThirtySecond,
            [Display(Name = "2/32")]
            TwoThirtySeconds,
            [Display(Name = "3/32")]
            ThreeThirtySeconds,
            [Display(Name = "4/32")]
            FourThirtySeconds,
            [Display(Name = "5/32")]
            FiveThirtySeconds,
            [Display(Name = "6/32")]
            SixThirtySeconds,
            [Display(Name = "7/32")]
            SevenThirtySeconds,
            [Display(Name = "8/32")]
            EightThirtySeconds,
            [Display(Name = "9/32")]
            NineThirtySeconds,
            [Display(Name = "10/32")]
            TenThirtySeconds,
            [Display(Name = "11/32")]
            ElevenThirtySeconds,
            [Display(Name = "12/32")]
            TwelveThirtySeconds,
            [Display(Name = "13/32")]
            ThirteenThirtySeconds,
            [Display(Name = "14/32")]
            FourteenThirtySeconds,
            [Display(Name = "15/32")]
            FifteenThirtySeconds,
            [Display(Name = "16/32")]
            SixteenThirtySeconds,
            [Display(Name = "17/32")]
            SeventeenThirtySeconds,
            [Display(Name = "18/32")]
            EightteenThirtySeconds,
            [Display(Name = "19/32")]
            NineteenThirtySeconds,
            [Display(Name = "20/32")]
            TwentyThirtySeconds,
            [Display(Name = "21/32")]
            TwentyOneThirtySeconds,
            [Display(Name = "22/32")]
            TwentyTwoThirtySeconds,
            [Display(Name = "23/32")]
            TwentyThreeThirtySeconds,
            [Display(Name = "24/32")]
            TwentyFourThirtySeconds,
            [Display(Name = "25/32")]
            TwentyFiveThirtySeconds,
            [Display(Name = "26/32")]
            TwentySixThirtySeconds,
            [Display(Name = "27/32")]
            TwentySevenThirtySeconds,
            [Display(Name = "28/32")]
            TwentyEightThirtySeconds,
            [Display(Name = "29/32")]
            TwentyNineThirtySeconds,
            [Display(Name = "30/32")]
            ThirtyThirtySeconds,
            [Display(Name = "31/32")]
            ThirtyOneThirtySeconds,
            New
        }

        public enum BrakeCondition
        {
            SELECT,
            New,
            [Display(Name = "90%")]
            Ninety,
            [Display(Name = "80%")]
            Eighty,
            [Display(Name = "70%")]
            Seventy,
            [Display(Name = "60%")]
            Sixty,
            [Display(Name = "50%")]
            Fifty,
            [Display(Name = "40%")]
            Forty,
            [Display(Name = "30%")]
            Thirty,
            [Display(Name = "20%")]
            Twenty,
            [Display(Name = "10%")]
            Ten
        }
    }
}
