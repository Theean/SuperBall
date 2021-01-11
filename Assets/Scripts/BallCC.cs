using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCC : MonoBehaviour
{
    public GameObject particleEffect;
    public bool canBoost;

    CharacterController controller;
    public Vector3 velocity;
    bool previouslyGrounded;

    float gravity = -15f;
    float airTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        velocity = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("space"))
        {
            if (canBoost)
            {
                if (velocity.x > 0)
                {
                    velocity.x += 15.0f;
                }
                else
                {
                    velocity.x -= 15.0f;
                }
                
                velocity.y += 15.0f;
            }
            else if (controller.isGrounded)
            {
                velocity.y += 10.0f;
            }
        }
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x + 0.05f, rigidbody.velocity.y);

        //SPEED CONTROL


        /*if (GetComponent<Rigidbody>())
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
        }*/
    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            if (airTime > 0.5)
            {
                velocity.y = 0;

                GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
                var main = obj.GetComponent<ParticleSystem>().main;
                //main.startColor = GetComponent<SpriteRenderer>().color;

                airTime = 0;
            }
            
        }

        if (controller.isGrounded == false && velocity.y > gravity)
        {
            airTime += Time.fixedDeltaTime;
            velocity.y += gravity * Time.deltaTime;

            //controller.Move(new Vector3(0, gravity, 0) * Time.fixedDeltaTime);
        }


        Vector3 newVel = transform.TransformDirection(velocity);
        controller.Move(newVel * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            var main = obj.GetComponent<ParticleSystem>().main;
            //main.startColor = GetComponent<SpriteRenderer>().color;
        }

        if (other.tag == "Token")
        {
            canBoost = true;
        }

        if (other.tag == "Bounce")
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);

            GameObject obj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            var main = obj.GetComponent<ParticleSystem>().main;
            //main.startColor = GetComponent<SpriteRenderer>().color;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Token")
        {
            canBoost = false;
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
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.gameObject.name);
    }
}
