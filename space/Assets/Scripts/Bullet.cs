using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public BulletData data;
    [SerializeField] public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LifeTimer());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        rb.linearVelocityY = data.travelSpeed;
    }

    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(data.lifetime);
        Destroy(gameObject);
    }
}
