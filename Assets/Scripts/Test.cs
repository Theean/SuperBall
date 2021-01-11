using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + speed * Time.deltaTime, player.transform.position.z);
        }
        else if (Input.GetKey("s"))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - speed * Time.deltaTime, player.transform.position.z);
        }
    }  
}
