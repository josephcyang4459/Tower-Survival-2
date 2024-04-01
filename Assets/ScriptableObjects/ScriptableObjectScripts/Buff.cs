using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "ScriptableObjects/Buff")]
public class Buff : ScriptableObject {
    [SerializeField] public int level;
    [SerializeField] public int flatRate;
    [SerializeField] public int percentRate;
}
