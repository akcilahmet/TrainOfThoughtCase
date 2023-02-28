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
   [SerializeField] private ObjectPool _objectPool;
   [SerializeField] private Camera cam;
   private void Awake()
   {
      LevelSetup();
   }

   void LevelSetup()
   {
      _gameController.finishScore = levelSo.levels[_levelManager.levelIndex].trainCount;
      canvasController.CorrectTxtSet(levelSo.levels[_levelManager.levelIndex].trainCount);
      GameObject go = Instantiate(levelSo.levels[_levelManager.levelIndex].levelPrefab);
      _objectPool.firstSpline = go.GetComponent<TrainTrackSetup>().startSpline;
      go.GetComponent<TrainTrackSetup>().junctionSwitchTriggerController.camera = cam;
   }
}
