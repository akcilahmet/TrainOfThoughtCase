using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTriggerManager : MonoBehaviour
{
    private Train _train;

    private void Start()
    {
        _train = GetComponent<Train>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("station"))
        {
            Debug.Log("station reached");
            Debug.Log("train type: " +_train.trainType.ToString()+ "station type: " + other.gameObject.GetComponent<Station>()._type);
            
            if (_train.trainType==(other.gameObject.GetComponent<Station>()._type.ToString()))
            {
                GameController.Instance.ScoreUpdate(+1);
            }
            else
            {
                GameController.Instance.ScoreUpdate(-1);

            }
            ObjectPool.Instance.ReturnTheObjectToThePool(this.gameObject);
        }
    }
}
