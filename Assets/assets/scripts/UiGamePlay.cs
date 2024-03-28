using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiGamePlay         : MonoBehaviour
{
    private  static readonly int SCORE_FACTOR = 10;
   [SerializeField] private TextMeshProUGUI scoreLabel;
   [SerializeField] private TextMeshProUGUI highScoreLabel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel.text         = GetScoreString();
         highScoreLabel.text    = GethScoreString();
    
    }

    // Update is called once per frame
    void Update()
    {
         scoreLabel.text        = GetScoreString();
         highScoreLabel.text    = GethScoreString();
    }

     private String GetScoreString(){

          return (GameManager.Instance.GetScore() * SCORE_FACTOR).ToString();
     }
   
    private string GethScoreString(){
   return (GameManager.Instance.GethScore() * SCORE_FACTOR).ToString();

    }
}
