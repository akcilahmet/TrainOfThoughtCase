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

    private void Update()
    {
       // düğüme ulaşıldığında yol bağlantılarını alalım
       //düğümün sahip olduğu yolların hangisi aktif onu öğren
       // node bulunduğu point noktasının değeri alınacak
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("node"))
        {
            Debug.Log("nodeeeeee contact to ");
            OnNodePassed(other.gameObject.GetComponent<NodeController>());
        }
    }

    private void OnNodePassed(NodeController nodeController)
    {
     

      
        
        double nodePercent = (double) nodeController.nodeMainPoint / (follower.spline.pointCount - 1);
        double followerPercent = follower.UnclipPercent(follower.result.percent);
        float distancePastNode = follower.spline.CalculateLength(nodePercent, followerPercent);

      
        
        follower.spline = nodeController.contactSpline;
        
        double newnodePercent = (double)0/ ( nodeController.contactSpline.pointCount - 1);
        double newPercent =  nodeController.contactSpline.Travel(newnodePercent, distancePastNode, follower.direction);
        follower.SetPercent(newPercent);
    }
}
