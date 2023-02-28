using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelIndex;
    public static LevelManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
       
    }
}
