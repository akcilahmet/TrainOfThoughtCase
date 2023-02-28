using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class Train : TrainFeatures
{
   
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private SplineFollower splineFollower;
  

    
    public void TrainColorSet(Color tempColor)
    {
        _meshRenderer.material.color = tempColor;
        
    }
    
    public void SplineAssignValue(SplineComputer targetSpline)
    {
        splineFollower.enabled = true;
        splineFollower.SetPercent(0);
        splineFollower.spline = targetSpline;
        

    }

    public void TrainSetActiveState(bool temp)
    {
        gameObject.SetActive(temp);
    
    }

    public void ResetTrain()
    {
        
        splineFollower.spline = null;
        splineFollower.enabled = false;
    }
  
    
}
