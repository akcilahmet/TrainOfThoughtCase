using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
   [SerializeField] private TMP_Text correctTxt;
   [SerializeField] private GameObject nextBtn;
   private int correcttarget;
   
   public void CorrectTxtSet(int temp)
   {
      correctTxt.text = "0 / " + temp.ToString();
      correcttarget = temp;
   }

   private void Start()
   {
      GameController.Instance.gameFinishEvent += GameFinishCanvasState;
   }

   private void OnDisable()
   {
      GameController.Instance.gameFinishEvent -= GameFinishCanvasState;

   }

   public void CorrextTextUpdate(int temp)
   {
      Debug.Log("updateeee");
      if (temp < 0)
      {
         temp = 0;
      }
      correctTxt.text = temp.ToString()+" / " + correcttarget.ToString();

   }

   public void GameFinishCanvasState()
   {
      Debug.Log("ahmett");
      correctTxt.gameObject.SetActive(false);
      nextBtn.gameObject.SetActive(true);
   }
}
