using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : ScriptableObject {
    [SerializeField] public int defaultHealth;
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] public int defaultShield;
    [SerializeField] public int shield;
    [SerializeField] public int maxShield;
    [SerializeField] public Sprite sprite;
}
