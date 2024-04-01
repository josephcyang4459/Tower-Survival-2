using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower")]
public class Tower : ScriptableObject {
    [SerializeField] public int defaultHealth;
    [SerializeField] public int health;
    [SerializeField] public int defaultShield;
    [SerializeField] public int shield;
    [SerializeField] public int defaultIncome;
    [SerializeField] public int income;
}
