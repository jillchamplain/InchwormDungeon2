using NUnit.Framework;
using UnityEngine;

public enum SpawnType
{
	NULL = -1,
	OBJECT,
	NONE,
}

[CreateAssetMenu(fileName = "SpawnData", menuName = "SpawnData")]
public class SpawnData : ScriptableObject
{
	[SerializeField] SpawnType[] spawnTypes;
}
