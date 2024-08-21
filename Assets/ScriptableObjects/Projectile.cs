using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile")]
public class Projectile : ScriptableObject {
    [SerializeField] public int projectileSpeed;
    [SerializeField] public Sprite sprite;
}
