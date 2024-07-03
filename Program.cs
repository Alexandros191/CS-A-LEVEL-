    string[] colours = { "R", "B", "Y", "G" };
        Random rand = new Random();

        // Generate a random combination of 4 colours
        string[] combination = new string[4];
        for (int i = 0; i < 4; i++)
        {
            int index = rand.Next(0, colours.Length);
            combination[i] = colours[index]; // Store the random colour in the combination array
        }

    
        //Console.WriteLine("Generated combination:"); //Randomly generated combination 
        //Console.WriteLine(string.Join(" ", combination));
 Console.WriteLine("MASTERMIND");
 Console.WriteLine();
        Console.WriteLine("COLOURS: RED (R), BLUE (B), YELLOW (Y), GREEN (G)");
        Console.WriteLine();

        // Number of attempts
        int maxAttempts = 12;
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            attempts++;

            //  Enter their combination guess without spaces
            Console.WriteLine($"ATTEMPT {attempts}/{maxAttempts}: ENTER COMBINATION GUESS (E.G., RBYG):");
            string guess = Console.ReadLine()?.ToUpper(); // Ensure guess is not null and convert to uppercase

            // Check if the guess matches the combination
            int correctPlaceAndColorCount = 0;
            int correctColorCount = 0;

            // Arrays to track which colors have been counted already
            bool[] combinationUsed = new bool[4];
            bool[] guessUsed = new bool[4];

            // Check correct color and position
            for (int i = 0; i < 4; i++)
            {
                if (guess != null && combination != null && i < guess.Length && i < combination.Length)
                {
                    if (guess[i] == combination[i][0]) // Compare characters directly
                    {
                        correctPlaceAndColorCount++;
                        combinationUsed[i] = true;
                        guessUsed[i] = true;
                    }
                }
            }

            // Step 4: Check correct color but wrong position
            for (int i = 0; i < 4; i++)
            {
                if (guess != null && combination != null && i < guess.Length && i < combination.Length && !combinationUsed[i])
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (!guessUsed[i] && guess[i] == combination[j][0] && !combinationUsed[j])
                        {
                            correctColorCount++;
                            combinationUsed[j] = true;
                            guessUsed[i] = true;
                            break;
                        }
                    }
                }
            }

            
            Console.WriteLine($"CORRECT COLOUR AND PLACE: {correctPlaceAndColorCount}");
            Console.WriteLine($"CORRECT COLOUR BUT WRONG PLACE: {correctColorCount}");

            //  Check if the guess is correct
            if (correctPlaceAndColorCount == 4)
            {
                Console.WriteLine("COMBINATION GUESSED CORRECTLY");
                break;
            }

            Console.WriteLine(); // Add a blank line for readability
        }

        // If the loop finishes without breaking, the user did not guess correctly within max attempts (12)
        if (attempts == maxAttempts)
        {
            Console.WriteLine($"YOU DID NOT GUESS THE COMBINATION IN  {maxAttempts} ATTEMPTS.");
            Console.WriteLine($"THE CORRECT COMBINATION WAS{string.Join(" ", combination)}");
        }

        Console.WriteLine("PRESS ANY KEY TO EXIT");
        Console.ReadKey();