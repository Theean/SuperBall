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
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 10 && player.GetComponent<Rigidbody2D>().velocity.x < 30)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.cyan, (player.GetComponent<Rigidbody2D>().velocity.x - 10) / (30 - 10));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 30 && player.GetComponent<Rigidbody2D>().velocity.x < 50)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.cyan, Color.blue, (player.GetComponent<Rigidbody2D>().velocity.x - 30) / (50 - 30));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 50 && player.GetComponent<Rigidbody2D>().velocity.x < 70)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.magenta, (player.GetComponent<Rigidbody2D>().velocity.x - 50) / (70 - 50));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 70 && player.GetComponent<Rigidbody2D>().velocity.x < 90)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.magenta, Color.red, (player.GetComponent<Rigidbody2D>().velocity.x - 70) / (90 - 70));
            }
            else if (player.GetComponent<Rigidbody2D>().velocity.x >= 90 && player.GetComponent<Rigidbody2D>().velocity.x < 110)
            {
                colourList[i].GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.yellow, (player.GetComponent<Rigidbody2D>().velocity.x - 90) / (110 - 90));
            }
        }
    }
}
