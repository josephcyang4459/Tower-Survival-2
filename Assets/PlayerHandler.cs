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
        for (int i = 0; i < EnemiesList.transform.childCount; i++)
            enemies.Add(EnemiesList.transform.GetChild(i).gameObject);

        foreach (Weapon w in player.weapons)
            w.Reset();

        //TODO Need to allow Projectile to be fired again based on weapon attack speed
    }

    // Update is called once per frame
    void FixedUpdate() {
        foreach (Weapon w in player.weapons)
            if (w.readyToFire)
                w.fireProjectile(enemies[0]);
    }

    private void Reset() {
        player.health = player.defaultHealth;
        player.maxHealth = player.defaultHealth;
        player.shield = player.defaultShield;
        player.maxShield = player.defaultShield;
        player.income = player.defaultIncome;
    }
}
