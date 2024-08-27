using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpawnHandler : MonoBehaviour {
    [SerializeField] public int spawnDistToPlayer;
    [SerializeField] public int spawnPoints;
    [SerializeField] public int maxSpawnPoints;
    [SerializeField] public int defaultMaxSpawnPoints;
    [SerializeField] public int spawnPointIncreasePerRound;
    [SerializeField] public int secondsBeforeSpawns;
    [SerializeField] public float spawnTimeBuffer;
    [SerializeField] public float minSpawnTimeBuffer;
    [SerializeField] public float SpawnTimeBufferDecreasePerRound;
    [SerializeField] public float waveTimeBuffer;
    [SerializeField] public GameObject[] enemyPrefabs;
    public UnityEvent goToNextWave;
    private float timestampFromLastSpawn;
    private int RoundCount;

    void Start() {
        Reset();
        goToNextWave.AddListener(UpdateSpawnPoints);
        goToNextWave.AddListener(UpdateSpawnTimeBuffer);
        StartCoroutine(SpawnWave(secondsBeforeSpawns));
    }

    void OnDestroy() {
        goToNextWave.RemoveListener(UpdateSpawnPoints);
        goToNextWave.RemoveListener(UpdateSpawnTimeBuffer);
    }

    IEnumerator SpawnWave(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        RoundCount++;

        while (spawnPoints > 0) {
            SpawnEnemy(enemyPrefabs[0]);
            yield return new WaitForSeconds(spawnTimeBuffer);
        }

        goToNextWave.Invoke();
        StartCoroutine(SpawnWave(waveTimeBuffer));
    }

    public void SpawnEnemy(GameObject enemy) {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.SetParent(GameObject.Find("Enemies").transform);
        int x, y = 0;
        x = Random.Range(0 - spawnDistToPlayer, spawnDistToPlayer + 1);

        if (x == 0) y = 10;
        else {
            // Randomly decides to spawn enemy above or below the Player
            int flipY = Random.Range(0, 2);
            y = Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow(spawnDistToPlayer, 2) - Mathf.Pow(x, 2)));

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
    }

    public void UpdateSpawnPoints() {
        maxSpawnPoints += spawnPointIncreasePerRound;
        spawnPoints = maxSpawnPoints;
    }

    public void UpdateSpawnTimeBuffer() {
        if (spawnTimeBuffer - SpawnTimeBufferDecreasePerRound >= minSpawnTimeBuffer)
            spawnTimeBuffer -= SpawnTimeBufferDecreasePerRound;
    }
}
