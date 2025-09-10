using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(Health))]
[RequireComponent(typeof(Shield))]
[RequireComponent(typeof(RefreshHandler))]
public class PlayerHandler : MonoBehaviour {
    [SerializeField] public Player player;
    [SerializeField] GameObject enemiesList;
    [SerializeField] public List<WeaponHandler> weaponhandlers;
    [SerializeField] public List<BuffHandler> buffhandlers;
    public List<GameObject> enemies = new List<GameObject>();
    public static PlayerHandler inst { get; private set; }

    private void Awake() {
        if (inst == null) {
            inst = this;
            DontDestroyOnLoad(this);
        } else
            Destroy(this);
    }

    void Start() {
        Reset();
        gameObject.GetComponent<Health>().death.AddListener(Die);

        for (int i = 0; i < enemiesList.transform.childCount; i++)
            enemies.Add(enemiesList.transform.GetChild(i).gameObject);
    }

    void FixedUpdate() {
        if (enemies.Count > 0)
            foreach (WeaponHandler weaponhandler in weaponhandlers)
                if (enemies[0] != null)
                    if (weaponhandler.WithinRange(gameObject, enemies[0]) && weaponhandler.readyToFire)
                        weaponhandler.Fire(enemies[0]);
    }

    public void UpgradeItem(ScriptableObject item) {
        if (item.GetType() == typeof(Weapon)) {
            UpgradeWeapon((Weapon)item);
        }
        else if (item.GetType() == typeof(Buff)) {
            //This is where you would upgrade a buff
            UpgradeBuff((Buff)item);
        }
        else {
            // This means that it's neither a weapon or buff, which the only thing would be the refresh item
            UpgradeRefresh();
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

    public void UpgradeBuff(Buff buff) {
        for (int i = 0; i < buffhandlers.Count; i++) {
            if (buffhandlers[i].buff == buff) {
                buffhandlers[i].Upgrade();
                return;
            }
        }

        BuffHandler newBuffHandler = gameObject.AddComponent<BuffHandler>();
        newBuffHandler.buff = buff;
        newBuffHandler.Reset();
        newBuffHandler.Upgrade();
        buffhandlers.Add(newBuffHandler);
    }

    public void UpgradeRefresh() { gameObject.GetComponent<RefreshHandler>().Upgrade(); }

    private void Reset() {
        GetComponent<Health>().Reset();
        GetComponent<Shield>().Reset();
        player.income = player.defaultIncome;
        ResetWeapons();
        ResetBuffs();
        GetComponent<RefreshHandler>().Reset();
    }

    private void ResetWeapons() {
        foreach (WeaponHandler weaponhandler in weaponhandlers) weaponhandler.Reset();
        weaponhandlers = new List<WeaponHandler>();
    }

    private void ResetBuffs() {
        foreach (BuffHandler buffHandler in buffhandlers) buffHandler.Reset();
        buffhandlers = new List<BuffHandler>();
    }

    public void Die() {
        StartCoroutine(SlowDownTimeOnDeath(.5f, .05f, 10));
        ResetWeapons();
        ResetBuffs();
    }

    IEnumerator SlowDownTimeOnDeath(float startTimeScale, float endTimeScale, int duration) {
        Time.timeScale = startTimeScale;
        float intervalTimeScaleReduction = (Time.timeScale - endTimeScale) / duration;

        while (Time.timeScale > endTimeScale + intervalTimeScaleReduction) {
            Time.timeScale -= intervalTimeScaleReduction;
            yield return new WaitForSeconds(.1f);
        }

        Time.timeScale = endTimeScale;
    }

    private void OnDestroy() {
        foreach (WeaponHandler weaponhandler in weaponhandlers) weaponhandler.Reset();
        foreach (BuffHandler buffhandler in buffhandlers) buffhandler.Reset();
    }
}
