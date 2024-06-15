using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {
    [SerializeField] public int projectileSpeed;
    [SerializeField] public int damage;
    [SerializeField] public int knockback;
    [SerializeField] public float knockbackSpeed;
    [SerializeField] public Sprite sprite;
    [SerializeField] public Transform target;
    [SerializeField] Projectile DefaultStats;

    // Start is called before the first frame update
    void Start() {
        projectileSpeed = DefaultStats.projectileSpeed;
        damage = DefaultStats.defaultDamage;
        knockback = DefaultStats.knockback;
        knockbackSpeed = DefaultStats.knockbackSpeed;
        sprite = DefaultStats.sprite;
    }

    void Update() {
        moveTowardsTarget();
    }

    public void updateDamage(int weaponLevel) { damage = DefaultStats.defaultDamage + (weaponLevel * DefaultStats.damagePerLevel); }

    public void moveTowardsTarget() {
        var step = projectileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
