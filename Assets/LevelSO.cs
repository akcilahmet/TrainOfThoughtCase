using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO")]
public class LevelSO : ScriptableObject
{
    public List<Level> levels;
}

[Serializable]
public class Level
{
    public int trainCount;
    public List<Color> colorList;
    public GameObject levelPrefab;
  

}
