using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Shield : Resource {
    [SerializeField] public UnityEvent damaged;
    [SerializeField] public UnityEvent shieldBreak;

    public override void ReduceResource(int reductionAmount) {
        // The damage exceeds the shield amount
        if (value < reductionAmount) {
            reductionAmount -= value;
            value = 0;
            shieldBreak.Invoke();

            // Leftover damage is taken from health
            gameObject.GetComponent<Health>().ReduceResource(reductionAmount);
        } else {
            value -= reductionAmount;
            damaged.Invoke();
        }
    }

    public override void GainResource(int gainAmount) { value = (value + gainAmount >= maxValue) ? maxValue : gainAmount; }
}
