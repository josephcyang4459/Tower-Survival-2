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
    public float trueRange;
    public float trueAtkSpeed;
    private float rangeToScaleRatio = 112.5f;
    private float timestampFromLastFire;

    public void Reset() {
        level = 0;
        trueRange = range / rangeToScaleRatio;
        trueAtkSpeed = 2 / (1 + (atkSpeed / 100f));
        projectile.GetComponent<ProjectileHandler>().UpdateDamage(level);
        readyToFire = true;
    }

    public void Upgrade() {
        level++;
        projectile.GetComponent<ProjectileHandler>().UpdateDamage(level);
    }

    public void Fire(GameObject target) {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.GetComponent<ProjectileHandler>().target = target;
        readyToFire = false;
        timestampFromLastFire = Time.time;
    }

    public bool WithinRange(GameObject origin, GameObject target) { return Vector3.Distance(origin.transform.position, target.transform.position) < trueRange; }

    public void CheckReadyToFire() {
        if (Time.time - timestampFromLastFire > trueAtkSpeed)
            readyToFire = true;
    }
}
