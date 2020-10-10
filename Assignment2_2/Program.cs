/*
 * Author: Patrick D
 * Date Created: 9 Oct 2020
 * Description: Display statistics for two types of hockey players, skaters and goalies
 */
using System;

namespace Assignment2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Skater class and store in one array
            Skater[] sk = { new Skater("Leon Draisaitl", "EDM", 43, 67), new Skater("Connor McDavid", "EDM", 34, 63),
            new Skater("Artemi Panarin", "NYR", 32, 63), new Skater("Wayne Simmonds", "TOR", 21, 37) };

            // Create instances of Goalie class and store in one array
            Goalie[] net = { new Goalie("Tuuka Rask", "BOS", 26, 8, 2.12), new Goalie("Jake Allen", "STL", 12, 6, 2.15),
            new Goalie("Anton Khudobin", "DAL", 16, 8, 2.22) };

            // Call DisplayPlayerStatistics method for each array
            DisplayPlayerStatistics(Skater.ColumnHeadings, sk);            
            DisplayPlayerStatistics(Goalie.ColumnHeadings, net);            
        }

        // Static method, DisplayPlayerStatistics, accepts string array and IListable array as parameters
        public static void DisplayPlayerStatistics (string[] columnHeadings, IListable[] columnValues)
        {
            Console.WriteLine();
            // Display column headings
            for (int x = 0; x < columnHeadings.Length; ++x)
            {
                
                Console.Write(columnHeadings[x].PadRight(15, ' '));
            }            

            // Display player statistics            
            for (int x = 0; x < columnValues.Length; ++x) //Iterate through object array
            {
                Console.WriteLine();
                for (int y = 0; y < columnValues[x].ColumnValues.Length; ++y) //Iterate through the object's IListable array
                {
                    Console.Write(columnValues[x].ColumnValues[y].PadRight(15, ' '));
                }
            }
            Console.WriteLine();
        }
    }

    // Interface named IListable
    public interface IListable { public string[] ColumnValues { get; } }

    // Concrete class Skater, implements IListable
    public class Skater : IListable
    {
        // Class constructor
        public Skater(string name, string team, int goals, int assists)
        {
            Name = name;
            Team = team;
            Goals = goals;
            Assists = assists;
        }

        // Accessor methods for class properties, read-only
        public string Name { get; }
        public string Team { get; }
        public int Goals { get; }
        public int Assists { get; }
        public static string[] ColumnHeadings
        {
            get
            {
                string[] columnHeadings = { "Name", "Team", "G", "A" };
                return columnHeadings;
            }
        }

        // Implement ColumnValues
        public string[] ColumnValues
        {
            get
            {
                string[] columnValues = { Name, Team, Convert.ToString(Goals), Convert.ToString(Assists) };
                return columnValues;

            }
        }
    }

    // Concrete class named Goalie, implements IListable
    public class Goalie : IListable
    {
        // Class constructor
        public Goalie(string name, string team, int wins, int losses, double goalsAgainstAverage)
        {
            Name = name;
            Team = team;
            Wins = wins;
            Losses = losses;
            GoalAgainstAverage = goalsAgainstAverage;
        }

        // Accessor methods for class properties, read-only
        public string Name { get; }
        public string Team { get; }
        public int Wins { get; }
        public int Losses { get; }
        public double GoalAgainstAverage { get; }
        public static string[] ColumnHeadings
        {
            get
            {
                string[] columnHeadings = { "Name", "Team", "W", "L", "GAA" };
                return columnHeadings;
            }
        }

        // Implement ColumnValues
        public string[] ColumnValues
        {
            get
            {
                string[] columnValues = { Name, Team, Convert.ToString(Wins), Convert.ToString(Losses), 
                    Convert.ToString(GoalAgainstAverage) };
                return columnValues;

            }
        }
    }

}


