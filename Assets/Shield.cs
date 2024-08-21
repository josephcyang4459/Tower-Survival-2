using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    [SerializeField] public int defaultValue;
    [SerializeField] public int value;
    [SerializeField] public int maxValue;

    public void TakeDamage(int damage) {
        value -= damage;
    }

    public void Reset() {
        maxValue = defaultValue;
        value = maxValue;
    }
}
