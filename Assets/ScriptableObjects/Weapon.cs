using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject {
    [SerializeField] public WeaponType weaponType;
    [SerializeField] public string description;
    [SerializeField] public int level;
    [SerializeField] public int maxLevel;
    [SerializeField] public int atkSpeed;
    [SerializeField] public int goldCost;
    [SerializeField] public int damage;
    [SerializeField] public int defaultDamage;
    [SerializeField] public int damagePerLevel;
    [SerializeField] public int knockback;
    [SerializeField] public int knockbackSpeed;
    [SerializeField] public int splash;
    [HideInInspector] public float secondsBetweenAttacks;

    [Header("Ranged Weapon Parameters | Not Required for Melee Weapons")]
    [SerializeField] public int range;
    [SerializeField] public GameObject projectile;
    [HideInInspector] public float trueRange;

 public override string ToString() {
        Match match = Regex.Match(name, @"(?<type>[A-Z][a-z]+)(?<name>([A-Z][a-z]+)+)");
        return match.Groups["name"].Value;
    }
}

public enum WeaponType {
    Melee,
    Ranged
}