using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public GameObject ExplosionPrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroids asteroids = collision.gameObject.GetComponent<Asteroids>();
        if (asteroids)
        {
            asteroids.TakeDamage(Damage);
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   
}
