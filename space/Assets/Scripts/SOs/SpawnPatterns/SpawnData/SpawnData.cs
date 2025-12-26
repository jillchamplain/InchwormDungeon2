using NUnit.Framework;
using UnityEngine;
public enum SpawnType
{
	NULL = -1,
	ENEMY_1,
	ENEMY_2,
	AMMO,
	GUN,
	POWER_UP,
	NONE,
}
[CreateAssetMenu(fileName = "SpawnData", menuName = "SpawnData")]
public class SpawnData : ScriptableObject
{
	[SerializeField] public SpawnType[] spawnTypes;
}
