using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHandler : MonoBehaviour {
    [SerializeField] public Buff buff;

    public void Reset() {
        buff.level = 0;
        UpdateBuff(buff.level);
    }

    public void Upgrade(int upgradeAmount = 1) {
        buff.level += upgradeAmount;
        UpdateBuff(buff.level);
    }

    public void UpdateBuff(int buffLevel) {
        buff.flatRate = buff.defaultFlatRate + (buffLevel * buff.flatRatePerLevel);
        buff.percentRate = buff.defaultPercentRate + (buffLevel * buff.percentRatePerLevel);
    }
}
