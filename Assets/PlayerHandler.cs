using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(Health))]
[RequireComponent(typeof(Shield))]
public class PlayerHandler : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] GameObject enemiesList;
    [SerializeField] public List<WeaponHandler> weaponhandlers;
    public List<GameObject> enemies = new List<GameObject>();
    public static PlayerHandler inst;
    public UnityEvent playerDamaged;

    // Start is called before the first frame update
    void Start() {
        if (inst == null) {
            inst = this;
            DontDestroyOnLoad(inst);
        } else {
            Destroy(gameObject);
        }

        Reset();
        for (int i = 0; i < enemiesList.transform.childCount; i++)
            enemies.Add(enemiesList.transform.GetChild(i).gameObject);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (enemies.Count > 0)
            foreach (WeaponHandler weaponhandler in weaponhandlers) {
                if (enemies[0] != null) {
                    if (weaponhandler.WithinRange(gameObject, enemies[0]) && weaponhandler.readyToFire) {
                        weaponhandler.Fire(enemies[0]);
                    }
                }
            }
    }

    public void UpgradeWeapon(Weapon weapon) {
        for (int i = 0; i <  weaponhandlers.Count; i++) {
            if (weaponhandlers[i].weapon == weapon) {
                weaponhandlers[i].Upgrade();
                return;
            }
        }

        WeaponHandler newWeaponHandler = gameObject.AddComponent<WeaponHandler>();
        newWeaponHandler.weapon = weapon;
        newWeaponHandler.Reset();
        newWeaponHandler.Upgrade();
        weaponhandlers.Add(newWeaponHandler);
    }

    private void Reset() {
        GetComponent<Health>().Reset();
        GetComponent<Shield>().Reset();

        player.income = player.defaultIncome;

        foreach (WeaponHandler weaponhandler in weaponhandlers) weaponhandler.Reset();
        weaponhandlers = new List<WeaponHandler>();
    }

    public void Die() { Destroy(gameObject); }

    private void OnDestroy() { foreach (WeaponHandler weaponhandler in weaponhandlers) weaponhandler.Reset(); }
}
