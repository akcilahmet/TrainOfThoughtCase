using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using UnityEngine;
using UnityEngine.Serialization;

public class NodeController : MonoBehaviour
{
   [SerializeField]private Node node;
  
   [SerializeField]private SplineComputer main;
   [SerializeField]private SplineComputer junctionToConnected;
   [SerializeField]private SplineComputer junctionToConnectedTwo;
   
   public SplineComputer contactSpline;
   public int nodeMainPoint;
   
   private int clicked;

   private SplineProperties splinePropertiesMain;
   private SplineProperties splinePropertiesConnected;
   private SplineProperties splinePropertiesConnectedTwo;

   [Header("Scripts")] [Space(10)] [SerializeField]
   private JunctionSwitchTriggerController _junctionSwitchTriggerController;

   private void Start()
   {
      splinePropertiesMain = main.GetComponent<SplineProperties>();
      splinePropertiesConnected = junctionToConnected.GetComponent<SplineProperties>();
      splinePropertiesConnectedTwo = junctionToConnectedTwo.GetComponent<SplineProperties>();
      
   }

   private void Update()
   {
      if (_junctionSwitchTriggerController.contactTo)
      {
         if (Input.GetMouseButtonDown(0))
         {
            clicked++;

            if (clicked % 2 == 0)
            {
               ResetJunction();
             
              
            
               JunctionSwitchChanged(main,splinePropertiesMain,
                  junctionToConnectedTwo,splinePropertiesConnectedTwo);
            }

            if (clicked % 2 == 1)
            {
               ResetJunction();
              
              

               JunctionSwitchChanged(main,splinePropertiesMain,
                  junctionToConnected,splinePropertiesConnected);
            }
         }
      }
   }

   void JunctionSwitchChanged(SplineComputer tempMain,SplineProperties tempMainProperties,
      SplineComputer tempJunctionToConnected,SplineProperties tempJunctionConnectedProperties)
   {
      contactSpline = tempJunctionToConnected;
      node.AddConnection(tempMain,tempMainProperties.pointIndex);
      node.AddConnection(tempJunctionToConnected,tempJunctionConnectedProperties.pointIndex);
      tempJunctionConnectedProperties.SetSwitchPoint();
   }

   private void ResetJunctionToConnectedSpline()
   {
      splinePropertiesMain.SetNormalPointPos();
      splinePropertiesConnected.SetNormalPointPos();
   } 
   private void ResetJunctionToConnectedSplineTwo()
   {
      splinePropertiesMain.SetNormalPointPos();
      splinePropertiesConnectedTwo.SetNormalPointPos();
   }

   private void ResetJunction()
   {
      node.ClearConnections();
      splinePropertiesMain.SetNormalPointPos();
      splinePropertiesConnected.SetNormalPointPos();
      splinePropertiesConnectedTwo.SetNormalPointPos();
   }
}
