using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public bool gameFinish;
   public int score;
   public int finishScore;
  
   public delegate void GameFinish();
   
   public GameFinish gameFinishEvent;
   
   public static GameController Instance { get; private set; }
    
   private void Awake()
   {
      Instance = this;
      Time.timeScale = 1;
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
         gameFinishEvent?.Invoke();
         Time.timeScale = 0;
         return gameFinish;
      }

      gameFinish = false;
      return gameFinish;
   }

  
}
