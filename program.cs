using System;

namespace Drofsnar
{
    public class Program
    {
        private string[] _events = Array.Empty<string>();
        private int score = 5000;
        private int hunters = 0;
        private int lives = 3;

        string[] birdNames = 
        {
            "Bird",
            "CrestedIbis",
            "GreatKiskudee",
            "RedCrossbill",
            "Red-neckedPhalarope",
            "EveningGrosbeak",
            "GreaterPrairieChicken",
            "IcelandGull",
            "Orange-belliedParrot"
        };
        int[] birdScores = 
        {
            10,
            100,
            300,
            500,
            700,
            1000,
            2000,
            3000,
            5000
        };
        public void SetEvents(string[] events)
        {
            _events = events;
        }
       public void Run()
{
    foreach (string gameEvent in _events)
    {
        string lifeEvent = "";
        int birdScore = 0;

        switch (gameEvent)
        {
            case "InvincibleBirdHunter":
                lives--;
                lifeEvent = "-1 Life";
                hunters = 0;
                break;
            case "VulnerableBirdHunter":
                double power = Math.Pow(2, hunters);
                score += 200 * Convert.ToInt32(power);
                hunters++;
                break;
            default:
                int birdIndex = Array.IndexOf(birdNames, gameEvent);
                if (birdIndex >= 0 && birdIndex < birdScores.Length)
                {
                    string birdName = birdNames[birdIndex];
                    birdScore = birdScores[birdIndex];
                    score += birdScore;
                }
                break;
        }

        Console.WriteLine($"{gameEvent} {birdScore} {score} {lives} {lifeEvent}");

        if (lives <= 0)
        {
            Console.WriteLine("You Died!");
            break;
        }
    }
}
        private static string[] GetEventsFromFile(string path)
        {
            string text = File.ReadAllText(path);
            return text.Split(',');
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.SetEvents(GetEventsFromFile("/Users/scott/Desktop/ElevenFifty/dotnetProjects/Drofsnar/game-sequence.txt"));
            program.Run();
        }
    }
}
