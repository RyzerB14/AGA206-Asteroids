using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AsteroidRefs; // Asteroids to spawn
    public float CheckInterval = 3f; // Check time if we can spawn
    public float PushForce = 100f; // Force to push object into the screen
    public int SpawnThreshold = 10; // The limit of asteroids we can spawn

    public float Inaccuracy = 2f;

    private float checkTimer = 0f;

    void Start()
    {
        //Debug.Log(TotalAsteroidValue()); 
    }

    private void Update() //When to check if asteroids can spawn
    {
        checkTimer += Time.deltaTime;
        if(checkTimer > CheckInterval)
        {
            checkTimer = 0f;

            if(TotalAsteroidValue() < SpawnThreshold)
            {
                SpawnAsteroid();
            }
        }
    }

    private void SpawnAsteroid()
    {
        //Pick random asteroid from ref
        int asteroidIndex = Random.Range(0, AsteroidRefs.Length);
        GameObject asteroidRef = AsteroidRefs[asteroidIndex];
        //find random spawn
        Vector3 spawnPoint = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);

        GameObject Asteroid = Instantiate(asteroidRef, spawnPoint, transform.rotation);

        Vector2 force = PushDirection(spawnPoint) * PushForce;
        Rigidbody2D rb = Asteroid.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }
    private Vector3 RandomOffscreenPoint()
    {
        Vector2 randomPos = Random.insideUnitCircle;
        Vector2 direction = randomPos.normalized;
        Vector2 finalPos = (Vector2)transform.position + direction * 2f;

        return Camera.main.ViewportToWorldPoint(finalPos);
    }

    public int TotalAsteroidValue()// Get asteroid number and add up
    {
        Asteroids[] asteroids = FindObjectsByType<Asteroids>(FindObjectsSortMode.None);
        int value = 0;
        for(int i = 0; i < asteroids.Length; i++)
        {
            value += asteroids[i].SpawnValue;
        }
        return value;
    }

    private Vector2 PushDirection(Vector2 from)
    {
        Vector2 miss = Random.insideUnitCircle * Inaccuracy;
        Vector2 destination = (Vector2)transform.position + miss;
        Vector2 direction = (destination - from).normalized;

        return direction;
    }
}
