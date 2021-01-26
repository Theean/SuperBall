using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1000;

    float t = 0.0f;
    Quaternion targetRotation;
    Quaternion originalRotation;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.insideUnitSphere.normalized * speed);

        originalRotation = transform.localRotation;
        t = 0;
        targetRotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        t = Mathf.Clamp01(t + Time.deltaTime);
        transform.localRotation = Quaternion.Slerp(originalRotation, targetRotation, t);
    }
}
