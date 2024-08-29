using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(Health))]
[RequireComponent(typeof(Shield))]
public class PlayerHandler : MonoBehaviour {
    [SerializeField] public Player player;
    [SerializeField] GameObject enemiesList;
    [SerializeField] public List<WeaponHandler> weaponhandlers;
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
        else {
            //This is where you would upgrade a buff
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
        ResetWeapons();
    }

    private void ResetWeapons() {
        foreach (WeaponHandler weaponhandler in weaponhandlers) weaponhandler.Reset();
        weaponhandlers = new List<WeaponHandler>();
    }

    public void Die() {
        StartCoroutine(SlowDownTimeOnDeath(.5f, .05f, 10));
        ResetWeapons();
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

    private void OnDestroy() { foreach (WeaponHandler weaponhandler in weaponhandlers) weaponhandler.Reset(); }
}
