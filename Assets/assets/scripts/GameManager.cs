using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager    : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
   



    private static readonly string KEY_HIGHEST_SCORE = "highestScore";
public bool isGameOver {get; private set;}


[Header("Audio")]
[SerializeField] private AudioSource musicPlayer;
[SerializeField] private AudioSource GameOverSfx;


[Header("score")]
[SerializeField] private float score;

[SerializeField] private int hScore;

   void Awake() {
             if(Instance != null && Instance != this) {
                    Destroy(this);

             }else{
                Instance    = this;
             }
   

          score             = 0;
          hScore = PlayerPrefs.GetInt(KEY_HIGHEST_SCORE);
   
   
   
   }

    void Start()
    {
        
    }

   
   
   public int GetScore(){

    return (int) Mathf.Floor(score);
    
   }

   public int GethScore(){

       return hScore;
   }
   
    // Update is called once per frame
    void Update()
    {
       
       //increment Score
       if(!isGameOver){
        score   += Time.deltaTime;

       }


         //update HighScore
       if(GetScore()> GethScore()){
              hScore    = GetScore();

       }
    }
    public void EndGame(){
      if(isGameOver) return;
      //set flag
      isGameOver            = true;
      
      //Stop Music
      musicPlayer.Stop();
      

      // Play Sfx
      GameOverSfx.Play();


        //save highest Score
        PlayerPrefs.SetInt(KEY_HIGHEST_SCORE, GethScore());
    
         StartCoroutine(ReloadScene(6));
    
    }
   
      private IEnumerator ReloadScene(float delay){

         yield return new WaitForSeconds(delay);

         string sceneName = SceneManager.GetActiveScene().name;
         SceneManager.LoadScene(sceneName);

      }




}
