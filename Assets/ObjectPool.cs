using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
   [SerializeField] private LevelSO _levelSo;
   [SerializeField] private SplineComputer firstSpline;
   [SerializeField] private GameObject trainPrefab;
   [SerializeField] private Transform createdPos;
   [SerializeField] private List<GameObject> trains;
   [SerializeField] private List<GameObject> moveTrains;

   [Header("Timer")][Space(10)]
   [SerializeField] private float timer = 2f;
   private float originalTimer;
   private bool timerBool;
  
   public static ObjectPool Instance { get; private set; }
 
  
   private void Start()
   {
      Instance = this;
      
      originalTimer = timer;
      TrainsCreated();
   }

   void TrainsCreated()
   {
      for (int i = 0; i < 6; i++)
      {
         GameObject go = Instantiate(trainPrefab, createdPos.transform.position,Quaternion.identity);
         Train goTrain = go.GetComponent<Train>();
       
         goTrain.SplineAssignValue(firstSpline);
         goTrain.TrainColorSet(_levelSo.levels[0].colorList[Random.Range(0,_levelSo.levels[0].colorList.Count)]);
         goTrain.TrainSetActiveState(false);
         go.transform.SetParent(transform);
       
         trains.Add(go);
      }
   }

   private void Update()
   {
      // oyun basladıysa kontrolü atılacak
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

   public void ReturnTheObjectToThePool(GameObject go) // station contact to 
   {

      Train tempTrain = go.GetComponent<Train>();
      tempTrain.ResetTrain();
      go.transform.position = createdPos.position;
      trains.Add(go);
      moveTrains.Remove(go);
     tempTrain.TrainSetActiveState(false);




   }
}
