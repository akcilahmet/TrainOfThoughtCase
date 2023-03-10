using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
   [SerializeField] private LevelSO _levelSo;
   public SplineComputer firstSpline;
   [SerializeField] private GameObject trainPrefab;
   [SerializeField] private Transform createdPos;
   [SerializeField] private List<GameObject> trains;
   [SerializeField] private List<GameObject> moveTrains;

   [Header("Timer")][Space(10)]
   [SerializeField] private float timer = 2f;
   private float originalTimer;
   private bool timerBool;
  
   public static ObjectPool Instance { get; private set; }
 
  
   private void Awake()
   {
      Instance = this;
   }

   private void Start()
   {
      originalTimer = timer;
      timer = 2;
      TrainsCreated();
   }

   private int levelIndex;
   void TrainsCreated()
   {
      for (int i = 0; i < 10; i++)
      {
         levelIndex = LevelManager.Instance.levelIndex;
         GameObject go = Instantiate(trainPrefab, createdPos.transform.position,Quaternion.identity);
         Train goTrain = go.GetComponent<Train>();
       
         goTrain.SplineAssignValue(firstSpline);

         #region RandomCOlortypeSet

         int randomColor;
         if (i > _levelSo.levels[levelIndex].colorList.Count - 1)
         {
            randomColor=Random.Range(0,_levelSo.levels[levelIndex].colorList.Count);
         }
         else
         {
            randomColor = i;
         }
         
         goTrain.TrainColorSet(_levelSo.levels[levelIndex].colorList[randomColor]);
         goTrain.trainType = _levelSo.levels[levelIndex].trainType[randomColor];

         #endregion
       
        
         goTrain.TrainSetActiveState(false);
         go.transform.SetParent(transform);
       
         trains.Add(go);
      }
   }

   private void Update()
   {
      TrainMoveControl();
   }

   void TrainMoveControl()
   {
      if (!timerBool)
      {
         timer -= Time.deltaTime;
         if (timer <= 0)
         {
            timerBool = true;
            timer = originalTimer;
           ActivateTrain();
         }
      }
   }

   void ActivateTrain()
   {
      if (trains.Count > 0)
      {
         moveTrains.Add( trains[0]);
         trains[0].GetComponent<Train>().TrainSetActiveState(true);
         trains[0].GetComponent<Train>().SplineAssignValue(firstSpline);
         trains.Remove(trains[0]);
       

         timerBool = false;
      }
     
   }

   public void ReturnTheObjectToThePool(GameObject go) 
   {
      levelIndex = LevelManager.Instance.levelIndex;
      Train tempTrain = go.GetComponent<Train>();
      tempTrain.ResetTrain();
      go.transform.position = createdPos.position;
      trains.Add(go);
      moveTrains.Remove(go);
      tempTrain.TrainSetActiveState(false);
      
      int randomColor=Random.Range(0,_levelSo.levels[levelIndex].colorList.Count);
      tempTrain.TrainColorSet(_levelSo.levels[levelIndex].colorList[randomColor]);
      tempTrain.trainType = _levelSo.levels[levelIndex].trainType[randomColor];



   }
}
