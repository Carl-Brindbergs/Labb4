using System.Reflection;

namespace labb4
{
    internal class Program
    {
        enum Gender
        {
            Male,
            Female,
            NonBinary,
            Other
        }
        struct Hair
        {
            public string Color;
            public int Length;
        }

        struct Name
        {
            public string FirstName;
            public string LastName;
        }
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person(new Name { FirstName = "carl", LastName = "brindbergs" }, Gender.Male, new Hair { Color = "Blond", Length = 8 }, new DateTime(1993, 09, 14), "blå"));
            people.Add(new Person(new Name { FirstName = "dafina", LastName = "beqiri" }, Gender.Female, new Hair { Color = "Brown", Length = 43 }, new DateTime(1993, 06, 03), "Brun"));
            people.Add(new Person(new Name { FirstName = "cecilia", LastName = "cedergren" }, Gender.Female, new Hair { Color = "Blond", Length = 50 }, new DateTime(1994, 01, 01), "Green"));

            bool menu = true;
            while (menu == true)
            {
                Console.WriteLine("Välj ett alternativ. Svara med en siffra.");
                Console.WriteLine("[1] Sök efter person");
                Console.WriteLine("[2] Lägg till en person");
                Console.WriteLine("[3] Ta bort person");
                Console.WriteLine("[4] Skriv ut alla personer");
                Console.WriteLine("[5] Avsluta Programmet");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Vad heter personen du vill söka efter i förnamn?");
                        string searchFirstName = Console.ReadLine().Trim().ToLower();

                        Console.WriteLine("Vad heter personen du vill söka efter i efternamn?");
                        string searchLastName = Console.ReadLine().Trim().ToLower();

                        Name searchName = new Name { FirstName = searchFirstName, LastName = searchLastName };
                        bool found = false;

                        foreach (Person person in people)
                        {
                            if (person.Name.FirstName == searchName.FirstName && person.Name.LastName == searchName.LastName)
                            {
                                Console.WriteLine();
                                Console.WriteLine(person.ToString());
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Personen hittades inte.");
                        }
                        break;

                    case "2":
                        AddPerson(people);
                        break;


                    case "3":
                        Console.WriteLine("Vad heter personen du vill söka efter i förnamn?");
                        string deleteFirstName = Console.ReadLine().Trim().ToLower();

                        Console.WriteLine("Vad heter personen du vill söka efter i efternamn?");
                        string deleteLastName = Console.ReadLine().Trim().ToLower();

                        Name deleteName = new Name { FirstName = deleteFirstName, LastName = deleteLastName };
                        bool deleted = false;
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].Name.FirstName == deleteName.FirstName && people[i].Name.LastName == deleteName.LastName)
                            {
                                people.RemoveAt(i);
                                Console.WriteLine("Personen har tagits bort.");
                                deleted = true;
                                break;
                            }
                        }
                        if (!deleted)
                        {
                            Console.WriteLine("Personen hittades inte.");
                        }
                        break;

                    case "4":
                        ListPersons(people);
                        break;

                    case "5":
                        Console.WriteLine("Programmet avslutas.");
                        menu = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;

                }
            }
        }

        static void AddPerson(List<Person> people)
        {
            Gender gender;
            Console.WriteLine("Vad heter personen i förnamn?");
            string firstName = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("Vad heter personen i efternamn?");
            string lastName = Console.ReadLine().Trim().ToLower();

            Name nameInput = new Name { FirstName = firstName, LastName = lastName };

            while (true)
            {
                Console.WriteLine("Vilket kön har personen? Välj med siffra");
                Console.WriteLine("[1] Man");
                Console.WriteLine("[2] Kvinna");
                Console.WriteLine("[3] Icke-Binär");
                Console.WriteLine("[4] Annan");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        gender = Gender.Male;
                        break;

                    case "2":
                        gender = Gender.Female;
                        break;

                    case "3":
                        gender = Gender.NonBinary;
                        break;

                    case "4":
                        gender = Gender.Other;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        continue;
                }
                break;
            }

            Console.WriteLine("Vilken hårfärg har personen?");
            string hairColor = Console.ReadLine();

            int hairLength;
            while (true)
            {
                Console.WriteLine("Hur långt är personens hår i cm? svara i heltal");
                if (!int.TryParse(Console.ReadLine(), out hairLength))
                {
                    Console.WriteLine("Ogiltig längd, försök igen.");
                    continue;
                }
                else
                    break;
            }

            Hair hair = new Hair { Color = hairColor, Length = hairLength };

            int birthYear, birthMonth, birthDay;
            Console.WriteLine("När är personens födelsedag?");

            while (true)
            {

                Console.WriteLine("Vilket år föddes personen? Ange med fyra siffror, t.ex. 1999");

                if (!int.TryParse(Console.ReadLine(), out birthYear))
                {
                    Console.WriteLine("Ogiltigt år.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Vilken månad föddes personen? Svara med två siffror t.ex 03 för Mars");
                if (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
                {
                    Console.WriteLine("Ogiltig månad.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Vilket datum föddes personen? Svara med två siffror t.ex 04");
                if (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > 31)
                {
                    Console.WriteLine("Ogiltigt datum.");
                    continue;
                }
                break;
            }

            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);

            Console.WriteLine("Vilken ögonfärg har personen?");
            string eyeColor = Console.ReadLine();

            people.Add(new Person(nameInput, gender, hair, birthDate, eyeColor));
        }

        static void ListPersons(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }

        class Person
        {
            public Name Name;
            public Gender Gender;
            public Hair Hair;
            public DateTime BirthDate;
            public string EyeColor;

            public Person(Name name, Gender gender, Hair hair, DateTime BirthDate, string EyeColor)
            {
                this.Name = name;
                this.Gender = gender;
                this.Hair = hair;
                this.BirthDate = BirthDate;
                this.EyeColor = EyeColor;
            }

            public override string ToString()
            {
                if (BirthDate.Day < 3 || BirthDate.Day > 20 && BirthDate.Day < 23 || BirthDate.Day > 30)
                    return
                    $"Name: {Name.FirstName} {Name.LastName}\n" +
                    $"Gender: {Gender}\n" +
                    $"Hair Color: {Hair.Color}\n" +
                    $"Hair Length: {Hair.Length}cm\n" +
                    $"Birthday: {BirthDate:%d}:a {BirthDate:MMMM/yyyy}\n" +
                    $"Eye Color: {EyeColor}\n";

                else
                    return
                    $"Name: {Name.FirstName} {Name.LastName}\n" +
                    $"Gender: {Gender}\n" +
                    $"Hair Color: {Hair.Color}\n" +
                    $"Hair Length: {Hair.Length}cm\n" +
                    $"Birthday: {BirthDate:%d}:e {BirthDate:MMMM/yyyy}\n" +
                    $"Eye Color: {EyeColor}\n";
            }
        }
    }
}