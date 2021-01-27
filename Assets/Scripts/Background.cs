using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Quaternion randomRot;
    float xSpin;
    float ySpin;
    float zSpin;

    private void OnEnable()
    {
        Ball.perfectHit += Beat;
    }

    private void OnDisable()
    {
        Ball.perfectHit -= Beat;
    }

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

    void Beat()
    {
        transform.localScale = new Vector3(transform.localScale.x + 2f, transform.localScale.y + 2f, transform.localScale.z + 2f);
        StartCoroutine(BeatTimer());
    }

    IEnumerator BeatTimer()
    {
        yield return new WaitForSeconds(0.25f);
        transform.localScale = new Vector3(transform.localScale.x - 2f, transform.localScale.y - 2f, transform.localScale.z - 2f);
    }
}
