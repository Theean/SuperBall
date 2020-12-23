using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject particleEffect;


    Rigidbody2D rigidbody;
    public bool canBoost;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        //rigidbody.AddForce(new Vector2(250, 0));

        //rigidbody.velocity = new Vector2(20, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("space"))
        {
            if (canBoost)
            {
                rigidbody.AddForce(new Vector2(400, 600));
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f);

                if (hit.collider != null && hit.collider.tag == "Obstacle")
                {
                    rigidbody.AddForce(new Vector2(0, 500));
                }
            }
        }
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x + 0.05f, rigidbody.velocity.y);

            //SPEED CONTROL
            if (rigidbody.velocity.x < 10)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + 0.05f, rigidbody.velocity.y);
        }

        //Debug.Log(rigidbody.velocity);
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Token")
        {
            canBoost = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Token")
        {
            canBoost = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            var main = obj.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<SpriteRenderer>().color;
        }
    }
}
