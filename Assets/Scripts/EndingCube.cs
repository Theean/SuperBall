using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCube : MonoBehaviour
{

    public GameObject player;
    public Transform playerTransform;
    public Transform playerLocation;
    public float speed = 60f;
    bool playerScript;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = playerTransform;

        if (isMoving == false)
        {
            if (player.GetComponent<Ball>().boxComing == true)
            {         
                transform.position = Vector3.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
            }
        }

    }
}
