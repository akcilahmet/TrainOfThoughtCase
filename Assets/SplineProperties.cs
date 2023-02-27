using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SplineProperties : MonoBehaviour
{
   [SerializeField] private bool orginalTangetUse;
   private SplineComputer _splineComputer;
   public int pointIndex;
  
   [Header("Tangent set")] [Space(10)]
   private Vector3 originalTangent;
   private Vector3 originalTangent2;
   [SerializeField]private Vector3 targetTangent;
   [SerializeField]private Vector3 targetTangent2;
   [SerializeField]private Vector3 originalPos;
   private void Start()
   {
      _splineComputer = GetComponent<SplineComputer>();
      originalTangent = _splineComputer.GetPointTangent(0);
      originalTangent2 = _splineComputer.GetPointTangent2(0);
      originalPos = _splineComputer.GetPointPosition(0);
   }

 
   public void SetNormalPointPos()
   {
      _splineComputer.SetPointNormal(0,Vector3.zero);
      _splineComputer.SetPointPosition(0,originalPos);
      _splineComputer.SetPointTangents(0,originalTangent,originalTangent2,SplineComputer.Space.World);
      
   }
   public void SetSwitchPoint()
   {
      _splineComputer.SetPointNormal(0,Vector3.zero);
      if (!orginalTangetUse)
      {
         _splineComputer.SetPointTangents(0,targetTangent,targetTangent2,SplineComputer.Space.World);

      }
      else
      {
         _splineComputer.SetPointTangents(0,originalTangent,originalTangent2,SplineComputer.Space.World);

      }
   }
}
