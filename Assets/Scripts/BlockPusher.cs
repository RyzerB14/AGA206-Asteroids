using UnityEngine;

public class BlockPusher : MonoBehaviour
{
    public float Speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Capture The Users Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Create a new Verctor of the players Movement
        Vector3 move = new Vector3(horizontal, 0, vertical) * Time.deltaTime * Speed;
        //Move to the new position
        transform.position = transform.position + move;
    }
}
