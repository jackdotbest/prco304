using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Object
{
    public class QuestionnaireResult
    {
        private Organisation org;
        private String twoPointOne, twoPointTwo, threePointOne, threePointFour, fourPointFive, fourPointSix, fivePointFive, 
            sixPointOnePointOne;
        private Boolean twoPointThree, threePointTwo, threePointThree, threePointFive, threePointSix, threePointSeven, 
            fourPointOne, fourPointTwo, fourPointThree, fourPointFour, fivePointOne, fivePointTwo, fivePointThree, fivePointFour, 
            fivePointSix, fivepointSeven, sixPointOne, sixPointOnePointTwo, sixPointOnePointThree, sixPointOnePointFour, sixPointTwo, 
            sixPointTwoPointOne, sixPointTwoPointTwo, sixPointTwoPointThree, sixpointTwoPointFour, sixPointThree, sevenPointOne, 
            sevenPointTwo, sevenPointThree;

        public QuestionnaireResult()
        {

        }

        public QuestionnaireResult(Organisation org, string twoPointOne, string twoPointTwo, string threePointOne, 
            string threePointFour, string fourPointFive, string fourPointSix, string fivePointFive, string sixPointOnePointOne, 
            bool twoPointThree, bool threePointTwo, bool threePointThree, bool threePointFive, bool threePointSix, 
            bool threePointSeven, bool fourPointOne, bool fourPointTwo, bool fourPointThree, bool fourPointFour, 
            bool fivePointOne, bool fivePointTwo, bool fivePointThree, bool fivePointFour, bool fivePointSix, bool fivepointSeven, 
            bool sixPointOne, bool sixPointOnePointTwo, bool sixPointOnePointThree, bool sixPointOnePointFour, bool sixPointTwo, 
            bool sixPointTwoPointOne, bool sixPointTwoPointTwo, bool sixPointTwoPointThree, bool sixpointTwoPointFour, 
            bool sixPointThree, bool sevenPointOne, bool sevenPointTwo, bool sevenPointThree)
        {
            this.Org = org ?? throw new ArgumentNullException(nameof(org));
            this.TwoPointOne = twoPointOne ?? throw new ArgumentNullException(nameof(twoPointOne));
            this.TwoPointTwo = twoPointTwo ?? throw new ArgumentNullException(nameof(twoPointTwo));
            this.ThreePointOne = threePointOne ?? throw new ArgumentNullException(nameof(threePointOne));
            this.ThreePointFour = threePointFour ?? throw new ArgumentNullException(nameof(threePointFour));
            this.FourPointFive = fourPointFive ?? throw new ArgumentNullException(nameof(fourPointFive));
            this.FourPointSix = fourPointSix ?? throw new ArgumentNullException(nameof(fourPointSix));
            this.FivePointFive = fivePointFive ?? throw new ArgumentNullException(nameof(fivePointFive));
            this.SixPointOnePointOne = sixPointOnePointOne ?? throw new ArgumentNullException(nameof(sixPointOnePointOne));
            this.TwoPointThree = twoPointThree;
            this.ThreePointTwo = threePointTwo;
            this.ThreePointThree = threePointThree;
            this.ThreePointFive = threePointFive;
            this.ThreePointSix = threePointSix;
            this.ThreePointSeven = threePointSeven;
            this.FourPointOne = fourPointOne;
            this.FourPointTwo = fourPointTwo;
            this.FourPointThree = fourPointThree;
            this.FourPointFour = fourPointFour;
            this.FivePointOne = fivePointOne;
            this.FivePointTwo = fivePointTwo;
            this.FivePointThree = fivePointThree;
            this.FivePointFour = fivePointFour;
            this.FivePointSix = fivePointSix;
            this.FivepointSeven = fivepointSeven;
            this.SixPointOne = sixPointOne;
            this.SixPointOnePointTwo = sixPointOnePointTwo;
            this.SixPointOnePointThree = sixPointOnePointThree;
            this.SixPointOnePointFour = sixPointOnePointFour;
            this.SixPointTwo = sixPointTwo;
            this.SixPointTwoPointOne = sixPointTwoPointOne;
            this.SixPointTwoPointTwo = sixPointTwoPointTwo;
            this.SixPointTwoPointThree = sixPointTwoPointThree;
            this.SixpointTwoPointFour = sixpointTwoPointFour;
            this.SixPointThree = sixPointThree;
            this.SevenPointOne = sevenPointOne;
            this.SevenPointTwo = sevenPointTwo;
            this.SevenPointThree = sevenPointThree;
        }

        public bool TwoPointThree { get => twoPointThree; set => twoPointThree = value; }
        public bool ThreePointTwo { get => threePointTwo; set => threePointTwo = value; }
        public bool ThreePointThree { get => threePointThree; set => threePointThree = value; }
        public bool ThreePointFive { get => threePointFive; set => threePointFive = value; }
        public bool ThreePointSix { get => threePointSix; set => threePointSix = value; }
        public bool ThreePointSeven { get => threePointSeven; set => threePointSeven = value; }
        public bool FourPointOne { get => fourPointOne; set => fourPointOne = value; }
        public bool FourPointTwo { get => fourPointTwo; set => fourPointTwo = value; }
        public bool FourPointThree { get => fourPointThree; set => fourPointThree = value; }
        public bool FourPointFour { get => fourPointFour; set => fourPointFour = value; }
        public bool FivePointOne { get => fivePointOne; set => fivePointOne = value; }
        public bool FivePointTwo { get => fivePointTwo; set => fivePointTwo = value; }
        public bool FivePointThree { get => fivePointThree; set => fivePointThree = value; }
        public bool FivePointFour { get => fivePointFour; set => fivePointFour = value; }
        public bool FivePointSix { get => fivePointSix; set => fivePointSix = value; }
        public bool FivepointSeven { get => fivepointSeven; set => fivepointSeven = value; }
        public bool SixPointOne { get => sixPointOne; set => sixPointOne = value; }
        public bool SixPointOnePointTwo { get => sixPointOnePointTwo; set => sixPointOnePointTwo = value; }
        public bool SixPointOnePointThree { get => sixPointOnePointThree; set => sixPointOnePointThree = value; }
        public bool SixPointOnePointFour { get => sixPointOnePointFour; set => sixPointOnePointFour = value; }
        public bool SixPointTwo { get => sixPointTwo; set => sixPointTwo = value; }
        public bool SixPointTwoPointOne { get => sixPointTwoPointOne; set => sixPointTwoPointOne = value; }
        public bool SixPointTwoPointTwo { get => sixPointTwoPointTwo; set => sixPointTwoPointTwo = value; }
        public bool SixPointTwoPointThree { get => sixPointTwoPointThree; set => sixPointTwoPointThree = value; }
        public bool SixpointTwoPointFour { get => sixpointTwoPointFour; set => sixpointTwoPointFour = value; }
        public bool SixPointThree { get => sixPointThree; set => sixPointThree = value; }
        public bool SevenPointOne { get => sevenPointOne; set => sevenPointOne = value; }
        public bool SevenPointTwo { get => sevenPointTwo; set => sevenPointTwo = value; }
        public bool SevenPointThree { get => sevenPointThree; set => sevenPointThree = value; }
        public string TwoPointOne { get => twoPointOne; set => twoPointOne = value; }
        public string TwoPointTwo { get => twoPointTwo; set => twoPointTwo = value; }
        public string ThreePointOne { get => threePointOne; set => threePointOne = value; }
        public string ThreePointFour { get => threePointFour; set => threePointFour = value; }
        public string FourPointFive { get => fourPointFive; set => fourPointFive = value; }
        public string FourPointSix { get => fourPointSix; set => fourPointSix = value; }
        public string FivePointFive { get => fivePointFive; set => fivePointFive = value; }
        public string SixPointOnePointOne { get => sixPointOnePointOne; set => sixPointOnePointOne = value; }
        internal Organisation Org { get => org; set => org = value; }
    }
}
