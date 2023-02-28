using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : TrainFeatures
{
    public TrainType trainType;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer.material.color = trainColor;
    }
}
