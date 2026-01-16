namespace High_or_Low
{
    internal class Program
    {
        enum Guess
        {
            higher,
            lower,
            correct,
            invalid,
        }


        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            Console.WriteLine("Welcome to High or Low.");
            Console.WriteLine("In this game a random number between 1 and 100 will be generated.\n" +
                "Your goal is to guess the number.\n" +
                "You will be told if you guessed higher or lower than the answer.\n" +
                "Your total guesses will be tracked and displayed when you get the right number.");
            Console.ReadLine();
            Console.WriteLine("Lets get started!");
            Console.ReadLine();
            Console.Clear();
            Guess highOrLow = Guess.invalid;
            bool isPlaying = true;
            bool replaying = true;
            int attempts = 0;
            int guessedNumber = 0;
            while (replaying)
            {
                while (isPlaying == true)
                {
                    Console.WriteLine("Guess a number between 1 and 100.");
                    try
                    {
                        string guessedNumberStr = Console.ReadLine();
                        guessedNumber = Convert.ToInt32(guessedNumberStr);
                    }
                    catch
                    {
                        highOrLow = Guess.invalid;
                    }

                    if (guessedNumber == randomNumber)
                    {
                        highOrLow = Guess.correct;
                    }
                    else if (guessedNumber < 1 || guessedNumber > 100)
                    {
                        highOrLow = Guess.invalid;
                    }
                    else if (guessedNumber > randomNumber)
                    {
                        highOrLow = Guess.higher;
                    }
                    else if (guessedNumber < randomNumber)
                    {
                        highOrLow = Guess.lower;
                    }

                    switch (highOrLow)
                    {
                        case Guess.correct:
                            Console.WriteLine("You Got It!");
                            attempts++;
                            isPlaying = false;
                            break;
                        case Guess.lower:
                            Console.WriteLine("Lower than the number.");
                            attempts++;
                            isPlaying = true;
                            break;
                        case Guess.higher:
                            Console.WriteLine("Higher than the number.");
                            attempts++;
                            isPlaying = true;
                            break;
                        default:
                            Console.WriteLine("Your guess was invalid. Please try again.");
                            isPlaying = true;
                            break;
                    }
                }

                Console.WriteLine("Press Enter to see your attempts.");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"Attempts: {attempts}");

                Console.WriteLine("Type 'Y' if you would like to play again, or anything else if not");
                string playingAgain = Console.ReadLine();

                if (playingAgain == "Y" || playingAgain == "y")
                {
                    replaying = true;
                    isPlaying = true;
                    attempts = 0;
                }
                else
                {
                    replaying = false;
                }
                Console.Clear();
            }
        }
    }
}
