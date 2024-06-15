using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SocialPlatforms;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject EnemiesList;
    private List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < EnemiesList.transform.childCount; i++) { enemies.Add(EnemiesList.transform.GetChild(i).gameObject); }

        foreach (Weapon w in player.weapons) { w.Reset(); }


        //TODO Need to make Projectile collide with the enemy and do damage
    }

    // Update is called once per frame
    void FixedUpdate() {
        Debug.Log(enemies.Count);

        foreach (GameObject e in enemies)
            Debug.Log(e.name);
        foreach (Weapon w in player.weapons) {
            if (w.readyToFire) {
                w.fireProjectile(enemies[0]);
                w.readyToFire = false;
            }
        }
    }

    private void Reset() {
        player.health = player.defaultHealth;
        player.maxHealth = player.defaultHealth;
        player.shield = player.defaultShield;
        player.maxShield = player.defaultShield;
        player.income = player.defaultIncome;
    }

    public void __Reset() {
        Reset();
    }
}
