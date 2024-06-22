using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponsTest : MonoBehaviour {
    [SerializeField] TMP_Text text;
    [SerializeField] Player player;

    // Update is called once per frame
    void Update() {
        text.text = "Weapons\n";
        foreach (Weapon w in player.weapons) {
            text.text += w.name + "\n";
        }
    }
}
