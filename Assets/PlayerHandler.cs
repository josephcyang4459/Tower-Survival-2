using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject EnemiesList;
    private List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        Reset();

        for (int i = 0; i < EnemiesList.transform.childCount; i++)
            enemies.Add(EnemiesList.transform.GetChild(i).gameObject);

        foreach (Weapon w in player.weapons)
            w.Reset();

        //TODO Need to stop hard crash when enemy dies and there's another projectile targeting it. EX: When many axes are going to hit goblin and the first axe kills the goblin.
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (enemies.Count > 0)
            foreach (Weapon w in player.weapons) {
                w.CheckReadyToFire();

                if (w.WithinRange(gameObject, enemies[0]) && w.readyToFire)
                    w.Fire(enemies[0]);
            }
    }

    public void AddWeapon(Weapon weapon) {
        weapon.Reset();
        weapon.Upgrade();
        player.weapons.Add(weapon);
    }

    public void UpgradeWeapon(Weapon weapon) { weapon.Upgrade(); }

    private void Reset() {
        player.health = player.defaultHealth;
        player.maxHealth = player.defaultHealth;
        player.shield = player.defaultShield;
        player.maxShield = player.defaultShield;
        player.income = player.defaultIncome;
        foreach (Weapon w in player.weapons) w.Reset();
        player.weapons = new List<Weapon>();
    }
}
