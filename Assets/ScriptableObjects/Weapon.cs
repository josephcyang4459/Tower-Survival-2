using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class Weapon : Item {
    [SerializeField] public WeaponType weaponType;
    [SerializeField] public int damage;
    [SerializeField] public int defaultDamage;
    [SerializeField] public int damagePerLevel;
    [SerializeField] public DamageType damageType;
    [SerializeField] public int atkSpeed;
    [SerializeField] public int knockback;
    [SerializeField] public int knockbackSpeed;
    [SerializeField] public int splash;
    [HideInInspector] public float secondsBetweenAttacks;

    [Header("Ranged Weapon Parameters | Not Required for Melee Weapons")]
    [SerializeField] public int range;
    [SerializeField] public GameObject projectile;
    [HideInInspector] public float trueRange;
}

public enum WeaponType {
    Melee,
    Ranged
}

public enum DamageType {
    Slash,
    Pierce,
    Siege,
    Magic,
    Spikes
}