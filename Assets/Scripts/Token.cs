using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    [SerializeField] GameObject OuterRing;
    GameObject PlayerBall;

    Vector2 x;
    Vector2 y;
    float playerDistance;


    void Start()
    {
        PlayerBall = GameManager.instance.ball;

        x = OuterRing.transform.position;
        y = PlayerBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        y = PlayerBall.transform.position;

        playerDistance = x.x - y.x;
        float normalValue = (playerDistance - 0) / (25 - 0);

        OuterRing.transform.localScale = Vector3.Lerp(Vector3.one * 1f, Vector3.one * 3f, normalValue);
    }
}