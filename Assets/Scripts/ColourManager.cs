using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] colourList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < colourList.Length; i++)
        {
            if (player.GetComponent<Rigidbody2D>().velocity.x < 10)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 10 && player.GetComponent<Rigidbody2D>().velocity.x < 20)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.cyan, (player.GetComponent<Rigidbody2D>().velocity.x - 10) / (20 - 10));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 20 && player.GetComponent<Rigidbody2D>().velocity.x < 50)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.cyan, Color.magenta, (player.GetComponent<Rigidbody2D>().velocity.x - 20) / (50 - 20));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 50 && player.GetComponent<Rigidbody2D>().velocity.x < 80)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.magenta, Color.red, (player.GetComponent<Rigidbody2D>().velocity.x - 50) / (80 - 50));
            }
            /*else if (player.GetComponent<Rigidbody2D>().velocity.x >= 70 && player.GetComponent<Rigidbody2D>().velocity.x < 80)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.magenta, Color.red, (player.GetComponent<Rigidbody2D>().velocity.x - 60) / (80 - 60));
            }*/
        }
    }
}
