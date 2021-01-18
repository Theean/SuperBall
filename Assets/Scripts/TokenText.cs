using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenText : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(new Vector2(1, 2));
    }
}
