using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> colourList;

    Color currentColour;
    Color targetColour;

    private void OnEnable()
    {
        Ball.greenHit += RedChange;
        Obstacle.startDeclare += AddObject;
        Ball.startDeclare += AddObject;
    }

    private void OnDisable()
    {
        Ball.greenHit -= RedChange;
        Obstacle.startDeclare -= AddObject;
        Ball.startDeclare -= AddObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void AddObject(GameObject obj)
    {
        colourList.Add(obj);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (colourList.Count > 0)
        {
            for (int i = 0; i < colourList.Count; i++)
            {
                currentColour = colourList[i].GetComponent<SpriteRenderer>().color;

                if (player.GetComponent<Rigidbody2D>().velocity.x < 10)
                {
                    targetColour = Color.white;
                }
                else if (player.GetComponent<Rigidbody2D>().velocity.x >= 10 && player.GetComponent<Rigidbody2D>().velocity.x < 20)
                {
                    targetColour = Color.Lerp(Color.white, Color.cyan, (player.GetComponent<Rigidbody2D>().velocity.x - 10) / (20 - 10));
                }
                else if (player.GetComponent<Rigidbody2D>().velocity.x >= 20 && player.GetComponent<Rigidbody2D>().velocity.x < 30)
                {
                    targetColour = Color.Lerp(Color.cyan, Color.magenta, (player.GetComponent<Rigidbody2D>().velocity.x - 20) / (30 - 20));
                }
                else if (player.GetComponent<Rigidbody2D>().velocity.x >= 30 && player.GetComponent<Rigidbody2D>().velocity.x < 40)
                {
                    targetColour = Color.Lerp(Color.magenta, Color.red, (player.GetComponent<Rigidbody2D>().velocity.x - 30) / (40 - 30));
                }

                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(currentColour, targetColour, 0.05f);
            }
        }
        
    }

    void RedChange()
    {
        for (int i = 0; i < colourList.Count; i++)
        {
            currentColour = Color.red;
            colourList[i].GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
