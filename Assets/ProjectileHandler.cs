using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {
    [SerializeField] public int projectileSpeed;
    [SerializeField] public Sprite sprite;
    [SerializeField] public Collider2D col;
    [SerializeField] public WeaponHandler sourceWeapon;
    [HideInInspector] public GameObject target;
    Vector3 targetPosition;
    public Projectile projectile;

    void Start() {
        projectileSpeed = projectile.projectileSpeed;
        sprite = projectile.sprite;
        targetPosition = target.transform.position;
    }

    void Update() {
        if (target != null) {
            targetPosition = target.transform.position;
            if (col.IsTouching(target.GetComponent<Collider2D>())) {
                sourceWeapon.DealDamage(target);
                Destroy(gameObject);
            } else { MoveTowardsTarget(targetPosition); }
        } else {
            if (transform.position == targetPosition) { Destroy(gameObject); }
            else { MoveTowardsTarget(targetPosition); }
        }
    }

    public void MoveTowardsTarget(Vector3 target) {
        var step = projectileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void Reset() {
        projectileSpeed = projectile.projectileSpeed;
        sprite = projectile.sprite;
    }
}
