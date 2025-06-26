using System.Xml.Serialization;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public int HealthMax = 3;
    public int HealthCurrent;

    public int CollisionDamage = 1;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if(ship != null)
        {
            ship.TakeDamage(CollisionDamage);
        }
        
    }

    public void TakeDamage(int damage)
    {

        HealthCurrent -= damage;
        if (HealthCurrent <= 0)
        {
            Explode();
        }


    }

    private void Explode()
    {
     Destroy(gameObject);

    }




    

   
}
