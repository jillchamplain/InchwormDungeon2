using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPattern", menuName = "SpawnPatterns")] 
public class SpawnPattern : ScriptableObject
{
    [SerializeField] public SpawnData[] spawnData;
}
