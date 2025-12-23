using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    NULL = -1,
    MENU,
    RUNNER,
    SHOOTER,
    PAUSED,
    GAME_OVER,
    NUM_STATES,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameState curState = GameState.RUNNER;

    public void setGameState(int index)
    {
        setGameState((GameState)index);
    }
    public void setGameState(GameState newState)
    {
		GameState bufferState;

		switch (newState)
        {
            case GameState.RUNNER:
				lastState = curState;
				curState = newState;

				Time.timeScale = 1;
                player.controller.setGameState(curState);
                ui.setGameState(GameState.RUNNER);
                break;
            case GameState.SHOOTER:
				lastState = curState;
				curState = newState;

				Time.timeScale = 1;
                player.controller.setGameState(curState);
                ui.setGameState(GameState.SHOOTER);
                break;
            case GameState.PAUSED:
                
                if(curState == GameState.PAUSED) //Toggle off
                {
					
					//Debug.Log("unpausing");
                    Time.timeScale = 1;
					player.controller.setGameState(lastState);
                    ui.setGameState(lastState);

                    bufferState = lastState;
					lastState = curState;
					curState = bufferState;
					ui.PauseUI();

				}
                else
                {
					
					//Debug.Log("pausing");	
					lastState = curState;
                    curState = newState;
					player.controller.setGameState(GameState.PAUSED);
					ui.setGameState(GameState.PAUSED);
					ui.PauseUI();
					Time.timeScale = 0;
				}
				break;
        }
    }

    [SerializeField] GameState lastState;

    [SerializeField] Player player;
    [SerializeField] UIManager ui;

    private void OnEnable()
    {
        Shooting.playerReload += PlayerReload;
        Shooting.playerStopReload += PlayerStopReload;
        Shooting.playerShoot += PlayerShoot;
    }

    private void OnDisable()
    {
        Shooting.playerReload -= PlayerReload;
        Shooting.playerStopReload -= PlayerStopReload;
        Shooting.playerShoot -= PlayerShoot;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setGameState(GameState.RUNNER);
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (curState == GameState.PAUSED)
            {
                
                Debug.Log("unfreeze");
            }
            Pause();
        }
    }

    void SetUp()
    {
        switch(curState)
        {
            case GameState.PAUSED:
                break;
            case GameState.RUNNER:
                ui.RunnerUI(player);
                break;
            case GameState.SHOOTER:
                //ui.ShooterUI(player);
                break;
        }
    }


	#region STATES
	void Pause()
    {
        setGameState(GameState.PAUSED);
        
        //pull up UI
	}

    void Death()
    {
        //player died
    }

    #endregion

    void PlayerHit(Player thePlayer)
    {
		switch (curState)
		{
			case GameState.PAUSED:
				break;
			case GameState.RUNNER:
				ui.RunnerUI(thePlayer);
				break;
			case GameState.SHOOTER:
				//ui.RunnerUI(thePlayer);
				break;
		}
	}

    #region SHOOTING
    void PlayerShoot(Player thePlayer)
    {
        switch(curState)
        {
            case GameState.PAUSED:
                break;
            case GameState.RUNNER:
                ui.RunnerUI(thePlayer);
                break;
            case GameState.SHOOTER:
                //ui.RunnerUI(thePlayer);
                break;
        }
            
    }

    void PlayerReload(Player thePlayer)
    {
		switch (curState)
		{
			case GameState.PAUSED:
				break;
			case GameState.RUNNER:
				ui.RunnerUI(thePlayer);
				break;
			case GameState.SHOOTER:
				//ui.RunnerUI(thePlayer);
				break;
		}
	}

    void PlayerStopReload(Player thePlayer)
    {
        switch (curState)
        {
            case GameState.PAUSED:
                break;
            case GameState.RUNNER:
                ui.RunnerUI(thePlayer);
                break;
            case GameState.SHOOTER:
                //ui.RunnerUI(thePlayer);
                break;
        }
    }

    void PlayerAmmoPack(Player thePlayer)
    {
		switch (curState)
		{
			case GameState.PAUSED:
				break;
			case GameState.RUNNER:
				ui.RunnerUI(thePlayer);
				break;
			case GameState.SHOOTER:
				//ui.RunnerUI(thePlayer);
				break;
		}
	}
	#endregion


}