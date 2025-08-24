using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ObjectToFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, transform.position.z);
        
    }
}
