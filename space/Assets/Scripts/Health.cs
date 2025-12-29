using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public float maxHealth;

    public delegate void PlayerHit(Player thePlayer);
    public static event PlayerHit playerHit;

    public delegate void PlayerHealed(Player thePlayer);
    public static event PlayerHealed playerHealed;

    public delegate void PlayerDied(Player thePlayer);
    public static event PlayerDied playerDied;

    public delegate void EnemyHit();
    public static event EnemyHit enemyHit;

    public delegate void EnemyHealed();
    public static event EnemyHealed enemyHealed;

    public delegate void EnemyDied();
    public static event EnemyDied enemyDied;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)

        //Find way for player to get score if shot versus collides with player
    {
        Debug.Log("calling from: " + this.gameObject);
        health -= damage;

        if(health <= 0)
        {
            if (GetComponentInParent<Player>())
                playerDied?.Invoke(GetComponentInParent<Player>());
            else
            {
                enemyDied?.Invoke();
                Destroy(gameObject);
            }
                
        }
        else
        {
			if (GetComponentInParent<Player>())
				playerHit?.Invoke(GetComponentInParent<Player>());
			else
				enemyHit?.Invoke();
		}

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
