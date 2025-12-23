using UnityEngine;

public enum PlayerControlState
{
	NULL = -1,
	LANE = 1,
	FREE,
	PAUSED,
	NUM_STATES
}

public enum PlayerDirection
{
	NULL = -1,
	LEFT,
	RIGHT,
	NUM_DIRECTIONS
}

public class PlayerController : MonoBehaviour
{
	//HANDLES WHERE PLAYER IS MOVING TO 
	//HANDLES POSITION DATA

	[SerializeField] public GameState gameState;

	public void setGameState(GameState newState) {  gameState = newState; }


	[Header("References")]
	[SerializeField] GameObject thePlayer;
	[SerializeField] Rigidbody2D rb;

	[Header("Lane Movement")]
	[SerializeField] Vector3[] lanePoses;
	public Vector3[] getLanePoses() { return lanePoses; }
	[SerializeField] Vector3 curPos;
	[SerializeField] int laneIndex;
	public void setLaneIndex(int newIndex) { laneIndex = newIndex; }
	public void changeLane(int change)
	{
		if (laneIndex + change < 0)
			return;
		else if (laneIndex + change > 2)
			return;
		laneIndex = laneIndex + change;
		curPos = lanePoses[laneIndex];
	}
	[SerializeField] float laneSpeed;
	[SerializeField] float laneAccel;
	[SerializeField] float laneAccelTime;
	[Header("Free Movement")]
	[SerializeField] Vector3 minPos;
	[SerializeField] Vector3 maxPos;
	[SerializeField] float freeSpeed;
	[SerializeField] float freeAccel;
	[SerializeField] float freeAccelTime;

	void Start()
	{
		
		changeLane(1);

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
		{
			HandleControlState(PlayerDirection.LEFT);
		}
		if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
		{
			HandleControlState(PlayerDirection.RIGHT);
		}


		//CONSTRAINTS

		if (gameState== GameState.RUNNER)
		{
			thePlayer.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, curPos, laneSpeed);
			//Debug.Log("setting position");
		}

		else if (gameState == GameState.SHOOTER)
		{
			if (gameObject.transform.position.x < minPos.x)
				thePlayer.transform.position = minPos;
			else if (gameObject.transform.position.x > maxPos.x)
				thePlayer.transform.position = maxPos;
		}
	}

	public void HandleControlState(PlayerDirection direct)
	{
	
		switch(gameState)
		{
			case GameState.NULL:
				break;
			case GameState.RUNNER:
				LaneMovement(direct);
				break;
			case GameState.SHOOTER:
				FreeMovement(direct);
				break;
		}
	}

	void LaneMovement(PlayerDirection direct)
	{
		//Lerping to lane positions
		switch (direct)
		{
			case PlayerDirection.LEFT:
				changeLane(-1);
				break;
			case PlayerDirection.RIGHT:
				changeLane(1);
				break;
		}

		thePlayer.transform.position = Vector3.Lerp(gameObject.transform.position, curPos, laneSpeed);
	}

	void FreeMovement(PlayerDirection direct) //Doesn't work yet
	{
		//Adding Force with constraints
		switch (direct)
		{
			case PlayerDirection.LEFT:
				rb.AddForce(new Vector3(-freeSpeed, 0));
				break;
			case PlayerDirection.RIGHT:
				rb.AddForce(new Vector3(freeSpeed, 0));
				Debug.Log("adding  force");
				break;
		}
	}
}
