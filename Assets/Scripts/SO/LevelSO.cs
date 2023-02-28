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
    public bool unlocked;
    public int trainCount;
    public List<Color> colorList;
    public List<string> trainType;
    public List<(int, string)> mylist;
    public GameObject levelPrefab;
    public GameObject cam;

}
