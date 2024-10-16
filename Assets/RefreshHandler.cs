using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshHandler : MonoBehaviour {
    [SerializeField] public Item refresh;

    public void Reset() {
        refresh.level = 0;
        UpdateCost(refresh.level);
    }

    public void Upgrade(int upgradeAmount = 1) {
        refresh.level += upgradeAmount;
        UpdateCost(refresh.level);
    }

    public void UpdateCost(int refreshLevel) { refresh.goldCost = 100 + (refreshLevel * 100); /* Default refresh cost is 100 */ }
}