using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class SpawnHandler : MonoBehaviour {
    [SerializeField] public int distToPlayer;
    [SerializeField] public int spawnPoints;
    [SerializeField] public int maxSpawnPoints;
    [SerializeField] public int defaultMaxSpawnPoints;
    [SerializeField] public float SecondsInbetweenSpawns;
    [SerializeField] public GameObject[] enemyPrefabs;
    private float timestampFromLastSpawn;

    void Start() { Reset(); }

    void Update() {
        if (ReadyToSpawn()) { SpawnEnemy(enemyPrefabs[0]); }
    }

    public void SpawnEnemy(GameObject enemy) {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.SetParent(GameObject.Find("Enemies").transform);
        int x, y = 0;
        x = Random.Range(0 - distToPlayer, distToPlayer + 1);

        if (x == 0) y = 10;
        else {
            // Randomly decides to spawn enemy above or below the Player
            int flipY = Random.Range(0, 2);
            y = Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow(distToPlayer, 2) - Mathf.Pow(x, 2)));

            // If flipY is 0, spawn enemy above Player, else, spawn it below Player
            y *= ((flipY == 1) ? -1 : 1);
        }

        newEnemy.transform.position = new Vector3(x, y, 0);
        PlayerHandler.inst.enemies.Add(newEnemy);
        timestampFromLastSpawn = Time.time;
        spawnPoints -= enemy.GetComponent<EnemyHandler>().defaultStats.spawnPointCost;
    }

    public void Reset() {
        maxSpawnPoints = defaultMaxSpawnPoints;
        spawnPoints = maxSpawnPoints;
        timestampFromLastSpawn = Time.time;
    }

    private bool ReadyToSpawn() {
        return (spawnPoints > 0) && (Time.time - timestampFromLastSpawn >= SecondsInbetweenSpawns);
    }
}
