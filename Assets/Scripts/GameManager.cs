using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform baseTransform;

    public GameObject ball;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        /*if (ball.transform.position.z != baseTransform.position.z)
        {
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, baseTransform.position.z);
        }*/
    }
}
