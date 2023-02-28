using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : StationFeatures
{
    public StationType _type;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer.material.color = stationColor;
    }
}
