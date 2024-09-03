using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Buff", menuName = "ScriptableObjects/Buff")]
public class Buff : Item {
    [SerializeField] public int flatRate;
    [SerializeField] public int percentRate;
}
