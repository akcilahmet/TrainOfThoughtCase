using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SplineProperties : MonoBehaviour
{
   private SplineComputer _splineComputer;
   public int pointIndex;
   public Vector3 splinePointFirstPos;

   private void Start()
   {
      _splineComputer = GetComponent<SplineComputer>();
      splinePointFirstPos=_splineComputer.GetPoint(pointIndex).position;
      
   }

   public Vector3 GetPointPos(int index)
   {
      return _splineComputer.GetPoint(index).position;
   }

   public void SetNormalPointPos()
   {
     
      _splineComputer.SetPointPosition(pointIndex,splinePointFirstPos);
   }
}
