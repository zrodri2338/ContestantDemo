using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CONTESTANT DEMO");
        Console.WriteLine("================");
        Console.WriteLine();

        int numberOfContestants = GetNumberOfContestants();

        Contestant[] contestants =
            new Contestant[numberOfContestants];

        // Enter contestants
        for (int i = 0; i < contestants.Length; i++)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"Contestant #{i + 1}");
            Console.WriteLine("--------------------");

            Console.Write("Enter contestant name: ");
            string name = Console.ReadLine() ?? "";

            int age = GetAge();

            DisplayTalentCategories();

            char talentCode = GetTalentCode();

            if (age <= 12)
            {
                contestants[i] =
                    new ChildContestant(
                        name,
                        age,
                        talentCode);
            }
            else if (age <= 17)
            {
                contestants[i] =
                    new TeenContestant(
                        name,
                        age,
                        talentCode);
            }
            else
            {
                contestants[i] =
                    new AdultContestant(
                        name,
                        age,
                        talentCode);
            }
        }

        double totalRevenue = 0;

        foreach (Contestant contestant in contestants)
        {
            totalRevenue += contestant.EntryFee;
        }

        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine(
            $"Total Expected Revenue: {totalRevenue:C}");
        Console.WriteLine("==============================");

        // Search contestants by talent
        DisplayContestantsByTalent(contestants);

        Console.WriteLine();
        Console.WriteLine("Program ended.");
    }

    static int GetNumberOfContestants()
    {
        int number;

        while (true)
        {
            Console.Write(
                "Enter the number of contestants (0-30): ");

            if (int.TryParse(Console.ReadLine(), out number)
                && number >= 0
                && number <= 30)
            {
                return number;
            }

            Console.WriteLine(
                "Invalid entry. Please enter a number from 0 through 30.");
        }
    }

    static int GetAge()
    {
        int age;

        while (true)
        {
            Console.Write("Enter contestant age: ");

            if (int.TryParse(Console.ReadLine(), out age)
                && age >= 0)
            {
                return age;
            }

            Console.WriteLine(
                "Invalid age. Please enter a valid number.");
        }
    }

    static void DisplayTalentCategories()
    {
        Console.WriteLine();
        Console.WriteLine("Talent Categories:");

        for (int i = 0;
             i < Contestant.TalentCodes.Length;
             i++)
        {
            Console.WriteLine(
                $"{Contestant.TalentCodes[i]} - " +
                $"{Contestant.TalentDescriptions[i]}");
        }

        Console.WriteLine();
    }

    static char GetTalentCode()
    {
        while (true)
        {
            Console.Write(
                "Enter talent code: ");

            string input =
                Console.ReadLine() ?? "";

            // Check that only one character was entered
            if (input.Length != 1)
            {
                Console.WriteLine(
                    "Invalid entry. Please enter one character.");
                continue;
            }

            char code =
                char.ToUpper(input[0]);

            if (Contestant.IsValidTalentCode(code))
            {
                return code;
            }

            Console.WriteLine(
                "Invalid talent code. Please enter S, D, M, or O.");
        }
    }

    static void DisplayContestantsByTalent(
        Contestant[] contestants)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("SEARCH BY TALENT CATEGORY");
            Console.WriteLine("==============================");

            DisplayTalentCategories();

            Console.WriteLine(
                "Enter X when finished.");

            Console.Write(
                "Enter talent code: ");

            string input =
                Console.ReadLine() ?? "";

            if (input.Length != 1)
            {
                Console.WriteLine(
                    "Invalid entry. Please enter one character.");
                continue;
            }

            char code =
                char.ToUpper(input[0]);

            if (code == 'X')
            {
                break;
            }

            if (!Contestant.IsValidTalentCode(code))
            {
                Console.WriteLine(
                    "Invalid talent code. Please enter S, D, M, or O.");
                continue;
            }

            bool found = false;

            Console.WriteLine();
            Console.WriteLine(
                $"Contestants in category {code}:");
            Console.WriteLine("------------------------------");

            foreach (Contestant contestant in contestants)
            {
                if (contestant.TalentCode == code)
                {
                    Console.WriteLine(contestant);
                    Console.WriteLine("------------------------------");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine(
                    "There are no contestants in this category.");
            }
        }
    }
}