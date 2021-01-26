using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int currentScore;
    public int scorePerNode = 100;
    public int perfectMod = 10;
    public int greatMod = 5;
    public int goodMod = 2;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public int currentCombo;
    public int maxCombo;
    public int comboBase;

    // Start is called before the first frame update
    void Start()
    {
        currentMultiplier = 1;
        comboBase = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NodeHit()
    {
        currentCombo++;


        
        if(currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;

            }
        }

        currentScore += scorePerNode * currentMultiplier;
        currentScore += currentCombo * comboBase * currentMultiplier;
    }

    public void NodeMiss()
    {
        Debug.Log("Missed Node");

        currentMultiplier = 1;
        currentCombo = 0;
        multiplierTracker = 0;
    }


}
