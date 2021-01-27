using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Quaternion randomRot;
    float xSpin;
    float ySpin;
    float zSpin;
    // Start is called before the first frame update
    void Start()
    {
        randomRot = Random.rotation;

        xSpin = Random.Range(0.0f, 0.5f);
        ySpin = Random.Range(0.0f, 0.5f);
        zSpin = Random.Range(0.0f, 0.5f);
    }

    private void FixedUpdate()
    {
        transform.Rotate(xSpin, ySpin, zSpin);

        //transform.Rotate(0, ySpin, 0);
    }
}
