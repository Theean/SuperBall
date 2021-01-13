using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public GameObject OuterRing;
    public GameObject PlayerBall;
    public Vector2 x;
    public Vector2 y;

    // Start is called before the first frame update
    public float ringSize;
    public float playerDistance;
    public Vector2 z;
    public bool isClose;
    public bool isPassed;

    void Start()
    {
        PlayerBall = GameManager.instance.ball;

        z = OuterRing.transform.localScale;
        x = OuterRing.transform.position;
        y = PlayerBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        y = PlayerBall.transform.position;

        //playerDistance = (y - x).magnitude;

        if (playerDistance < 50f)
        {
            isClose = true;
        }

        if (isClose == true)
        {
            //OuterRing.transform.localScale = z * playerDistance/4;
        }

        playerDistance = x.x - y.x;
        float normalValue = (playerDistance - 0) / (25 - 0);

        OuterRing.transform.localScale = Vector3.Lerp(transform.localScale * 2f, transform.localScale * 8, normalValue);
    }
}
