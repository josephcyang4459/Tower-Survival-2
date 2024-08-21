using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] public int defaultValue;
    [SerializeField] public int value;
    [SerializeField] public int maxValue;

    public void TakeDamage(int damage) {
        value -= damage;

        if (value <= 0)
            Die();
    }

    public void Die() {
        Destroy(gameObject);
    }

    public void Reset() {
        maxValue = defaultValue;
        value = maxValue;
    }
}
