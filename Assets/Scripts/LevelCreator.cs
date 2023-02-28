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
   private int levelIndex;
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
      levelIndex = _levelManager.levelIndex;
      _gameController.finishScore = levelSo.levels[levelIndex].trainCount;
      canvasController.CorrectTxtSet(levelSo.levels[levelIndex].trainCount);
      GameObject go = Instantiate(levelSo.levels[levelIndex].levelPrefab);
      _objectPool.firstSpline = go.GetComponent<TrainTrackSetup>().startSpline;
      GameObject camera = Instantiate(levelSo.levels[levelIndex].cam);
      
      foreach (var VARIABLE in go.GetComponent<TrainTrackSetup>().junctionSwitchTriggerController)
      {
         VARIABLE.camera = camera.GetComponent<Camera>();

      }
   }

   public void LevelSOUpdate()
   {
      Debug.Log("ahemttt2");
      if (PlayerPrefs.GetInt("levelIndex") < levelSo.levels.Count-1)
      {
         PlayerPrefs.SetInt("levelIndex",PlayerPrefs.GetInt("levelIndex")+1);
         levelSo.levels[PlayerPrefs.GetInt("levelIndex")].unlocked = false;
      }
     
     
   }
}
