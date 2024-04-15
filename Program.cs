using tp_juste_pris_tb_score.Classes;

bool continueGame = true;

while (continueGame)
{
    Game.StartGame();

    while (Game.ControlNumber())
    {
        Game.OneTry();
    }

    Game.EndGame();

    Game.ContinuePlaying(out continueGame);
}
