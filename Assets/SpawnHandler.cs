using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {
    [SerializeField] public int distToPlayer;
    [SerializeField] public int spawnPoints;
    [SerializeField] public int maxSpawnPoints;
    [SerializeField] public int defaultSpawnPoints;
    [SerializeField] public float SecondsInbetweenSpawns;

    void Start() { Reset(); }

    public void SpawnEnemy(GameObject enemy) {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.SetParent(GameObject.Find("Enemies").transform);
        int x, y = 0;
        x = Random.Range(0 - distToPlayer, distToPlayer + 1);

        if (x == 0)
            y = 10;
        else {
            int flipY = Random.Range(0, 2);
            Debug.Log("FlipY: " + flipY);
            y = Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow(distToPlayer, 2) - Mathf.Pow(x, 2))) * ((flipY == 1) ? -1: 1);
        }
            

        Debug.Log("New Enemy Spawned at: " + x + ", " + y);

        newEnemy.transform.position = new Vector3(x, y, 0);
        PlayerHandler.inst.enemies.Add(newEnemy);


    }

    public void Reset() { maxSpawnPoints = 10; }
}
