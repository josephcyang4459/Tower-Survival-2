using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject {
    [SerializeField] public int level;
    [SerializeField] public int health;
    [SerializeField] public int movementSpeed;
    [SerializeField] public Weapon weapon;
}
