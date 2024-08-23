using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponsTest : MonoBehaviour {
    [SerializeField] TMP_Text text;

    // Update is called once per frame
    void Update() {
        text.text = "Weapons\n";
        foreach (WeaponHandler weaponhandler in PlayerHandler.inst.weaponhandlers)
            text.text += weaponhandler.weapon.name + "\n";
    }
}
