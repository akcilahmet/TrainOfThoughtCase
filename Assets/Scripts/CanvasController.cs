using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
   [SerializeField] private TMP_Text correctTxt;
   private int correcttarget;
   
   public void CorrectTxtSet(int temp)
   {
      correctTxt.text = "Correct 0 of " + temp.ToString();
      correcttarget = temp;
   }

   public void CorrextTextUpdate(int temp)
   {
      Debug.Log("updateeee");
      if (temp < 0)
      {
         temp = 0;
      }
      correctTxt.text = "Correct "+temp.ToString()+" of " + correcttarget.ToString();

   }
}
