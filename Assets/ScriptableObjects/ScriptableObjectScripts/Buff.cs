using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Buff", menuName = "ScriptableObjects/Buff")]
public class Buff : ScriptableObject {
    [SerializeField] public string description;
    [SerializeField] public int level;
    [SerializeField] public int maxLevel = 999;
    [SerializeField] public int flatRate;
    [SerializeField] public int percentRate;
    [SerializeField] public int goldCost;
}
