using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public bool gameFinish;
   public int score;
   public int finishScore;
   
   
   public static GameController Instance { get; private set; }
    
   private void Awake()
   {
      Instance = this;
       
   }

   public void ScoreUpdate(int temp)
   {
      score += temp;
      FindObjectOfType<CanvasController>().CorrextTextUpdate(score);

   }

   public bool GameFinishControl()
   {
      if (score >= finishScore)
      {
         gameFinish = true;
         return gameFinish;
      }

      gameFinish = false;
      return gameFinish;
   }

  
}
