using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageProject
{
    class GarageApplication
    {
        GarageHandler theHandler;
        Dictionary<string, Type> typeDictionary;

        public GarageApplication ()
        {
            theHandler = new GarageHandler();
            typeDictionary = new Dictionary<string, Type>();

            typeDictionary.Add("CAR", typeof( Car));
            typeDictionary.Add("BUS", typeof(Bus));
            typeDictionary.Add("BOAT", typeof(Boat));
            typeDictionary.Add("AIRPLANE", typeof(Airplane));
            typeDictionary.Add("AEROPLANE", typeof(Airplane));
            typeDictionary.Add("PLANE", typeof(Airplane));
            typeDictionary.Add("MOTORCYCLE", typeof(Motorcycle));
            typeDictionary.Add("MC", typeof(Motorcycle));
        }

        public void Run()
        {
            Console.WriteLine("This is the GARAGE application");
            Console.WriteLine("What do you want to do");
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number "
                            + "\n(1, 2, 3 , 4, 5, 6, 7, 8, 9 or 0) of your choice"
                            + "\n1. Build the garage."
                            + "\n2. List the vehicles in the garage."
                            + "\n3. Park a vehicle in the garage."
                            + "\n4. Remove a vehicle from the garage."
                            + "\n5. Store the garage on disk."
                            + "\n6. Show a vehicle."
                            + "\n7. Search for features."
                            + "\n8. List vehicle types."
                            + "\n9 or nothing. Close the program down."
                            + "\n0. Fantasy population of garage."
                            );

                var inString = Console.ReadLine();
                if (inString.Length == 0)
                {
                    Console.WriteLine("Thank You and Goodbye!");
                    break;
                }

                switch (inString[0])
                {
                    case '1':
                        BuildGarage();
                        break;
                    case '2':
                        ListVehicles();
                        break;
                    case '3':
                        ParkVehicle();
                        break;
                    case '4':
                        RemoveVehicle();
                        break;
                    case '5':
                        PermanentBackup();
                        break;
                    case '6':
                        ShowVehicleData();
                        break;
                    case '7': FindVehiclesWithProperties(); 
                        break;
                    case '8': ListVehicleTypes();
                        break; 
                    case '9':
                        Console.WriteLine("Thank You and Goodbye!");
                        break;
                    case '0': FantasyPopulation(); 
                        break;
                    default:
                        break;
                }
                if (inString[0] == '9') break;
            }
        }

        private bool InitializedP()
        {
            if (!theHandler.Initialized())
            {
                Console.WriteLine("The garage must be built before it can be used\n");
                return false;
            }
            return true; 
        }

        private void ShowVehicleData()
        {
            if (!InitializedP()) return; 
            Console.WriteLine("What is the vehicle's license number?");
            string license = Console.ReadLine().ToUpper(); 
            var vehicl = theHandler.FindVehicle(license);
            if (vehicl==null)
            {
                Console.WriteLine("The vehicle could not be found.");
                return; 
            }
            Console.WriteLine($"Data for vehicle {license}:");
            Console.WriteLine($"Color: {vehicl.Color}\nNumber of wheels: {vehicl.Wheels}\n");
        }

        private void PermanentBackup()
        {
            if (!InitializedP()) return;
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            if (!InitializedP()) return;
            Console.WriteLine("Which vehicle do you want to remove (license)?");
            string inString = Console.ReadLine().ToUpper();
            if (theHandler.RemoveVehicle(inString)) Console.WriteLine($"Vehicle {inString} was successfully removed.\n");
            else Console.WriteLine($"Vehicle {inString} could not be found in the garage.\n" );
        }

        private void ParkVehicle()
        {
            string inString;
            Vehicle localVehicle;
            bool yesOrNo; 

            bool askYesNo(string question, out bool answer)
            {
                Console.WriteLine(question);
                string locStr = Console.ReadLine().ToLower();
                if (locStr == "y" || locStr == "yes")
                {
                    answer = true;
                    return true;
                }
                else if (locStr == "n" || locStr == "no")
                {
                    answer = false;
                    return true;
                }
                else
                {
                    Console.WriteLine("Could not interpret the answer as yes or no.\n");
                    answer = false; // Dummy value
                    return false;
                }
            }

            if (!InitializedP()) return;
            if (theHandler.Full())
            {
                Console.WriteLine("The garage is full. No more vehicle can be parked.\n");
                return;
            }
            Console.WriteLine("What does the license plate say?");
            string license = Console.ReadLine().ToUpper();
            if( theHandler.FindVehicle(license)!=null )
            {
                Console.WriteLine("This vehicle is already parked. It cannot be parked again");
                return; 
            }
            Console.WriteLine("What color is the vehicle?");
            string color = Console.ReadLine();
            Console.WriteLine("How many wheels does the vehicle have?");
            inString = Console.ReadLine();
            if (!int.TryParse(inString, out int wheels))
            {
                Console.WriteLine("The input text for number of wheel cannot be interpreted as a number.");
                Console.WriteLine("The vehicle cannot be parked.");
                return;
            }
            if (wheels<0)
            {
                Console.WriteLine("The program cannot accept a negative number of wheels");
                return; 
            }
            Console.WriteLine("What kind of vehicle is being parked?"
                        + "\nAeroplane, Bus, Boat, Car or MC?");
            inString = Console.ReadLine().ToLower();
            if (inString == "aeroplane" || inString == "airplane" || inString == "plane")
            {
                if (!askYesNo("Does the plane have jet engines?", out yesOrNo)) return;
                localVehicle = new Airplane(license, color, wheels, yesOrNo);
            }
            else if (inString == "mc" || inString == "motorcycle")
            {
                if (!askYesNo("Does the bike have a side car?", out yesOrNo)) return;
                localVehicle = new Motorcycle(license, color, wheels, yesOrNo);
            }
            else if (inString == "bus" )
            {
                if (!askYesNo("Does the bus have a middle bend?", out yesOrNo)) return;
                localVehicle = new Bus(license, color, wheels, yesOrNo);
            }
            else if (inString == "boat")
            {
                if (!askYesNo("Does the boat have sails?", out yesOrNo)) return;
                localVehicle = new Boat(license, color, wheels, yesOrNo);
            }
            else if (inString == "car")
            {
                Console.WriteLine("What is the number of seats?");
                inString = Console.ReadLine();
                if (!int.TryParse(inString, out int seats))
                {
                    Console.WriteLine("The input for number of seats cannot be interpreted as a nnumber.");
                    Console.WriteLine("The vehicle cannot be parked.\n");
                    return;
                }
                localVehicle = new Car(license, color, wheels, seats);
            }
            else
            {
                Console.WriteLine("Something went wrong when parking.");
                return;
            }
            theHandler.AddVehicle(localVehicle);
            Console.WriteLine($"Parking vehicle {localVehicle.License}.\n");
        }

        private void ListVehicles()
        {
            if (!InitializedP()) return;
            IEnumerable<Vehicle> localGarage = theHandler.ListVehicles();
            if (localGarage.Count() == 0) Console.WriteLine("The garage is empty.");
            else
            {
                Console.WriteLine("Listing all the vehicles in the garage.");
                foreach (Vehicle vehicl in localGarage)
                {
                    Console.WriteLine(vehicl.License);
                }
            }
            Console.WriteLine();
        }

        private void BuildGarage()
        {
            Console.WriteLine("How many vehicles can the garage take?");
            var inString = Console.ReadLine();
            int capacity;
            if (int.TryParse(inString, out capacity))
            {
                if (capacity > 1000000)
                {
                    Console.WriteLine("The garage cannot be bigger than one million vehicles.\n");
                }
                else if (capacity < 1)
                {
                    Console.WriteLine("The garage must be able to hold at least one vehicle.\n");
                }
                else
                {
                    theHandler.CreateGarage(capacity);
                    Console.WriteLine($"Building garage with {capacity} slots.\n");
                }
            }
            else Console.WriteLine("The input text could not be interpreted as an integer.\n");
        }

        private void FindVehiclesWithProperties()
        {
            if (!InitializedP()) return;
            Console.WriteLine("For each line, specify value of named vehicle property.");
            Console.WriteLine("Empty line (Return) is interpreted as accepting any value.");
            Console.WriteLine("What kind of vehicle?:");
            Type vehicleType;
            string vehicleTypeString = Console.ReadLine().ToUpper();
            if ((vehicleTypeString != "") && (!typeDictionary.ContainsKey(vehicleTypeString)))
            {
                Console.WriteLine("The string could not be interpreted as a kind of vehicle.");
                return;
            }
            else typeDictionary.TryGetValue(vehicleTypeString, out vehicleType); 
            Console.WriteLine("Color?:");
            string color = Console.ReadLine();
            Console.WriteLine("Number of wheels?:");
            int wheels;
            if (!int.TryParse(Console.ReadLine(), out wheels)) wheels = -17;
            var vehicls = theHandler.GetCharacterizedVehicles(vehicleType, wheels, color);
            if (vehicls.Count() == 0) Console.WriteLine("No vehicle fulfills all criteria.");
            else foreach (Vehicle v in vehicls) Console.WriteLine(v.License);
            Console.WriteLine();
        }

        private void ListVehicleTypes()
        {
            List<TypeListItem> groupList = theHandler.ListVehicleTypes();
            Console.WriteLine( "Type               Count");
            foreach (var group in groupList) Console.WriteLine($"{group.Namn}  {group.Antal}");
            Console.WriteLine();
        }

        private void FantasyPopulation()
        {
            theHandler.CreateGarage(7);
            theHandler.AddVehicle(new Car("CAR1", "Red", 4, 4));
            theHandler.AddVehicle(new Car("CAR2", "Blue", 4, 7));
            theHandler.AddVehicle(new Airplane("PLANE", "White", 3, false));
            theHandler.AddVehicle(new Motorcycle("MC1", "Black", 3, true));
            theHandler.AddVehicle(new Motorcycle("MC2", "Black", 2, false));
            theHandler.AddVehicle(new Bus("BUS", "Black", 6, true));
            theHandler.AddVehicle(new Boat("BOAT", "Green", 0, false));
            Console.WriteLine("Initializing the garage with seven vehicles.\n");
        }
    }
}

