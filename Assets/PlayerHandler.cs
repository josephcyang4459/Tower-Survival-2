using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject EnemiesList;
    public List<GameObject> enemies = new List<GameObject>();
    public static PlayerHandler inst;

    // Start is called before the first frame update
    void Start() {
        if (inst == null) {
            inst = this;
            DontDestroyOnLoad(inst);
        } else {
            Destroy(gameObject);
        }

        Reset();
        for (int i = 0; i < EnemiesList.transform.childCount; i++)
            enemies.Add(EnemiesList.transform.GetChild(i).gameObject);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (enemies.Count > 0)
            foreach (Weapon w in player.weapons) {
                w.CheckReadyToFire();

                if (enemies[0] != null)
                    if (w.WithinRange(gameObject, enemies[0]) && w.readyToFire)
                        w.Fire(enemies[0]);
            }
    }

    public void UpgradeWeapon(Weapon weapon) {
        if (player.weapons.Contains(weapon)) {
            weapon.Upgrade();
        } else {
            weapon.Reset();
            weapon.Upgrade();
            player.weapons.Add(weapon);
        }
    }

    public void SpawnEnemy(GameObject enemy) {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.SetParent(GameObject.Find("Enemies").transform);
        enemies.Add(newEnemy);
    }

    private void Reset() {
        player.health = player.defaultHealth;
        player.maxHealth = player.defaultHealth;
        player.shield = player.defaultShield;
        player.maxShield = player.defaultShield;
        player.income = player.defaultIncome;

        foreach (Weapon w in player.weapons) w.Reset();
        player.weapons = new List<Weapon>();
    }

    private void OnDestroy() { foreach (Weapon w in player.weapons) w.Reset(); }
}
