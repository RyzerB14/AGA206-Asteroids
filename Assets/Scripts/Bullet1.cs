using UnityEngine;

public class Bullet1 : MonoBehaviour
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
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            if (ship.CompareTag("pvp1"))
            {
                ship.TakeDamage(Damage);
            }
        }
    }

    private void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   
}
