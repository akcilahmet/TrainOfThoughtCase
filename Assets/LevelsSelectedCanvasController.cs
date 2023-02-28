using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsSelectedCanvasController : MonoBehaviour
{
   [SerializeField] private GameObject centerPanel;
   [SerializeField] private LevelSO levelSO;
   [SerializeField] private List<LevelSelectedBtnController> levelSelectedBtnList;

   private void Awake()
   {
       SetupLevelBtn();
   }

  

   public void LevelsSelectedPanelState(bool temp)
   {
      centerPanel.SetActive(temp);
   }


   void SetupLevelBtn()
   {
       for (int i = 0; i < levelSO.levels.Count; i++)
       {
           levelSelectedBtnList[i].unlocked = levelSO.levels[i].unlocked;
           levelSelectedBtnList[i].levelIndex = i;
       }
   }

  
}
