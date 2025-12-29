using UnityEngine;

public enum GameMode
{
    NULL = -1,
    EASY,
    NORMAL,
    MEDIUM,
    HARD,
    IMPOSSIBLE
}

[CreateAssetMenu(fileName = "GameData", menuName = "GameModes")]
public class GameData: ScriptableObject
{
    [SerializeField] GameMode name;
    [SerializeField] float damageMult;
    [SerializeField] float damageTakeMult;
    [SerializeField] float healthGivenMult;
    [SerializeField] float ammoGivenMult;
    [SerializeField] float ammoTakeMult;

    [SerializeField] public float minSpeed; //augment based on object's speed
    [SerializeField] public float maxSpeed;
    [SerializeField] public float speedIncrease;

    [SerializeField] public float startSpawnInterval; //Interval between spawns
    [SerializeField] public float minSpawnInterval; //Least it can wait

    [SerializeField] public float diffInterval; //How frequent to change difficulty
    [SerializeField] public float diffIncrease; //How much to increase speed 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
