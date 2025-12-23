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

    [SerializeField] float speedMult;
    [SerializeField] float maxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
