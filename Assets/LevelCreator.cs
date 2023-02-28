using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
   [SerializeField] private LevelSO levelSo;
   [SerializeField] private CanvasController canvasController;
   [SerializeField] private LevelManager _levelManager;
   [SerializeField] private GameController _gameController;
   private void Awake()
   {
      LevelSetup();
   }

   void LevelSetup()
   {
      _gameController.finishScore = levelSo.levels[_levelManager.levelIndex].trainCount;
      canvasController.CorrectTxtSet(levelSo.levels[_levelManager.levelIndex].trainCount);
      
   }
}
