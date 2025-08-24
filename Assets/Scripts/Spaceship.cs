using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.NetworkInformation;

public class Spaceship : MonoBehaviour
{
    #region Variables
    [Header("Engine")]
    public float EnginePower = 10f;
    public float TurnPower = 10f;
    [Header("Health")]
    public int HealthMax = 3;
    public int HealthCurrent;
    [Header("Bullet")]
    public GameObject BulletPrefab;
    public int BulletSpeed = 100;
    public float FiringRate = 0.33f;
    private float fireTimer = 0f;
    [Header("Sound")]
    public SoundPlayer HitSound;
    public SoundPlayer DieSound;
    [Header("UI")]
    public ShakeCamera Shake;
    public ScreenFlash Flash;

    public int Score = 0;
    public GameOverUI GameOverUI;


    private Rigidbody2D rb2D;
    #endregion
    public bool SpaceShip1 = true;
    public GameObject player;
    public Transform respawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        HealthCurrent = HealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceShip1 == true)
        {
            float horizontalArrow = Input.GetAxis("HorizontalArrow");
            float verticalArrow = Input.GetAxis("VerticalArrow");

            ApplyThrust(verticalArrow);
            ApplyTorque(horizontalArrow);
        }

        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");


            ApplyThrust(vertical);
            ApplyTorque(horizontal);

        }
  

        Updatefiring();

 
        

    }

    private void Updatefiring()
    {
        bool isFiring = Input.GetButton("Fire1");
        fireTimer = fireTimer - Time.deltaTime;
        //other fireTimer -= Time.deltaTime;


        if (isFiring == true && fireTimer <= 0)
        {
            FireBullet();
            fireTimer = FiringRate;
        }


    }
    private void ApplyThrust(float amount)
    {
        //Debug.Log("Thrust amout is " + amount);
        Vector2 thrust = transform.up * EnginePower * Time.deltaTime * amount;
        rb2D.AddForce(thrust);
    }


    private void ApplyTorque(float amount)
    {
        float torque = amount * TurnPower * Time.deltaTime;
        rb2D.AddTorque(-torque);


    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(Flash.FlashRoutine());
        
        StartCoroutine(Shake.ShakeRoutine());
       
        HitSound.PlaySound();
      
        // reduce health 1 or damage
        HealthCurrent = HealthCurrent - damage;
        //Health -= damge; Other way
        //if current health death
        if (HealthCurrent <=0)
        {
           if (gameObject.CompareTag("SpaceShip1"))
            {
                player.transform.position = respawnPoint.position;
                HealthCurrent = HealthMax;
            }
           if (gameObject.CompareTag("SpaceShip2"))
            {
                player.transform.position = respawnPoint.position;
                HealthCurrent = HealthMax;
            }
            //Explode();
        }
    }

    public void Explode ()
    {
        DieSound.PlaySound();
        // explode and destroy ship
        Debug.Log("Game Over");
        GameOver();
        Destroy(gameObject);

    }

    public void FireBullet()
    {
        //create a bullet at spaceship location and rotation
        GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        Vector2 force = transform.up * BulletSpeed;
        rb.AddForce(force);
    
    
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Hiscore", 0);
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("Hiscore", score);
    }

    public void GameOver()
    {
        bool celebrateHighScore = false;
        if(Score > GetHighScore() && celebrateHighScore == false)
        {
            SetHighScore(Score);
            celebrateHighScore = true;
        }
        GameOverUI.Show(celebrateHighScore,Score, GetHighScore());
    }

}
