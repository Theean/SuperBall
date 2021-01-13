using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform camera;
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
        if (Input.GetKey("w") || OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > 0)
        {
            if (player.activeSelf)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + speed * Time.deltaTime, player.transform.position.z);
            }

            if (camera.gameObject.activeSelf)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + speed * Time.deltaTime, camera.transform.position.z);
            }
            
        }
        else if (Input.GetKey("s") || OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < 0)
        {
            if (player != null)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - speed * Time.deltaTime, player.transform.position.z);
            }

            if (camera.gameObject.activeSelf)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - speed * Time.deltaTime, camera.transform.position.z);
            }

        }
    }  
}
