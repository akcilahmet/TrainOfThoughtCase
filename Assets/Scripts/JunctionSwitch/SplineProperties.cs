using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SplineProperties : MonoBehaviour
{
   [SerializeField] private bool enterValueManuelPos;
   [SerializeField] private bool orginalTangetUse;
   private SplineComputer _splineComputer;
   public int pointIndex;
   public int JunctionpointTwo;
   public int JunctionpointTree;
  
   [Header("Tangent set")] [Space(10)]
   public Vector3 originalTangent;
   public Vector3 originalTangent2;
   [SerializeField]private Vector3 targetTangent;
   [SerializeField]private Vector3 targetTangent2;
   [SerializeField]private Vector3 originalPos;
   private void Start()
   {
      _splineComputer = GetComponent<SplineComputer>();
    

      if (!enterValueManuelPos)
      {
         originalTangent2 = _splineComputer.GetPointTangent2(pointIndex);
         originalTangent = _splineComputer.GetPointTangent(pointIndex);
         originalPos = _splineComputer.GetPointPosition(pointIndex);
      }
      
   }

 
   public void SetNormalPointPos()
   {
     
         _splineComputer.SetPointNormal(pointIndex,Vector3.zero);
         _splineComputer.SetPointPosition(pointIndex,originalPos);
         _splineComputer.SetPointTangents(pointIndex,originalTangent,originalTangent2,SplineComputer.Space.World);
      
     
      
   }
   public void SetSwitchPoint()
   {
     
         _splineComputer.SetPointNormal(pointIndex,Vector3.zero);
         if (!orginalTangetUse)
         {
            _splineComputer.SetPointTangents(pointIndex,targetTangent,targetTangent2,SplineComputer.Space.World);

         }
         else
         {
            _splineComputer.SetPointTangents(pointIndex,originalTangent,originalTangent2,SplineComputer.Space.World);

         }
      
     
   }
}
