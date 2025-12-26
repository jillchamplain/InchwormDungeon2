using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public BulletData data;
    [SerializeField] public Movement movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement.speed = data.travelSpeed;
        StartCoroutine(LifeTimer());
    }

    // Update is called once per frame

    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(data.lifetime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Health>().Damage(data.damage);
            Destroy(gameObject);
        }
    }
}
