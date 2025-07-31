using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ObjectToFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ObjectToFollow.position;
    }
}
