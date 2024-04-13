using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject {
    [SerializeField] public string description;
    [SerializeField] public int level;
    [SerializeField] public int maxLevel;
    [SerializeField] public int health;
    [SerializeField] public int movementSpeed;
    [SerializeField] public int spawnPointCost;
    [SerializeField] public Weapon weapon;
}
