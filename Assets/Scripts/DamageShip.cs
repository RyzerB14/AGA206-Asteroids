using UnityEngine;

public class DamageShip : MonoBehaviour
{
    public int CollisionDamage = 1;
    public void OnCollisionEnter2D(Collision2D collision)//GetSpaceShip And Is It Colliding with Asteroid
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            ship.TakeDamage(CollisionDamage);
        }

    }
}
