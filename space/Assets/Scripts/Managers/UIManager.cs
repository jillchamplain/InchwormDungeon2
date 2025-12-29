using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIGroup[] groups;
    UIGroup getUIGroup(string name)
    {
        foreach(UIGroup ui in groups)
        {
            if(ui.name == name)
                return ui;
        }
        return null;
    }
    [SerializeField] GameState gameState;
    public GameState getGameState() {  return gameState; }
    public void setGameState(GameState newState)
    {
        gameState = newState; 

        switch(gameState)
        {
            case GameState.RUNNER:
                break;
            case GameState.SHOOTER:
                break;
            case GameState.PAUSED:
                break;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void RunnerUI(Player thePlayer)
    {
        if (gameState == GameState.RUNNER)
        {
            getUIGroup("Runner").UpdateUI(true, thePlayer);
            getUIGroup("WorldRunner").UpdateUI(true, thePlayer);
        }
        else
        {
            getUIGroup("Runner").UpdateUI(false);
            getUIGroup("WorldRunner").UpdateUI(false);
        }

    }

    public void ShooterUI()
    {
        if (gameState == GameState.SHOOTER)
            getUIGroup("Shooter").UpdateUI(true);
        else
            getUIGroup("Sooter").UpdateUI(false);
    }

    public void PauseUI()
    {
        if (gameState == GameState.PAUSED)
            getUIGroup("Pause").UpdateUI(true);
        else
            getUIGroup("Pause").UpdateUI(false);
    }

    public void GameOverUI()
    {
        if (gameState == GameState.GAME_OVER)
            getUIGroup("GameOver").UpdateUI(true);
        else
            getUIGroup("GameOver").UpdateUI(false);
    }
}
