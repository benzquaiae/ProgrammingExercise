namespace Mastermind {
    internal class RunGame {
        private static void Main(string[] args) {
            
            string? playerNum = string.Empty;
            int maxAttempts = 10;
            int attempts = 1; 
            GameController gc = new GameController();

            gc.generateRandNum();

            Console.WriteLine("\nWelcome to Mastermind!");
            Console.WriteLine("\nA " + gc.RandomNumber.Length + " digit number has been generated for you to guess.\n" +
            "Each digit of the number is between " + gc.DigitRange + " (inclusively).\n" +
            "You have " + maxAttempts + " attempts to correctly guess the number.\n" +
            "\n+ = the number of correct digits in the correct position" + 
            "\n- = the number of correct digits in the wrong position" +
            "\n\nGood luck!");

            do {

                Console.WriteLine("\nAttempt " + attempts + ": ");

                playerNum = Console.ReadLine();
                playerNum = playerNum is null ? "0" : playerNum;

                try {

                    Convert.ToInt32(playerNum);

                    //error handling for +/- numbers that convert successfully but wrong format...
                    if(playerNum.Contains("-") || playerNum.Contains("+")) {playerNum = "0";}

                    // Not processing numbers less than or greater than the set number of digits...
                    if (playerNum != "0" && ((playerNum.Length < gc.RandomNumber.Length) || (playerNum.Length > gc.RandomNumber.Length))){
                        playerNum = "0";
                    }

                } catch (FormatException e){ playerNum = "0"; } //error handling for string input
                catch (OverflowException e){ playerNum = "0"; } //error handling for numbers too large/small

                if (playerNum != "0"){
                    gc.compareInput(playerNum);

                    if (!gc.Matched)
                    {Console.WriteLine(gc.Hint);}
                }

                attempts ++;

            } while (gc.Matched == false && attempts <= maxAttempts);

            if (gc.Matched)
            {
                Console.WriteLine("\nYou got it!");
            }
            else
            {
                Console.WriteLine("\nBetter luck next time!\nThe number was: " + gc.RandomNumber);
            }

            Console.WriteLine("\nThanks for playing!");
        }
    }
}