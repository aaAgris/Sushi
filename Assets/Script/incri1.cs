using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class incri1 : MonoBehaviour{
    private Text score;
    private int scoreAmount;

    void Start()
    {
        scoreAmount = 1;
        score=GetComponent<Text>();

    }

    private void Update(){
      score.text=scoreAmount.ToString();
    }

   
    public void SubtractScore()
    {
        scoreAmount -=1;
    }

    public void IncriseScore()
    {
        scoreAmount +=1;
    }
}
