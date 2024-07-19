using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyHandler : MonoBehaviour {
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] public Sprite sprite;
    [SerializeField] public int movementSpeed;
    [SerializeField] Enemy DefaultStats;

    // Start is called before the first frame update
    void Start() {
        health = DefaultStats.health;
        maxHealth = DefaultStats.maxHealth;
        sprite = DefaultStats.sprite;
        movementSpeed = DefaultStats.movementSpeed;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, PlayerHandler.inst.transform.position, movementSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public void Die() {
        PlayerHandler.inst.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
