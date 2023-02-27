using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using UnityEngine;

public class NodeController : MonoBehaviour
{
   public Node node;
  
   public SplineComputer main;
   public SplineComputer connectedMain;
   public SplineComputer connectedMainTwo;
   public SplineComputer contactSpline;
   public int nodeMainPoint;
  
   
   public bool testttt;
   public int clicked;

   private SplineProperties splinePropertiesMain;
   private SplineProperties splinePropertiesConnected;
   private SplineProperties splinePropertiesConnectedTwo;

   private void Start()
   {
      splinePropertiesMain = main.GetComponent<SplineProperties>();
      splinePropertiesConnected = connectedMain.GetComponent<SplineProperties>();
      splinePropertiesConnectedTwo = connectedMainTwo.GetComponent<SplineProperties>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         clicked++;

         if (clicked % 2 == 0)
         {
            node.ClearConnections();
            ResetSplinePos();
            
            contactSpline = connectedMainTwo;
            node.AddConnection(main,splinePropertiesMain.pointIndex);
            node.AddConnection(connectedMainTwo,splinePropertiesConnectedTwo.pointIndex);
         }

         if (clicked % 2 == 1)
         {
            node.ClearConnections();
            ResetSplinePosTwo();
            
            contactSpline = connectedMain;
            node.AddConnection(main,splinePropertiesMain.pointIndex);
            node.AddConnection(connectedMain,splinePropertiesConnected.pointIndex);
           
            //junctionSwitch.SwitchActive();
         }
      }
   }

   private void ResetSplinePos()
   {
     // junctionSwitch.SwitchReset();
      splinePropertiesMain.SetNormalPointPos();
      splinePropertiesConnected.SetNormalPointPos();
   } 
   private void ResetSplinePosTwo()
   {
     // junctionSwitch.SwitchReset();
      splinePropertiesMain.SetNormalPointPos();
      splinePropertiesConnectedTwo.SetNormalPointPos();
   }
}
