using NUnit.Framework;
using UnityEngine;

public enum SpawnType
{
	NULL = -1,
	OBJECT,
	NONE,
}

public class SpawnData : MonoBehaviour
{
	[SerializeField] List<SpawnType> data;
}
