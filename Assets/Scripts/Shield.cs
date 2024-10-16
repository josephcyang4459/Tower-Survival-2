using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {
    [SerializeField] public int defaultValue;
    [SerializeField] public int minValue = 0;
    [SerializeField] public UnityEvent damaged;
    [SerializeField] public UnityEvent shieldBreak;
    [Header("Values below are for tracking purposes")]
    [SerializeField] public int value;
    [SerializeField] public int maxValue;

    public void TakeDamage(int damage) {
        value -= damage;
        damaged.Invoke();

        if (value <= 0)
            shieldBreak.Invoke();
    }

    public void Reset() {
        minValue = 0;
        maxValue = defaultValue;
        value = maxValue;
    }
}
