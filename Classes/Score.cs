namespace tp_juste_pris_tb_score.Classes;

public class ScoreEntry
{
    public string Name { get; set; }
    public int Score { get; set; }

    public ScoreEntry()
    {
        Name = "";
        Score = 0;
    }
    public ScoreEntry(string initName, int initScore)
    {
        Name = initName;
        Score = initScore;
    }

    public override string ToString()
    {
        return Name + " = " + Score;
    }
}