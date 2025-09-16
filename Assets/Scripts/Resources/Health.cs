using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : Resource {
    [SerializeField] public UnityEvent damaged;
    [SerializeField] public UnityEvent death;

    public override void ReduceResource(int reductionAmount) {
        value -= reductionAmount;
        damaged.Invoke();

        if (value <= 0) death.Invoke();
    }

    public override void GainResource(int gainAmount) { value = (value + gainAmount >= maxValue) ? maxValue : gainAmount; }
}
