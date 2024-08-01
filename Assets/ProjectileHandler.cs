using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {
    [SerializeField] public int projectileSpeed;
    [SerializeField] public int damage;
    [SerializeField] public int knockback;
    [SerializeField] public float knockbackSpeed;
    [SerializeField] public Sprite sprite;
    [SerializeField] public GameObject target;
    [SerializeField] public Vector3 targetPosition;
    [SerializeField] public Collider2D col;
    [SerializeField] Projectile defaultStats;

    // Start is called before the first frame update
    void Start() {
        projectileSpeed = defaultStats.projectileSpeed;
        knockback = defaultStats.knockback;
        knockbackSpeed = defaultStats.knockbackSpeed;
        sprite = defaultStats.sprite;
        targetPosition = target.transform.position;
    }

    void Update() {
        if (target != null) {
            targetPosition = target.transform.position;
            if (col.IsTouching(target.GetComponent<Collider2D>())) { DealDamage(target); }
            else { MoveTowardsTarget(target.transform.position); }
        } else {
            if (transform.position == targetPosition) { Destroy(gameObject); }
            else { MoveTowardsTarget(targetPosition); }
        }
    }

    public void UpdateDamage(int weaponLevel) { damage = defaultStats.defaultDamage + (weaponLevel * defaultStats.damagePerLevel); }

    public void DealDamage(GameObject target) {
        target.GetComponent<EnemyHandler>().TakeDamage(damage);
        Destroy(gameObject);
    }

    public void MoveTowardsTarget(Vector3 target) {
        var step = projectileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void Reset() {
        projectileSpeed = defaultStats.projectileSpeed;
        damage = defaultStats.defaultDamage;
        knockback = defaultStats.knockback;
        knockbackSpeed = defaultStats.knockbackSpeed;
        sprite = defaultStats.sprite;
    }
}
