using System.Collections;
using UnityEngine;

/// <summary>
/// This is a class responsible to spawn enemies
/// </summary>
public class WaveSpawner : MonoBehaviour {

  public static int enemiesAlive = 0;// this indixates how many enemies are alive
  [SerializeField] private Wave[] waves;// enemy prefab that we are going to use as enemy
  [SerializeField] private Transform spawnPoint;// the start point the enemies going to spawn
  [SerializeField] private float tmeBetweenWave = 5f; //the time span between each wave
  private float countDown = 2f;
  private int waveNumber = 0; //number of wave that has been created by this script
  [SerializeField]
  private GameManager gameManager;

  #region unity methods
  /// <summary>
  /// This method will be called per second and start a co routine to spawn over time.
  /// </summary>
  private void Update() {
    if(enemiesAlive > 0) {
      return;
    }
    if(waveNumber == waves.Length) {
      gameManager.levelPassed();

    }

    if(countDown <= 0) {
      StartCoroutine(SpawnWave());
      countDown = tmeBetweenWave;
      return;
    }
    countDown -= Time.deltaTime;
  }

  #endregion

  #region enemy wave functionaities
  /// <summary>
  /// To spawn the waves. That means the time or interval of the enemy spawing
  /// </summary>
  /// <returns> The wait second of the wave</returns>
  IEnumerator SpawnWave() {
    playerStats.stats.setRounds();
    Wave wave = waves[waveNumber];
    for(int i = 0; i < wave.getNumber(); i++) {
      SpawnEnemy(wave.getEnemy());
      yield return new WaitForSeconds(1f / wave.getRate());
    }
    waveNumber++;
  }
  /// <summary>
  /// This method will be used to instansiate the enemies
  /// </summary>
  void SpawnEnemy(GameObject enemyPrefab) {
    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    enemiesAlive++;
  }
  #endregion

}

