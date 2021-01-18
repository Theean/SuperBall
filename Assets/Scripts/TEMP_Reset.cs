using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_Reset : MonoBehaviour
{
    public Transform resetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ball>())
        {
            collision.GetComponent<Ball>().trailParticle.GetComponent<ParticleSystem>().Stop();
            collision.transform.position = new Vector3(resetPos.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            collision.GetComponent<Ball>().trailParticle.GetComponent<ParticleSystem>().Play();
        }
    }

}
