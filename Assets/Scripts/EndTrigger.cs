using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Transform resetPos;

    public delegate void OnEndDelegate(Transform ballPos);
    public static OnEndDelegate onEndTrigger;
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
            collision.transform.position = new Vector3(resetPos.transform.position.x, collision.transform.position.y, collision.transform.position.z);

            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50f);
            //onEndTrigger(collision.transform);
        }
    }

}
