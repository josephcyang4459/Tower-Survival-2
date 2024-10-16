using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour {
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Slider shieldBarSlider;
    [SerializeField] Health playerHealth;
    [SerializeField] Shield playerShield;
    [SerializeField] TMP_Text overlayText;

    void Start() {
        Reset();

        playerHealth.damaged.AddListener(UpdateHealthBar);
        playerShield.damaged.AddListener(UpdateShieldBar);
        playerHealth.damaged.AddListener(UpdateOverlayText);
        playerShield.damaged.AddListener(UpdateOverlayText);
    }

    private void UpdateHealthBar() {
        healthBarSlider.value = (float) playerHealth.value / playerHealth.maxValue;
    }

    private void UpdateShieldBar() {
        shieldBarSlider.value = (float) playerShield.value / playerShield.maxValue;
    }
    
    private void UpdateOverlayText() {
        overlayText.text = (playerHealth.value + playerShield.value) + " / " + playerHealth.maxValue;
    }

    void Reset() {
        UpdateHealthBar();
        UpdateShieldBar();
        UpdateOverlayText();
    }

    void OnDestroy() {
        playerHealth.damaged.RemoveListener(UpdateHealthBar);
        playerShield.damaged.RemoveListener(UpdateShieldBar);
        playerHealth.damaged.RemoveListener(UpdateOverlayText);
        playerShield.damaged.RemoveListener(UpdateOverlayText);
    }
}
