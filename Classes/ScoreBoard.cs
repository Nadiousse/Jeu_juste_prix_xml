namespace tp_juste_pris_tb_score.Classes;

public class ScoreBoard
{
   
    public List<ScoreEntry> Scores { get; set; }

    public ScoreBoard()
    {
        Scores = new List<ScoreEntry>();
    }

    private void SortScoreBoard()
    {
        List<ScoreEntry> ListSorted = Scores.OrderBy(scoreEntry => scoreEntry.Score).ToList();

        Scores = ListSorted;
    }

    public void AddScores(ScoreEntry newScoreEntry)
    {
        Scores.Add(newScoreEntry);
        
        SortScoreBoard();
    }
    
    public void DisplayScoreBoard()
    {
        int scoreId = 1;
        
        Console.WriteLine("\n------------------------------Scores-------------------------------");
        foreach (ScoreEntry score in Scores)
        {
            if (scoreId >= 5)
            {
                break;
            }
            
            Console.Write($"{scoreId}. ");
            Console.WriteLine(score);
            scoreId++;
        }
        Console.WriteLine("-------------------------------------------------------------------");
    }

    public void NewScoreBoardEntry(int score)
    {
        Console.Write("Entrer your name to be listed in the scoreboard : ");

        string entryName = "";

        try
        {
            entryName = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(entryName))
            {
                throw new Exception();
            }
        }
        catch
        {
            Console.WriteLine("Nom Invalide");
        }

        AddScores(new ScoreEntry(entryName, score));
    }
}