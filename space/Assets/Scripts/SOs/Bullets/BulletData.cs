using UnityEngine;

public enum BulletType
{
    NULL = -1,
    BASIC,
    NUM_BULLETS,
}

[CreateAssetMenu(fileName = "BulletData", menuName = "Bullets")]
public class BulletData : ScriptableObject
{
    [SerializeField] public BulletType type;
    [SerializeField] public float fireRate;
    [SerializeField] public float reloadSpeed;
    [SerializeField] public float lifetime;
    [SerializeField] public float damage;
    [SerializeField] public float travelSpeed;
    [SerializeField] public int ammoCost;
    [SerializeField] public int maxAmmoAmount;

	[SerializeField] public Vector3[] bulletSpawns;
}
