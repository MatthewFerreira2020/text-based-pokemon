using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game101_Lab5_Kashi
{
    class Program
    {

        /* @Authors: Matthew Ferreira n01155990, Basil Noubani N00375834, Kashi n01123649
        */
        static void Main(string[] args)
        {

            Player[] trainers = new Player[5]; // creating array of trainers and putting in trainers
            trainers[0] = new Player("Ash", "10", "Pallet Town");
            trainers[1] = new Player("Brock", "15", "Pewter City");
            trainers[2] = new Player("Misty", "10", "Cerulean City");
            trainers[3] = new Player("May", "10", "Petalburg City");
            trainers[4] = new Player("Sabrina", "21", "Saffron City");

            Pokemon[] pokeArray = new Pokemon[5]; //creating array of pokemon and filling the array with pokemon
            Groudon groudon = new Groudon();
            pokeArray[0] = groudon;

            Moltres moltres = new Moltres();
            pokeArray[1] = moltres;

            Zapdos zapdos = new Zapdos();
            pokeArray[2] = zapdos;

            Articuno articuno = new Articuno();
            pokeArray[3] = articuno;

            Kyogre kyogre = new Kyogre();
            pokeArray[4] = kyogre;

            Player yourPlayer = new Player();



            Random rnd = new Random(); // generating levels for trainer pokemon
            for (int i = 0; i < 5; i++)
            {
                int randomLevel = rnd.Next(1, 1000);
                if (i == 0)
                {

                    pokeArray[0].setLevel(randomLevel);
                    pokeArray[0].setEXP(randomLevel);
                }

                if (i == 1)
                {

                    pokeArray[1].setLevel(randomLevel);
                    pokeArray[1].setEXP(randomLevel);
                }

                if (i == 2)
                {

                    pokeArray[2].setLevel(randomLevel);
                    pokeArray[2].setEXP(randomLevel);
                }

                if (i == 3)
                {

                    pokeArray[3].setLevel(randomLevel);
                    pokeArray[3].setEXP(randomLevel);
                }

                if (i == 4)
                {

                    pokeArray[4].setLevel(randomLevel);
                    pokeArray[4].setEXP(randomLevel);
                }
            }

            for (int i = 0; i <= trainers.Length-1; i++)
            {
                int trainerNumPokemon = rnd.Next(1, 6);
                for (int j = 1; j <= trainerNumPokemon; j++)
                {
                    int trainerPokemon = rnd.Next(0, 4);
                    trainers[i].setPokemon(pokeArray, trainerPokemon);
                    trainers[i].setNumberOfPokemon(j);
                }
            }

            bool running = true;
            
                Console.WriteLine("What is your name?");
                string name = Console.ReadLine();
                yourPlayer.setName(name);
                Console.WriteLine("Hello, {0}, how old are you?", yourPlayer.getName());
                string age = Console.ReadLine();
                yourPlayer.setAge(age);
                Console.WriteLine("Awesome! And what city are you from, {0}?", yourPlayer.getName());
                string city = Console.ReadLine();
                yourPlayer.setCity(city);
                Console.WriteLine("\nWelcome to the world of Pokemon, {0}!\n", yourPlayer.getName());
            do
            {
                Console.WriteLine("What would like to do?\n1. battle a trainer\n2. battle wild pokemon\n3. go to pokecenter\n4. go to Pokeball Boutique");
                int pSelection = Convert.ToInt32(Console.ReadLine());

                switch (pSelection) 
                {
                    case 1: Console.WriteLine("\nYou encountered a trainer.\n"); // trainer battle
                        Console.WriteLine();
                        int rndTrainer = rnd.Next(0, 4);
                        yourPlayer.battle(trainers[rndTrainer]);
                        pokecenter(yourPlayer);                                 // allows user to go the pokecenter after battle
                        break;

                    case 2: Console.WriteLine("\nYou encountered a wild Pokemon.\n"); // wild pokemon battle
                        int rndpokemon = rnd.Next(0, 4);                              // generating random pokemon for encounters
                        int randomLevel = rnd.Next(1, 1000);                            // generating random levels for wild pokemon
                        switch (rndpokemon)
                        {
                            case 0:
                                pokeArray[rndpokemon] = new Kyogre();
                                pokeArray[rndpokemon].setLevel(randomLevel);
                                pokeArray[rndpokemon].setEXP(randomLevel);
                                break;
                            case 1:
                                pokeArray[rndpokemon] = new Articuno();
                                pokeArray[rndpokemon].setLevel(randomLevel);
                                pokeArray[rndpokemon].setEXP(randomLevel);
                                break;
                            case 2:
                                pokeArray[rndpokemon] = new Zapdos();
                                pokeArray[rndpokemon].setLevel(randomLevel);
                                pokeArray[rndpokemon].setEXP(randomLevel);
                                break;
                            case 3:
                                pokeArray[rndpokemon] = new Groudon();
                                pokeArray[rndpokemon].setLevel(randomLevel);
                                pokeArray[rndpokemon].setEXP(randomLevel);
                                break;
                            case 4:
                                pokeArray[rndpokemon] = new Moltres();
                                pokeArray[rndpokemon].setLevel(randomLevel);
                                pokeArray[rndpokemon].setEXP(randomLevel);
                                break;
                            default:
                                break;
                        }

                        yourPlayer.battle(pokeArray, rndpokemon);
                        pokecenter(yourPlayer);                                     // allows user to go to pokecenter after battle
                        break;

                    case 3:
                        pokecenter(yourPlayer);
                        break;

                    case 4:
                        pokeballBoutique(yourPlayer);
                        break;
                    default: break;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nWould you like to continue?");                 //allows player to quit game
                string playAgain = Console.ReadLine().ToLower();

                if (playAgain == "no")
                {
                    Pokemon[] finalPokemon = yourPlayer.getPokemonList();           // displays final player stats
                    int finalNumberOfPokemon = yourPlayer.getNumberOfPokemon();
                    int count = 0;
                    Console.WriteLine("{0}, you ended up with:\n{1} PokeBalls\n{2} dollars\n\nList of Pokemon captured:", yourPlayer.getName(), yourPlayer.getNumberOfPokeballs(), yourPlayer.getMoney());
                    while (count < finalNumberOfPokemon)
                    {
                        Console.WriteLine("Your {0} was level {1} and had {2} HP!", finalPokemon[count].getName(), finalPokemon[count].getLevel(), finalPokemon[count].getHP());
                        count++;
                    }
                    Console.ReadKey();
                    running = false;
                }
            } while (running == true);



        }

        static public void pokecenter(Player user)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0}, would you like to head to the Poke Center to heal your Pokemon?", user.getName()); // allows user to choose to not go to pokecenter
            string userAnswer = Console.ReadLine().ToLower();

            if (userAnswer == "yes")
            {
                Pokemon[] healingPokemon = user.getPokemonList();
                int numPokemon = user.getNumberOfPokemon();
                int i = 0;
                    while (i < numPokemon) // goes through every pokemon the player has and restores their HP
                    {
                        string currentPokemon = healingPokemon[i].getName();
                        switch (currentPokemon)
                        {
                            case "Moltres":
                                healingPokemon[i].setHP(90);
                            Console.WriteLine("Your {0} is healed", healingPokemon[i].getName());
                            break;
                            case "Groudon":
                                healingPokemon[i].setHP(100);
                            Console.WriteLine("Your {0} is healed", healingPokemon[i].getName());
                            break;
                            case "Zapdos":
                                healingPokemon[i].setHP(90);
                            Console.WriteLine("Your {0} is healed", healingPokemon[i].getName());
                            break;
                            case "Articuno":
                                healingPokemon[i].setHP(90);
                            Console.WriteLine("Your {0} is healed", healingPokemon[i].getName());
                            break;
                            case "Kyogre":
                                healingPokemon[i].setHP(100);
                            Console.WriteLine("Your {0} is healed", healingPokemon[i].getName());
                            break;
                            
                            default:
                                break;
                        }
                    i++;
                    }
                Console.WriteLine("All pokemon have been healed");
                
            }
        }


        static public void pokeballBoutique(Player user)
        {
            Console.WriteLine("{0}, welcome to the Pokeball Boutique!", user.getName());
            bool buying = true;
            do
            {
                Console.WriteLine("You currently have ${0}", user.getMoney());
                Console.WriteLine("Pokeballs cost $100, how many pokeballs would you like to buy?");
                int buyPokeballs = Convert.ToInt32(Console.ReadLine());
                int cost = buyPokeballs * 100;
                if (cost <= user.getMoney()) 
                {
                    buyPokeballs = buyPokeballs + user.getNumberOfPokeballs();
                    user.setNumberOfPokeballs(buyPokeballs);
                    int currentMoney = user.getMoney() - cost;
                    user.setMoney(currentMoney);
                    Console.WriteLine("Do you want to buy more pokeballs?");
                    string continueBuying = Console.ReadLine().ToLower();
                    if (continueBuying == "yes")
                    {
                        buying = true;
                    }
                    else
                    {
                        buying = false;
                    }
                }
                else
                {
                    Console.WriteLine("You don't have enough money to buy that many pokeballs");
                    Console.WriteLine("Do you want to buy more pokeballs?");
                    string continueBuying = Console.ReadLine().ToLower();
                    if (continueBuying == "yes")
                    {
                        buying = true;
                    }
                    else
                    {
                        buying = false;
                    }
                }
            } while (buying == true);
        }




    }
}
