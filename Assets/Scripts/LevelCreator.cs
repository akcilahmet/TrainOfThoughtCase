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

   private void OnEnable()
   {
      _gameController.gameFinishEvent += LevelSOUpdate;
   }

   private void OnDisable()
   {
      _gameController.gameFinishEvent -= LevelSOUpdate;
   }

   void LevelSetup()
   {
      _gameController.finishScore = levelSo.levels[_levelManager.levelIndex].trainCount;
      canvasController.CorrectTxtSet(levelSo.levels[_levelManager.levelIndex].trainCount);
      GameObject go = Instantiate(levelSo.levels[_levelManager.levelIndex].levelPrefab);
      _objectPool.firstSpline = go.GetComponent<TrainTrackSetup>().startSpline;
      
      foreach (var VARIABLE in go.GetComponent<TrainTrackSetup>().junctionSwitchTriggerController)
      {
         VARIABLE.camera = cam;

      }
   }

   public void LevelSOUpdate()
   {
      Debug.Log("ahemttt2");
      PlayerPrefs.SetInt("levelIndex",PlayerPrefs.GetInt("levelIndex")+1);
      levelSo.levels[PlayerPrefs.GetInt("levelIndex")].unlocked = false;
   }
}
