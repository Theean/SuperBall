using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject particleEffect;


    Rigidbody2D rigidbody2D;
    Rigidbody rigidbody;
    public bool canBoost;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        else if (GetComponent<Rigidbody2D>())
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }


        //rigidbody.AddForce(transform.right * 800.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("space"))
        {
            if (canBoost)
            {
                if (GetComponent<Rigidbody>())
                {
                    rigidbody.AddForce(new Vector3(400, 600, 0));
                }
                else if (GetComponent<Rigidbody2D>())
                {
                    rigidbody2D.AddForce(new Vector2(400, 600));
                }
            }
            else
            {
                if (GetComponent<Rigidbody>())
                {
                    RaycastHit hit;

                    if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.5f) && hit.collider.tag == "Obstacle")
                    {
                        rigidbody.AddForce(new Vector3(0, 500, 0));
                    }
                }
                else if (GetComponent<Rigidbody2D>())
                {
                    RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f);

                    if (hit2D.collider != null && hit2D.collider.tag == "Obstacle")
                    {
                        rigidbody2D.AddForce(new Vector2(0, 500));
                    }
                }


                
            }
        }
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x + 0.05f, rigidbody.velocity.y);

            //SPEED CONTROL
        

        if (GetComponent<Rigidbody>())
        {
            if (Mathf.Abs(rigidbody.velocity.x) < 5)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x * 2, rigidbody.velocity.y, rigidbody.velocity.z);
            }
        }
        else if (GetComponent<Rigidbody2D>())
        {
            if (rigidbody2D.velocity.x < 10)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + 0.05f, rigidbody2D.velocity.y);
            }
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Token")
        {
            canBoost = true;
        }

        if (other.tag == "Bounce")
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x * -1f, rigidbody.velocity.y, rigidbody.velocity.z);


            //Vector3 newVel = GameManager.instance.baseTransform.transform.InverseTransformDirection(rigidbody.velocity);
            ////newVel = new Vector3(-newVel.x, newVel.y, newVel.z);
            //Debug.Log(newVel.x);
            //newVel.x *= -newVel.x;
            //Debug.Log(newVel.x);
            //rigidbody.velocity = transform.TransformDirection(newVel);
            //Debug.Log("TRIGGER");

            GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            var main = obj.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Token")
        {
            canBoost = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Token")
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            var main = obj.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<SpriteRenderer>().color;
        }

        /*if (collision.collider.tag == "Bounce")
        {
            Debug.Log("TRIGGER");

            GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            var main = obj.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<SpriteRenderer>().color;

            Vector3 newVel = transform.InverseTransformDirection(rigidbody.velocity);
            newVel = new Vector3(-newVel.x, newVel.y, newVel.z);
            rigidbody.velocity = transform.TransformDirection(newVel);
        }*/
    }
}
