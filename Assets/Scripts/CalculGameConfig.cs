using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CalculGameConfig", order = 1)]
public class CalculGameConfig : ScriptableObject
{
    public List<Area> areas = new List<Area>();
}

