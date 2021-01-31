using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smiley : MonoBehaviour
{
    private void OnEnable()
    {
        EndTrigger.onEndTrigger += startAnimation;
    }

    private void OnDisable()
    {
        EndTrigger.onEndTrigger -= startAnimation;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startAnimation()
    {
        GetComponent<Animator>().SetTrigger("Start");
    }
}
