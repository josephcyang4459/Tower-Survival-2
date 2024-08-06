using UnityEngine;
using UnityEngine.Events;

public class SpawnHandler : MonoBehaviour {
    [SerializeField] public int distToPlayer;
    [SerializeField] public int spawnPoints;
    [SerializeField] public int maxSpawnPoints;
    [SerializeField] public int defaultMaxSpawnPoints;
    [SerializeField] public int spawnPointIncreasePerRound;
    [SerializeField] public int secondsBeforeSpawns;
    [SerializeField] public float secondsInbetweenSpawns;
    [SerializeField] public float secondsInbetweenWaves;
    [SerializeField] public GameObject[] enemyPrefabs;
    public UnityEvent goToNextWave;
    private float timestampFromLastSpawn;
    private int RoundCount;

    void Start() {
        Reset();
        goToNextWave.AddListener(UpdateSpawnPoints);
    }

    void Update() {
        if (Time.time < secondsBeforeSpawns) return;
        if (spawnPoints > 0) {
            if (ReadyToSpawn()) {
                SpawnEnemy(enemyPrefabs[0]);
            }
        } else {
            if (Time.time - timestampFromLastSpawn >= secondsInbetweenWaves) {
                RoundCount++;
                goToNextWave.Invoke();
            }
        }
    }

    void OnDestroy() { goToNextWave.RemoveListener(UpdateSpawnPoints); }

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
    }

    public void UpdateSpawnPoints() {
        maxSpawnPoints += spawnPointIncreasePerRound;
        spawnPoints = maxSpawnPoints;
    }

    private bool ReadyToSpawn() { return Time.time - timestampFromLastSpawn >= secondsInbetweenSpawns; }
}
