using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<Spawnable> spawnables;
    public List<Spawnable> GetSpawnables() { return spawnables; }
    public Spawnable getSpawnableOfType(SpawnType type)
    {
        foreach(Spawnable s in spawnables)
        {
            if(s.spawnType == type) return s;
        }
        return null;
    }
    [SerializeField] SpawnPattern[] spawnPatterns;
    [SerializeField] LaneData laneData;

    //Difficulty
    [SerializeField] GameData gameData;
    [SerializeField] Vector3 spawnPos;
    [SerializeField] float spawnSpeed;
    [SerializeField] float patternInterval;

    [SerializeField] float moveSpeed;

    [SerializeField] float timeElapsed;
    bool canSpawn = true;
    bool canDiff = false;
    
    SpawnPattern[] getSpawnPatterns() {  return spawnPatterns; }
    public SpawnPattern getSpawnPatternAt(int index)
    {
        for (int i = 0; i < spawnPatterns.Length; i++)
        {
            if(i == index)
                return spawnPatterns[i];
        }
        return null;
    }

    public SpawnPattern getRandomSpawnPattern()
    {
        int index = Random.Range(0, spawnPatterns.Length);
        return spawnPatterns[index];
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnSpeed = gameData.startSpawnInterval;
        moveSpeed = gameData.minSpeed;
        StartCoroutine(DiffTimer());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //timeElapsed += Time.deltaTime * 10;
        if(canDiff)
        {
            ChangeDifficulty();
        }
        
        if(canSpawn)
        {
            SpawnPattern();
			StartCoroutine(SpawnTimer());
		}
    }

    IEnumerator DiffTimer()
    {
        canDiff  = false;
        yield return new WaitForSecondsRealtime(gameData.diffInterval);
        canDiff = true;

    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSecondsRealtime(spawnSpeed);
        canSpawn = true;
    }

    void SpawnPattern()
    {
		canSpawn = false;

		SpawnPattern thePattern = getRandomSpawnPattern();

        for(int i = 0; i < thePattern.spawnData.Length; i++) //Get each spawn data for the lanes and spawn them according to their position in the pattern
        {
            //Debug.Log("The pattern has: " + thePattern.spawnData.Length);
            SpawnData theData = thePattern.spawnData[i];
            for(int j = 0; j < theData.spawnTypes.Length; j++) //Get each piece of object data per lane
            {
               // Debug.Log("length is " + (theData.spawnTypes.Length -1 ));
                float xOffset = 0f;
                switch(j)
                {
                    case 0:
                        xOffset = -laneData.laneWidth;
                        break;
                    case 1:
                        xOffset = 0f;
                        break;
                    case 2:
                        xOffset = laneData.laneWidth;
                        break;

                }
                float yOffset = i * (laneData.maxSegLength);

                //Get Object type and spawn 
                if (getSpawnableOfType(theData.spawnTypes[j])) //If not null
                {
                    GameObject template = getSpawnableOfType(theData.spawnTypes[j]).template;
                    Vector3 spawn = new Vector3(spawnPos.x + xOffset, spawnPos.y + yOffset, 0);
                    GameObject theSpawn = GameObject.Instantiate(template, spawn, Quaternion.identity);
                    theSpawn.GetComponent<Movement>().speed = -moveSpeed;
                }
            }
			
		}

        
    }

    void ChangeDifficulty()
    {
		/*if (timeElapsed % (int)gameData.diffInterval >= .25)
            return;*/
		//return;

		//Change Spawn Speed
		float diffChange = gameData.diffIncrease;
		spawnSpeed -= diffChange;
		if (spawnSpeed < gameData.minSpawnInterval) //Makes sure game never spawns things inside each other 
			spawnSpeed = gameData.minSpawnInterval;

        //Change Move Speed
        float speedChange = gameData.speedIncrease;
        moveSpeed += speedChange;
        if(moveSpeed > gameData.maxSpeed)
            moveSpeed = gameData.maxSpeed;
        
        StartCoroutine(DiffTimer());
      
    }


}
