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
    [SerializeField] public GameObject projectile;
    public bool readyToFire = true;

    public void Reset() {
        level = 0;
        projectile.GetComponent<ProjectileHandler>().updateDamage(level);
        readyToFire = true;
    }

    public void UpgradeWeapon() {
        level++;
        projectile.GetComponent<ProjectileHandler>().updateDamage(level);
    }

    public void fireProjectile(GameObject target) {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.GetComponent<ProjectileHandler>().target = target.transform;
    }
}
