using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionSwitchTriggerController : MonoBehaviour
{
   public bool contactTo;
   [SerializeField] private LayerMask mask;
   public Camera camera;
   private Ray ray;
   private RaycastHit hit;
   

   private void Update()
   {
      ray = camera.ScreenPointToRay(Input.mousePosition);
      
      if (Physics.Raycast(ray, out hit,Mathf.Infinity,mask)) {

         contactTo = true;
      }
      else
      {
         {
            contactTo = false;
         }
      }
   }
}
