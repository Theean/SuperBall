using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float xSpin;
    float ySpin;
    float zSpin;

    bool end;

    Vector3 direction;

    Color currentColour;

    private void OnEnable()
    {
        Ball.perfectHit += Beat;
        EndTrigger.onEndTrigger += End;
    }

    private void OnDisable()
    {
        Ball.perfectHit -= Beat;
        EndTrigger.onEndTrigger -= End;
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentColour = GetComponent<Material>().color;

        xSpin = Random.Range(0.0f, 0.5f);
        ySpin = Random.Range(0.0f, 0.5f);
        zSpin = Random.Range(0.0f, 0.5f);
    }

    private void FixedUpdate()
    {
        transform.Rotate(xSpin, ySpin, zSpin);

        //transform.Rotate(0, ySpin, 0);

        if (end)
        {
            transform.Translate(direction * 5 * Time.fixedDeltaTime);
        }
    }

    void Beat(Color colour)
    {
        transform.localScale = new Vector3(transform.localScale.x + 2f, transform.localScale.y + 2f, transform.localScale.z + 2f);
        //GetComponent<Material>().color = colour;
        StartCoroutine(BeatTimer());
    }

    IEnumerator BeatTimer()
    {
        yield return new WaitForSeconds(0.25f);
        transform.localScale = new Vector3(transform.localScale.x - 2f, transform.localScale.y - 2f, transform.localScale.z - 2f);
        //GetComponent<Material>().color = currentColour;
    }

    void End(Transform ballPos)
    {
        direction = ballPos.position - transform.position;
        end = true;
    }
}
