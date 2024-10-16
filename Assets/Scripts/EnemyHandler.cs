using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Health))]

public class EnemyHandler : MonoBehaviour {
    [SerializeField] public Sprite sprite;
    [SerializeField] public int movementSpeed;
    [SerializeField] public Enemy defaultStats;
    [SerializeField] WeaponHandler weaponhandler;

    void Start() {
        gameObject.GetComponent<Health>().death.AddListener(Die);
        Reset();
    }

    void Update() {
        GameObject player = PlayerHandler.inst.gameObject;

        // If enemy has ranged weapon
        if (weaponhandler.weapon.weaponType == WeaponType.Ranged) {
            if (weaponhandler.WithinRange(gameObject, player)) {
                if (weaponhandler.readyToFire) weaponhandler.Fire(player);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            }
        }
            
        // If enemy has melee weapon
        else {
            if (gameObject.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>())) {
                if (weaponhandler.readyToFire) weaponhandler.Fire(player);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            }
        }
    }

    void Reset() {
        GetComponent<Health>().Reset();
        sprite = defaultStats.sprite;
        movementSpeed = defaultStats.movementSpeed;

        weaponhandler.Reset();
    }

    private void Die() { Destroy(gameObject); }

    private void OnDestroy() {
        gameObject.GetComponent<Health>().death.RemoveListener(Die);
        PlayerHandler.inst.enemies.Remove(gameObject);
    }
}
