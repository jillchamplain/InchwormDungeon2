using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerController controller;
    [SerializeField] public Shooting shooter;
    [SerializeField] public Health health;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) 
        {
            Debug.Log("colliding with " + collision.gameObject);
            gameObject.GetComponent<Health>().Damage(collision.gameObject.GetComponent<Enemy>().damage);
            Destroy(collision.gameObject);
        }
    }
}
