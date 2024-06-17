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
    [SerializeField] public GameObject target;
    [SerializeField] public Collider2D col;
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
        if (col.IsTouching(target.GetComponent<Collider2D>())) { DealDamage(damage, target); }
        else { MoveTowardsTarget(); }
    }

    public void UpdateDamage(int weaponLevel) { damage = DefaultStats.defaultDamage + (weaponLevel * DefaultStats.damagePerLevel); }

    public void DealDamage(int damage, GameObject target) {
        target.GetComponent<EnemyHandler>().TakeDamage(damage);
        Destroy(gameObject);
    }

    public void MoveTowardsTarget() {
        var step = projectileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
