using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float maxHealth;

    public delegate void PlayerHit(Player thePlayer);
    public static event PlayerHit playerHit;

    public delegate void PlayerHealed(Player thePlayer);
    public static event PlayerHealed playerHealed;

    public delegate void EnemyHit();
    public static event EnemyHit enemyHit;

    public delegate void EnemyHealed();
    public static event EnemyHealed enemyHealed;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (GetComponentInParent<Player>())
            playerHit?.Invoke(GetComponentInParent<Player>());
        else
            enemyHit?.Invoke();

    }

    public void Heal(float heal)
    {
        health += heal;

        if (GetComponentInParent<Player>())
            playerHealed?.Invoke(GetComponentInParent<Player>());
        else
            enemyHealed?.Invoke();
    }
}
