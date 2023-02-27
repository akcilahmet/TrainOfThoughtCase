using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    private SplineFollower follower;
    public int splineIndex;
   

    private SplineTracer.NodeConnection temp;
    void Start()
    {
        follower = GetComponent<SplineFollower>();
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("node"))
        {
            OnNodePassed(other.gameObject.GetComponent<NodeController>());
        }
    }

    private void OnNodePassed(NodeController nodeController)
    {
        
        double nodePercent = (double) nodeController.nodeMainPoint / (follower.spline.pointCount - 1);
        double followerPercent = follower.UnclipPercent(follower.result.percent);
        float distancePastNode = follower.spline.CalculateLength(nodePercent, followerPercent);
        Debug.Log("follower percent: " +followerPercent);
      
        
        follower.spline = nodeController.contactSpline;
        
        double newnodePercent = (double)0/ ( nodeController.contactSpline.pointCount-1 );
        double newPercent =  nodeController.contactSpline.Travel(newnodePercent, distancePastNode, follower.direction);
        Debug.Log("new percent: " +newPercent);

        follower.SetPercent(newPercent);
    }
}
