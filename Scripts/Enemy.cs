using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This is a scrip class created by unity.
/// This classs gives functionaity to the eney which is a skeleton.
/// The enemy will be able to travel, have health and speed due to the script.
/// </summary>
public class Enemy : MonoBehaviour {

  [SerializeField]
  private float speed = 10.0f;// speed variable for the enemy.
  private float decreasedSpeed;
  [SerializeField]
  private float health;//health variable for the enemy.
  private float healthVariable;
  [SerializeField] private GameObject deathEffect;
  [SerializeField]
  private Image healthbar;
  private Transform target;
  private int wavePoint = 0;
  private int playerLife;
  private int money;
  public static Enemy enemyInstance; // Singleton

  #region Unity utilities

  /// <summary>
  /// This is a unity method which will be used to set the target for enemu, get the money from the player stat and get the speed variable.
  /// </summary>
  public void Start() {
    target = WayPoints.wayPoints[0];
    money = playerStats.stats.getMoney();
    decreasedSpeed = getSpeed();
    healthVariable = health;
  }


  public void Awake() => enemyInstance = this; // Lamda expression to initialize the singleton start of the game

  // Update is called once per frame
  /// <summary>
  /// This method allows the enemies to move forward and the next way point get updated per frame.
  /// </summary>
  public void Update() {
    Vector3 direction = target.position - transform.position;
    transform.Translate(direction.normalized * decreasedSpeed * Time.deltaTime, Space.World);
    if(Vector3.Distance(transform.position, target.position) <= 0.1) {
      getNextWayPoint();
    }
    playerLife = playerStats.stats.getLives();
    decreasedSpeed = speed;
  }
  #endregion


  #region Functionalities for the enemy
  protected float getSpeed() => speed;

  /// <summary>
  /// This method allows the enemy to move from one way point to other.
  /// </summary>
  void getNextWayPoint() {
    if(wavePoint >= (WayPoints.wayPoints.Length - 1)) {
      endOfPath();

      return;
    }
    wavePoint++;
    target = WayPoints.wayPoints[wavePoint];
  }
  /// <summary>
  /// This method is to deduct the players life.
  /// </summary>
  public void endOfPath() {
    if(playerLife == 0) {
      Debug.Log("Game Over");

    } else {
      playerLife--;
      playerStats.stats.setLives(playerLife);
      Destroy(gameObject);
      WaveSpawner.enemiesAlive--;
    }
  }
  /// <summary>
  /// This method is to allow damage the enemy and add the sum of the money upon enemies death.
  /// </summary>
  /// <param name="damage">The ammount of damage.</param>
  public void DamageEnemy(float damage) {
    if((health <= 0)) {
      Destroy(gameObject);
      money += 30;
      playerStats.stats.setMoney(money);
      GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
      Destroy(effect, 2f);
      WaveSpawner.enemiesAlive--;

    } else {
      health = health -= damage;
      healthbar.fillAmount = health / healthVariable; //manipulating the healthbar
    }
  }
  /// <summary>
  /// This method will be used to sloew down the enemies for the laser beamer.
  /// </summary>
  /// <param name="slowVar">Is the percentage for slowing the enemy.</param>
  public void slow(float slowVar) {
    decreasedSpeed = speed - speed * (1 - slowVar);
  }
  #endregion

}
