using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTriggerManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("station"))
        {
            Debug.Log("station reached");
            ObjectPool.Instance.ReturnTheObjectToThePool(this.gameObject);
        }
    }
}
