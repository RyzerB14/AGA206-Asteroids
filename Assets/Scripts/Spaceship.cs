using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float EnginePower = 10f;
    public float TurnPower = 10f;

    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ApplyThrust(vertical);
        ApplyTorque(horizontal);
    }

    private void ApplyThrust(float amount)
    {
        //Debug.Log("Thrust amout is " + amount);
        Vector2 thrust = transform.up * EnginePower * Time.deltaTime * amount;
        rb2D.AddForce(thrust);
    }


    private void ApplyTorque(float amout)
    {
        float torque = amout * TurnPower * Time.deltaTime;
        rb2D.AddTorque(-torque);


    }
}
