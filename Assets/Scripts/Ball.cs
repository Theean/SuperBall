using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;
    [SerializeField] GameObject trailPrefab;
    public GameObject trailParticle; //temporarily public atm

    AudioSource source;
    Rigidbody2D rigidbody;
    public bool canBoost;
    GameObject tempToken; //used to keep track of which token the ball is currently in contact with

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();

        trailParticle = Instantiate(trailPrefab, transform.position, Quaternion.identity);
        //var main = t.GetComponent<ParticleSystem>().main;
        //main.startColor = GetComponent<SpriteRenderer>().color;
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
                trailParticle.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f);
                if (hit2D.collider != null && hit2D.collider.tag == "Obstacle")
                {
                    rigidbody.AddForce(new Vector2(0, 500));
                    SoundManager.instance.PlayJump(source);
                    trailParticle.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x + 0.05f, rigidbody.velocity.y);

        //SPEED CONTROL

        if (rigidbody.velocity.x < 10)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + 0.05f, rigidbody.velocity.y);
        }


        //TRAIL PARTICLE FOLLOW & COLOUR
        trailParticle.transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y - 0.4f, transform.position.z);
        var main = trailParticle.GetComponent<ParticleSystem>().main;
        main.startColor = new Color(GetComponent<SpriteRenderer>().color.r + 0.2f, GetComponent<SpriteRenderer>().color.g + 0.2f, GetComponent<SpriteRenderer>().color.b + 0.2f);
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
            //obj.GetComponent<ParticleSystem>().Stop();

            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f);
            if (hit2D.collider != null && hit2D.collider.tag == "Obstacle")
            {
                SoundManager.instance.PlayLand(source);
                trailParticle.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                SoundManager.instance.PlayWallHit(source);
            }
        }
    }
}
