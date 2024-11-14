using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculateGame2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int correct_answer;
            int total_score = 0;
            int factor1; //random number of the first factor
            int factor2; //random number of the second factor
            int playerAnswer;

            // -- Intro -- 
            ChangeColor("Yellow");
            Console.WriteLine("Welcome to the Math game!");
            ChangeColor("Red");
            Console.WriteLine("-------------------------");
            ChangeColor(default);

            // -- player name info --
            Console.WriteLine("Type your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Player Name : ");
            ChangeColor("Cyan");
            Console.WriteLine(name);
            ChangeColor(default);
            Console.WriteLine();

            // -- Game mode/difficulty selection --
            Console.WriteLine("----Choose the Difficulty----");
            Console.WriteLine();
            Console.WriteLine("Type game Mode/Difficult: '1' for EASY or '2' for HARD mode");
            int gameMode = Convert.ToInt32(Console.ReadLine());
            switch (gameMode){
                case 1:
                    ChangeColor("Green");
                    Console.WriteLine("---- Easy mode selected! ----");
                    break;

                case 2:
                    ChangeColor("Red");
                    Console.WriteLine("---- Hard mode selected!!! ----");
                    break;

                default:
                    ChangeColor("Green");
                    Console.WriteLine("---- Easy mode (Default) ----");
                    break;
            }
            ChangeColor(default);
            Console.WriteLine();

            // -- Player choose the Operator --
            Console.WriteLine("---- Should the operator (type the Number) ----");
            Console.WriteLine("'1' = (Plus +), '2' = (Minus -), '3' = (Mutiply *)");
            int selectedOperator = Convert.ToInt32(Console.ReadLine());
            string operatorSelectString = ""; //Convert to string variable type
            ChangeColor("Yellow");
            switch (selectedOperator){
                case 1:
                    Console.WriteLine("---- Addition Game Mode (+) ----");
                    operatorSelectString = "+";
                    break;

                case 2:
                    Console.WriteLine("---- Subtraction Game Mode (-) ----");
                    operatorSelectString = "-";
                    break;

                case 3:
                    Console.WriteLine("---- Mutiplication Game Mode (*) ----");
                    operatorSelectString = "*";
                    break;

                //case 4:
                //    Console.WriteLine("---- Division Game Mode (/) ----");
                //    operatorSelectString = "/";
                //    break;

                default:
                    Console.WriteLine("---- Addition Game Mode (+) ----");
                    operatorSelectString = "+";
                    break;
            }

            // --- Main code after all have selected ---
            Calculation();

            // --- Score Result ---
            Console.WriteLine();
            ChangeColor("Cyan");
            Console.WriteLine("Player name: " + name);
            Console.WriteLine("GET TOTAL SCORE OF: " + total_score);

            // [ALL Function]
            // Execute all the quiz code with Easy mode selected
            void Calculation()
            {
                for (int i = 0; i < 5; i++)
                {
                    ChangeColor("Yellow");
                    if (gameMode == 2){
                        RandomNumberHardMode();
                    }
                    else{
                        RandomNumberEasyMode();
                    }

                    switch (selectedOperator)
                    {
                        case 1:
                            correct_answer = factor1 + factor2;
                            break;
                        case 2:
                            correct_answer = factor1 - factor2;
                            break;
                        case 3:
                            correct_answer = factor1 * factor2;
                            break;
                        //case 4:
                        //    correct_answer = factor1 / factor2;
                        //    break;
                        default:
                            Console.WriteLine("//Invalid operator. Defaulting to Addition.//");
                            correct_answer = factor1 + factor2;
                            break;
                    }

                    ChangeColor("default");
                    playerAnswer = Convert.ToInt32(Console.ReadLine()); // Get Player answer

                    if (playerAnswer == correct_answer)
                    {
                        PlayerCorrect();
                    }
                    else if (playerAnswer != correct_answer)
                    {
                        PlayerGetWrongAnswer();
                    }
                }
            }

            // Player got the correct answer, +1 point to the total score
            void PlayerCorrect() 
            {
                ChangeColor("Green");
                Console.WriteLine("Correct!!");
                Console.WriteLine(); //Space
                ChangeColor("default");
                total_score++;
            }

            // Player got wrong answer, no point
            void PlayerGetWrongAnswer()
            {
                ChangeColor("Red");
                Console.WriteLine("Wrong! the correct answer is -> " + correct_answer);
                Console.WriteLine(); //Space
                ChangeColor("default");
            }

            // Random number for easy mode >100
            void RandomNumberEasyMode()
            {
                Random rnd = new Random();
                factor1 = rnd.Next(1, 99);
                factor2 = rnd.Next(1, 99);
                Console.WriteLine(factor1 + " " + operatorSelectString + " " + factor2);
            }

            // Random number for hard mode >1000
            void RandomNumberHardMode()
            {
                Random rnd = new Random();
                factor1 = rnd.Next(1, 999);
                factor2 = rnd.Next(1, 999);
                Console.WriteLine(factor1 + " " + operatorSelectString + " " + factor2);
            }

            // Change color for aesthetics
            void ChangeColor(string color){
                switch (color)
                {
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "Red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            Console.ReadKey();
        } 
    }
}

