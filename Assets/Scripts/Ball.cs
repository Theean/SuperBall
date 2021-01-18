using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject particleEffect;

    AudioSource source;
    Rigidbody2D rigidbody;
    public bool canBoost;
    GameObject tempToken; //used to keep track of which token the ball is currently in contact with

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //JUMP & BOOST
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("space"))
        {
            if (canBoost)
            {
                //Mathf.Abs((gameObject.transform.position - tempToken.transform.position).magnitude) <= 0.3

                if (Mathf.Abs(gameObject.transform.position.x - tempToken.transform.position.x) <= 0.3)
                {
                    Debug.Log("Perfect!");
                    SoundManager.instance.PlayPerfect(source);
                }
                else if (Mathf.Abs(gameObject.transform.position.x - tempToken.transform.position.x) <= 0.6)
                {
                    Debug.Log("Great!");
                    SoundManager.instance.PlayOkay(source);
                }
                else
                {
                    Debug.Log("Good!");
                    SoundManager.instance.PlayBad(source);
                }

                    rigidbody.AddForce(new Vector2(400, 600));
            }
            else
            {
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f);
                if (hit2D.collider != null && hit2D.collider.tag == "Obstacle")
                {
                    rigidbody.AddForce(new Vector2(0, 500));
                    SoundManager.instance.PlayJump(source);
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
        /*if (GetComponent<Rigidbody>())
        {
            Vector3 gravity = -9.81f * 2 * Vector3.up;
            rigidbody.AddForce(gravity, ForceMode.Acceleration);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Token")
        {
            canBoost = true;
            tempToken = collision.gameObject;
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

            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f);
            if (hit2D.collider != null && hit2D.collider.tag == "Obstacle")
            {
                SoundManager.instance.PlayLand(source);
            }
            else
            {
                SoundManager.instance.PlayWallHit(source);
            }
        }
    }
}
