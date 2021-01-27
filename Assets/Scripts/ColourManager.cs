using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] colourList;
    Color currentColour;
    Color targetColour;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < colourList.Length; i++)
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
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 20 && player.GetComponent<Rigidbody2D>().velocity.x < 35)
            {
                targetColour = Color.Lerp(Color.cyan, Color.magenta, (player.GetComponent<Rigidbody2D>().velocity.x - 20) / (35 - 20));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 35 && player.GetComponent<Rigidbody2D>().velocity.x < 50)
            {
                targetColour = Color.Lerp(Color.magenta, Color.red, (player.GetComponent<Rigidbody2D>().velocity.x - 35) / (50 - 35));
            }

            colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(currentColour, targetColour, 0.02f);
        }
    }
}
