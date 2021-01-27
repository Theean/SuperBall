using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;
    [SerializeField] GameObject trailPrefab;
    public GameObject trailParticle; //temporarily public atm

    public GameObject perfectsprite;
    public GameObject greatsprite;
    public GameObject goodsprite;
    float ballMinimumSpeed;
    float ballMaximumSpeed;
    Vector2 currentBallSpeed;

    public GameObject breakBox;
    public int breakNumber=10;

    AudioSource source;
    Rigidbody2D rigidbody;
    public bool canBoost;
    public bool canBreak;
    GameObject tempToken; //used to keep track of which token the ball is currently in contact with

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();

        ballMinimumSpeed = 10f;
        ballMaximumSpeed = 50f;

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
                    var sx = Instantiate(perfectsprite, transform.position + new Vector3(2, 4, 1), Quaternion.identity);
                    //sx.transform.parent = transform;
                    Destroy(sx, 1f);
                    SoundManager.instance.PlayPerfect(source);
                }
                else if (Mathf.Abs(gameObject.transform.position.x - tempToken.transform.position.x) <= 0.6)
                {
                    Debug.Log("Great!");
                    var sy = Instantiate(greatsprite, transform.position + new Vector3(2, 4, 1), Quaternion.identity);
                    //sy.transform.parent = transform;
                    SoundManager.instance.PlayOkay(source);
                    Destroy(sy, 1f);
                }
                else
                {
                    Debug.Log("Good!");
                    var sz = Instantiate(goodsprite, transform.position + new Vector3(2, 4, 1), Quaternion.identity);
                    //sz.transform.parent = transform;
                    SoundManager.instance.PlayBad(source);
                    Destroy(sz, 1f);
                }

                //rigidbody.AddForce(new Vector2(400, 600));

                rigidbody.velocity = new Vector2(rigidbody.velocity.x + 5f, 15f);
            }
            else if (canBreak)
            {
                if (Mathf.Abs(gameObject.transform.position.x - tempToken.transform.position.x) <= 0.3)
                {
                    Debug.Log("Perfect!");
                    var sx = Instantiate(perfectsprite, transform.position + new Vector3(2, 4, 1), Quaternion.identity);
                    //sx.transform.parent = transform;
                    Destroy(sx, 1f);
                    SoundManager.instance.PlayPerfect(source);
                }
                else if (Mathf.Abs(gameObject.transform.position.x - tempToken.transform.position.x) <= 0.6)
                {
                    Debug.Log("Great!");
                    var sy = Instantiate(greatsprite, transform.position + new Vector3(2, 4, 1), Quaternion.identity);
                    //sy.transform.parent = transform;
                    SoundManager.instance.PlayOkay(source);
                    Destroy(sy, 1f);
                }
                else
                {
                    Debug.Log("Good!");
                    var sz = Instantiate(goodsprite, transform.position + new Vector3(2, 4, 1), Quaternion.identity);
                    //sz.transform.parent = transform;
                    SoundManager.instance.PlayBad(source);
                    Destroy(sz, 1f);
                }

                //Destroy(tempToken);
                rigidbody.AddForce(new Vector2(400, 0));
                StartCoroutine(speedBurst());


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

        //Debug.Log(rigidbody.velocity.x);

        //SPEED CONTROL

        if (rigidbody.velocity.x < ballMinimumSpeed)
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
        else if (collision.tag == "Token2")
        {
            canBreak = true;
            tempToken = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Token")
        {
            canBoost = false;
        }
        else if (collision.tag == "Token2")
        {
            canBreak = false;
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



    private void Explosion()
    {
        for (int i = 0; i < breakNumber; i++)
        {
            Instantiate(breakBox, transform.position, Quaternion.identity);
        }      
    }

    IEnumerator speedBurst()
    {
        currentBallSpeed = rigidbody.velocity;
        rigidbody.velocity = new Vector2(20, rigidbody.velocity.y);
        yield return new WaitForSeconds(0.3f);
        Explosion();
        Destroy(tempToken);
        //rigidbody.velocity = new Vector2(ballMaximumSpeed - 2, rigidbody.velocity.y);
    }
}
