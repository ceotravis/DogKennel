class Kennel {
    List<Dog> Dogs = new List<Dog>();
    List<Dog> CompetingDogs = new List<Dog>(2);
    public string Name { get; }
    public string Owner { get; }

    /// <summary>
    ///  Create a kennel, add all dogs in the constructor.
    /// </summary>
    /// <param name="name">The name of the kennel</param>
    /// <param name="owner">Owner of the kennel</param>
    public Kennel(string name, string owner) {
        Name = name;
        Owner = owner;

        // Add more dogs here.
        Dog Bob = new Dog("Bob", "Old, grumpy and hungry", 62, "boodhound", 0, 1, 2);
        Dogs.Add(Bob);

        Dog Bertha = new Dog("Bertha", "Old, grumpy and hungry", 45, "boodhound", 1, 2, 5);
        Dogs.Add(Bertha);

        Dog Max = new Dog("Max", "Energetic and playful", 75, "Labrador", 1, 2, 3);
        Dogs.Add(Max);

        Dog Bella = new Dog("Bella", "Friendly and loyal", 80, "Golden Retriever", 1, 3, 2);
        Dogs.Add(Bella);

        Dog Rocky = new Dog("Rocky", "Adventurous and strong", 90, "German Shepherd", 0, 3, 4);
        Dogs.Add(Rocky);

        Dog Daisy = new Dog("Daisy", "Sweet and gentle", 65, "Beagle", 1, 1, 1);
        Dogs.Add(Daisy);

        Dog Duke = new Dog("Duke", "Confident and protective", 80, "Rottweiler", 0, 3, 5);
        Dogs.Add(Duke);

        GameplayLoop();

    }

    /// <summary>
    /// Prints out all dogs in a kennel on seperate lines.
    /// </summary>
    private void PrintDogs() {
        Console.WriteLine($"Dogs that live in the {this.Name} kennel");
        for (int i = 0; i < Dogs.Count; i++) {
            Console.WriteLine("*******************************");
            Console.WriteLine($"Name: {Dogs[i].Name}");
            Console.WriteLine($"Gender: {Dogs[i].GetGender()}");
            Console.WriteLine($"Breed: {Dogs[i].Breed}");
            Console.WriteLine($"Chonk: {Dogs[i].Chonk}");
            // Since the description can be null
            if (Dogs[i].Description != null || Dogs[i].Description != "") {
                Console.WriteLine($"Description: {Dogs[i].Description}");
            }
        }
        Console.WriteLine("*******************************");
    }
    /// <summary>
    /// Return the index where the dog resides in the Dogs list.
    /// </summary>
    /// <param name="dogName">The user's inputted name</param>
    /// <param name="Dogs">The list of all the dogs</param>
    /// <returns>The index of dog, or -1 if the dog does not exist.</returns>
    private int GetDogIndexByName(string dogName, List<Dog> Dogs) {
        for (int i = 0; i < Dogs.Count; i++) {
            if (Dogs[i].Name == dogName) {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Add a dog to the CompetingDogs list. The competing number of dogs is currently limited to 2
    /// </summary>
    /// <param name="Message">The message that should be displayed to the user when the dog's name is requested.</param>
    private void SelectDog(string Message) {
        try {
            string selectDog;
            int dogIndex;

            // Infinite loop to reportedly promt the user for input
            while (true) {

                Console.WriteLine(Message);
                // Store the user's input
                selectDog = Console.ReadLine()!;

                // Check if the input is null or is an empty string,
                // if so continue to the next iteration of the loop
                if (selectDog == null || selectDog == "") {
                    continue;
                }

                dogIndex = GetDogIndexByName(selectDog, Dogs);

                if (dogIndex != -1) {
                    for (int i = 0; i < Dogs.Count; i++) {
                        // Check if a dog exist with the name of the user's input
                        if (Dogs[i].Name == selectDog) {
                            // Compare the id of the user's selected dog to the the first dog in the CompetingDogs array
                            // This is so that you cannot add the same dog twice.
                            if (CompetingDogs.Count == 0) {
                                CompetingDogs.Add(Dogs[i]);
                                return;
                            } else if (Dogs[dogIndex].ID != CompetingDogs.First().ID) {
                                CompetingDogs.Add(Dogs[i]);
                                return;
                                // If this check fails throw an error to the user and let the user start from the begining
                            } else {
                                Console.WriteLine("A dog cannot compete against itself");
                                Thread.Sleep(700);
                                Console.Clear();
                                continue;
                            }

                        }
                    }
                } else {
                    Console.WriteLine("A dog with that name does not live in this kennel. Did you type the name right?");
                    Thread.Sleep(700);
                    continue;
                }
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Simulates a race between two dogs, evaluating their performance based on factors such as stamina, chonkiness, size, and gender-related traits.
    /// The winner is determined through a point system, with each factor contributing to the points. Randomness is introduced in tie-breaking scenarios.
    /// </summary>
    private void Race() {
        Dog competingDog1;
        Dog competingDog2;

        // The dog that is currently winning. Is used in the competing algorithm.
        int potentialWinner;
        int winningDog;

        int competingDog1Points = 0;
        int competingDog2Points = 0;

        // Easier to write these variables instead of the index of competingdogs
        competingDog1 = CompetingDogs[0];
        competingDog2 = CompetingDogs[1];

        Console.Clear();

        Console.WriteLine($"{competingDog1.Name} vs {competingDog2.Name}");

        // For a more dramatic effect
        Thread.Sleep(500);

        // Dog competition simulation code to determine the winner based on stamina, chonkiness, size, and gender-related factors.
        // Uses a random number generator for tie-breaking scenarios.
        Random random = new Random();

        int randomInt;
        
        // The dog with more stamina will be the potential winner.
        if (competingDog1.Stamina > competingDog2.Stamina) {
            competingDog1Points += 20; 
        } else if (competingDog2.Stamina > competingDog1.Stamina) {
            competingDog2Points += 20;
        } else {
            // Winning by random gives half the points compared to winning without luck.
            potentialWinner = random.Next(1, 3);
            if (potentialWinner == 1) {
                competingDog1Points += 10;
            } else {
                competingDog2Points += 10;
            }
        }

        // The dog that is less chonky will get 40 points. If both are equally chonky one will by random and get 20 points
        if (competingDog1.Chonk < competingDog2.Chonk) {
            competingDog1Points += 40;
        } else if (competingDog2.Chonk < competingDog1.Chonk) {
            potentialWinner = 2;
            competingDog2Points += 40;
        } else {
            potentialWinner = random.Next(1, 3);
            if (potentialWinner == 1) {
                competingDog1Points += 20;
            } else {
                competingDog2Points += 20;
            }
        }

        // The dog with the smallest size will get 10 points, if both dogs have the same size randomness will be introduced
        // and the winning dog will get 5 points
        if (competingDog1.Size > competingDog2.Size) {
            potentialWinner = 1;
            competingDog2Points += 10;
        } else if (competingDog2.Size > competingDog1.Size){
            competingDog1Points += 10;
        } else {
            potentialWinner = random.Next(1, 3);
            if (potentialWinner == 1) {
                competingDog1Points += 5;
            } else {
                competingDog2Points += 5;
            }
        }

        // Introduce randomness based on both dog's genders
        if (competingDog1.Gender == 1 && competingDog2.Gender == 0) {
            // If competingDog1 is male and competingDog2 is female
            randomInt = random.Next(1, 45);

            // Apply points to competingDog2 based on random condition
            if (randomInt % 2 == 0) {
                competingDog2Points += 10;
            }
        } else if (competingDog1.Gender == 0 && competingDog2.Gender == 1) {
            // If competingDog1 is female and competingDog2 is male
            randomInt = random.Next(1, 45);

            // Apply points to competingDog1 based on random condition
            if (randomInt % 2 != 0) {
                competingDog1Points += 10;
            }
        } else {
            // If dogs have the same gender or if gender information is not available
            potentialWinner = random.Next(1, 3);

            // Randomly assign points to one of the dogs
            if (potentialWinner == 1) {
                competingDog1Points += 5;
            } else {
                competingDog2Points += 5;
            }
        }


        if (competingDog1Points > competingDog2Points) {
            winningDog = 1;
        } else {
            winningDog = 2;
        }

        Console.WriteLine($"{CompetingDogs[winningDog-1].Name} wins!");
    }

    /// <summary>
    /// Gameplay loop. Handles dog selection and if the user wants to play again.
    /// </summary>
    private void GameplayLoop() {
        while (true) {
            PrintDogs();

            SelectDog("Enter the name of the dog that should partake in a running race. (Input is case sensitive)");
            SelectDog("Enter the name of the second dog that should partake in the running race. (Input is case sensitive");

            // Simulate a race between the two selected dogs.
            Race();

            while (true) {
                Console.WriteLine("Do you want to play again? (yes/no)");
                string Input = Console.ReadLine()!.ToLower();

                // Prompt the user for another round
                if (Input == "yes") {
                    // Start a new race
                    break;
                } else if (Input == "no") {
                    // Exit the programs
                    Environment.Exit(0);
                } else {
                    // Handle invalid input 
                    Console.WriteLine("Parse error, please enter yes or no");
                    continue;
                }
            }
        }
    }
}