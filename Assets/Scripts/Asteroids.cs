using System.Xml.Serialization;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [Range(1,3)]
    public int SpawnValue = 3;
    [Space]
    public int HealthMax = 3;
    public int HealthCurrent;
    public int CollisionDamage = 1;
    [Header("Explosion Stuff")]
    public GameObject[] chunks;
    public int ChunksMin = 0;
    public int ChunksMax = 4;
    public float ExplodeDist = 0.5f;
    public float ExplosionForce = 10;



    private void Start()
    {
        HealthCurrent = HealthMax;
        for(int i = 0;i < chunks.Length; i++)
        {
            Debug.Log(chunks[i]);
        }
        //Debug.Log(Chunks.Lenght);

    }
    public void OnCollisionEnter2D(Collision2D collision)//GetSpaceShip And Is It Colliding with Asteroid
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if(ship != null)
        {
            ship.TakeDamage(CollisionDamage);
        }
        
    }
    public void TakeDamage(int damage)//Take Damage
    {

        HealthCurrent -= damage;
        if (HealthCurrent <= 0)
        {
            Explode();
        }
    }
    private void Explode()//Explode the asteroids
    {
        int numChunks = Random.Range(ChunksMin, ChunksMax + 1 );
        
        for(int i=0; i< numChunks; i++)
        {
            CreateAsteroidChunks();
        }

       

     Destroy(gameObject);

    }
    private void CreateAsteroidChunks()//Spawn asteroids Chunks With Arrays
    {
        if (chunks == null || chunks.Length == 0)
            return;

        int randomIndex = Random.Range(0, chunks.Length);

        Vector2 spawnPos = transform.position;
        Vector2 newPos = spawnPos;
        spawnPos.x += Random.Range(-ExplodeDist, ExplodeDist);
        spawnPos.y += Random.Range(-ExplodeDist, ExplodeDist);

       GameObject chunk = Instantiate(chunks[randomIndex], transform.position, transform.rotation);
       Vector2 dir = (spawnPos - newPos).normalized;

        Rigidbody2D rb = chunk.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * ExplosionForce);
    }



    

   
}
