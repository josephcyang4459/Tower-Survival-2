using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponsTest : MonoBehaviour {
    [SerializeField] TMP_Text text;
    [SerializeField] PlayerHandler playerHandler;

    void Start() {
        playerHandler = PlayerHandler.inst;
    }

    // Update is called once per frame
    void Update() {
        text.text = "Weapons\n";
        foreach (WeaponHandler weaponhandler in playerHandler.weaponhandlers) {
            text.text += weaponhandler.name + "\n";
        }
    }
}
