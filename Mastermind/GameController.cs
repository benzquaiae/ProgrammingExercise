using System.Text;

namespace Mastermind {
    public class GameController {

        //default constructor
        public GameController() {

            randNumGenerator = new Random();
            randNumMatched = false;
            hintMessage = string.Empty;
            randNumLength = 4;
            minDigit = 1;
            maxDigit = 6;
            randNum = string.Empty;
        }

        //constructor to customize random number length
        public GameController(int numLength) {

            randNumGenerator = new Random();
            randNumMatched = false;
            hintMessage = string.Empty;
            randNumLength = numLength;
            minDigit = 1;
            maxDigit = 6;
            randNum = string.Empty;
        }
        
        //TODO: add more contructors to allow control over digit range
        
        public string RandomNumber {
            get => randNum;
        }

        public bool Matched {
            get => randNumMatched;
        }

        public string Hint {
            get => hintMessage;
        }

        public string DigitRange{
            get => minDigit.ToString() + " and " + maxDigit.ToString();
        }

        public void generateRandNum () {

            for(int i=0; i<randNumLength; i++){
                randNum += Convert.ToString(randNumGenerator.Next(minDigit,maxDigit+1));
            }
        }

        public void compareInput(string inputNum) {

            //if the numbers are equal, exhaustive check unnecessary...
            if (randNum == inputNum) {
                randNumMatched = true;
                return;
            } else
            {   
                string pluses = string.Empty;
                string minuses = string.Empty;
                char element;
                StringBuilder randNumDummy = new StringBuilder(randNum);
                List<int> positionsMatched = new List<int>();

                //check for correct numbers in correct place (+)...
                for(int i=0; i<randNumLength; i++){

                    if (randNum.ElementAt(i) == inputNum.ElementAt(i)){
                        positionsMatched.Add(i);
                        randNumDummy[i] = ' ';
                        pluses += '+';
                    }
                }

                //check for correct numbers in the wrong place (-)...
                //checked separately to account for duplicate numbers and allow matched
                //numbers to have precedence...
                for(int i=0; i<randNumLength; i++){
                    
                    if (positionsMatched.Contains(i)){continue;}

                    element = inputNum.ElementAt(i);

                    if (randNumDummy.ToString().Contains(element)){

                        randNumDummy[randNumDummy.ToString().IndexOf(element)] = ' ';
                        minuses += "-";
                    }
                }

                //assemble hint
                hintMessage = pluses + minuses;
            }
        }

        private Random randNumGenerator;
        private string randNum;
        private int randNumLength;
        private bool randNumMatched;
        private string hintMessage;
        private int minDigit;
        private int maxDigit;
    }
}