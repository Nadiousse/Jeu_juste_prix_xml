using System.Xml.Serialization;

namespace tp_juste_pris_tb_score.Classes;

public static class Game
{
    static string _xmlFileName = "scoreboard.xml";
    static string _path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + _xmlFileName;
    
    public static int Score { get; set; }
    public static int NumberFind { get; set; }
    public static int NumberTry { get; set; }
    public static int CountTry { get; set; }
    public static ScoreBoard ActualScoreBoard { get; set; }

    public static void StartGame()
    {
        ActualScoreBoard = new ScoreBoard();
        DeserializeScoreBoard();
        
        Score = 0;
        CountTry = 1;
        
        int minNumber = 0;
        int maxNumber = 100;

        Random random = new Random();
        NumberFind = random.Next(minNumber, maxNumber+1);
    }

    public static void OneTry()
    {
        Console.Write("Enter a number : ");

        string enteredNumber = Console.ReadLine();

        int tempNumber;
        int.TryParse(enteredNumber, out tempNumber);

        NumberTry = tempNumber;
    }

    public static bool ControlNumber()
    {
        if (NumberTry == NumberFind)
        {
            Score = CountTry;
            return false;
        }
        else
        {
            if (CountTry != 1)
            {
                if (NumberTry < NumberFind)
                {
                    Console.WriteLine("Plus grand !\n");
                }
                else
                {
                    Console.WriteLine("Plus petit !\n");
                }
            }

            CountTry++;
            return true;
        }
    }

    public static void EndGame()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"Congratulation ! You found the number. You score is {CountTry}.");
        Console.WriteLine("--------------------------------------------------------\n");
        
        ActualScoreBoard.NewScoreBoardEntry(CountTry);
        
        ActualScoreBoard.DisplayScoreBoard();
        
        SerializeScoreBoard();
    }

    public static void ContinuePlaying(out bool continueOrStop)
    {
        Console.Write("Do you want to continue ? (yes/no)  ");
        string answer = Console.ReadLine();

        if (answer.ToLower() == "yes")
        {
            continueOrStop = true;
        }
        else
        {
            continueOrStop = false;
        }
        
    }
    
    public static void DeserializeScoreBoard()
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScoreBoard));
            StreamReader streamReader = new StreamReader(_path);
            ActualScoreBoard = (ScoreBoard)xmlSerializer.Deserialize(streamReader);
            streamReader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public static void SerializeScoreBoard()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScoreBoard));
        StreamWriter streamWriter = new StreamWriter(_path);
        
        xmlSerializer.Serialize(streamWriter, ActualScoreBoard);
        streamWriter.Close();
    }
}