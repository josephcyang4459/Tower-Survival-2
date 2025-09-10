using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Buff", menuName = "ScriptableObjects/Buff")]
public class Buff : Item {
    [SerializeField] public BuffType buffType;
    [SerializeField] public int flatRate;
    [SerializeField] public int percentRate;
    [SerializeField] public int defaultFlatRate;
    [SerializeField] public int defaultPercentRate;
    [SerializeField] public int flatRatePerLevel;
    [SerializeField] public int percentRatePerLevel;
}

public enum BuffType {
    Damage,
    Gold,
    Health,
    Other
}