using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void OnStartDelegate(GameObject obj);
    public static OnStartDelegate startDeclare;

    // Start is called before the first frame update
    void Start()
    {
        startDeclare(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
