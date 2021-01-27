﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            //camera.transform.position = new Vector3(target.transform.position.x + 5.0f, target.transform.position.y, camera.transform.position.z);
            //transform.position = new Vector3(target.transform.position.x + 20.0f, target.transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            transform.position = new Vector3(target.transform.position.x + 10.0f, transform.position.y, transform.position.z);
        }
    }
}
