using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void FixedUpdate() { }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public void Die() { Destroy(this); }
}
