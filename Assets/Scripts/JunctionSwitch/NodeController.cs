using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using UnityEngine;
using UnityEngine.Serialization;

public class NodeController : MonoBehaviour
{
   [SerializeField] private bool junctionOne;
   [SerializeField] private bool junctionTwo;
   [SerializeField] private bool junctionTree;
   [SerializeField] private bool junctionFour;
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
      if (junctionOne)
      {
         contactSpline = tempJunctionToConnected;
         node.AddConnection(tempMain,tempMainProperties.pointIndex);
         node.AddConnection(tempJunctionToConnected,tempJunctionConnectedProperties.pointIndex);
         tempJunctionConnectedProperties.SetSwitchPoint();
      }

      if (junctionTwo)
      {
         contactSpline = tempJunctionToConnected;
         node.AddConnection(tempMain,tempMainProperties.JunctionpointTwo);
         node.AddConnection(tempJunctionToConnected,tempJunctionConnectedProperties.JunctionpointTwo);
         tempJunctionConnectedProperties.SetSwitchPoint();
      }

      if (junctionTree)
      {
         contactSpline = tempJunctionToConnected;
         node.AddConnection(tempMain,tempMainProperties.JunctionpointTree);
         node.AddConnection(tempJunctionToConnected,tempJunctionConnectedProperties.JunctionpointTree);
         tempJunctionConnectedProperties.SetSwitchPoint();
      }
      if (junctionFour)
      {
         contactSpline = tempJunctionToConnected;
         node.AddConnection(tempMain,tempMainProperties.JunctionpointFour);
         node.AddConnection(tempJunctionToConnected,tempJunctionConnectedProperties.JunctionpointFour);
         tempJunctionConnectedProperties.SetSwitchPoint();
      }
     
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
