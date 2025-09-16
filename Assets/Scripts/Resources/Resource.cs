using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class Resource : MonoBehaviour {
    [SerializeField] public int value;
    [SerializeField] public int maxValue;
    [SerializeField] public int minValue;
    [SerializeField] public int defaultValue;
    [SerializeField] public int defaultMaxValue;
    [SerializeField] public int defaultMinValue;

    abstract public void ReduceResource(int reductionAmount);

    abstract public void GainResource(int gainAmount);

    public void Reset() {
        value = defaultValue;
        maxValue = defaultMaxValue;
        minValue = defaultMinValue;
    }
}
