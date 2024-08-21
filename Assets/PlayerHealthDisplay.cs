using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour {
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Slider shieldBarSlider;
    [SerializeField] Health playerHealth;
    [SerializeField] Shield playerShield;

    // Start is called before the first frame update
    void Start() {
        Reset();
    }

    private void UpdateHealthBar() {
        healthBarSlider.value = (float) playerHealth.value / playerHealth.maxValue;
    }

    private void UpdateShieldBar() {
        shieldBarSlider.value = (float) playerShield.value / playerShield.maxValue;
    }

    void Reset() {
        PlayerHandler.inst.playerDamaged.AddListener(UpdateHealthBar);
        PlayerHandler.inst.playerDamaged.AddListener(UpdateShieldBar);
    }

    void OnDestroy() {
        PlayerHandler.inst.playerDamaged.RemoveListener(UpdateHealthBar);
        PlayerHandler.inst.playerDamaged.RemoveListener(UpdateShieldBar);
    }
}
