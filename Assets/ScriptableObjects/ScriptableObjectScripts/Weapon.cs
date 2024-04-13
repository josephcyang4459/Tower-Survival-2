using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject {
    [SerializeField] public string description;
    [SerializeField] public int level;
    [SerializeField] public int maxLevel;
    [SerializeField] public int atkSpeed;
    [SerializeField] public int range;
    [SerializeField] public int goldCost;
    [SerializeField] public Projectile projectile;
}
