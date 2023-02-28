using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectedBtnController : MonoBehaviour
{
   public int levelIndex;
   public bool unlocked;
   [SerializeField] private TMP_Text levelTxt;
   private Button _button;
   [SerializeField] private int selectedLevelIndex;

   private void Start()
   {
      _button = GetComponent<Button>();
      BtnSetup();
      _button.onClick.AddListener(() => BtnClicked());
   }

   void BtnSetup()
   {
      levelTxt.text = "Level " + (levelIndex + 1).ToString();
      if (unlocked)
      {
         _button.interactable = false;
      }
      else
      {
         _button.interactable = true;
      }
   }

   void BtnClicked()
   {
      PlayerPrefs.SetInt("levelIndex",selectedLevelIndex);
      SceneManager.LoadScene("Level");
   }

   public void BtnStateRunTimeUpdate()
   {
      if (unlocked)
      {
         _button.interactable = false;
      }
      else
      {
         _button.interactable = true;
      }
   }
}
