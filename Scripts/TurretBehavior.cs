
using UnityEngine;
/// <summary>
/// This class is responsible for the turrets to move their head to the enemy and rotate the head
/// as long as the enemies are in the range.
/// </summary>
public class TurretBehavior : MonoBehaviour {
  //This is a variable to store the target object
  private Transform target;
  private Enemy targetEnemy;// the enemy target


  [Header("Atrributes")]
  //This is a variable to set the range 
  [SerializeField] private float range = 15f; // the range of the turret for the enemy.
  //this variable is for indicaing how many bullet will be firing per second
  [SerializeField] private float fireRate = 1.00f;
  //This vaiable is for creating the timegap between fire the next bullet
  [SerializeField] private float rateOfFire = 0f;


  [SerializeField] private new string tag = "Enemy"; //this will be used to find the game objects which are tagged as Enemy.


  [SerializeField] private Transform head; //head for the turret
  //This is the variable to instantiate the bullets
  [SerializeField] private GameObject bullets;

  //this variables are for the laser beamer.
  [Header("Laser Beamer Atrributes")]
  [SerializeField] private bool laserBeam = false;
  [SerializeField] private LineRenderer lineRenderer;
  [SerializeField] private int damageOverTime;
  private readonly float slowingVar = 0.2f;// the rate of slowing down the enemies

  [SerializeField] private Transform fireDirection;// the position where the bullet or the missile will be instantiated.
  // Start is called before the first frame update
  void Start() {
    //This method will help to repeatedly invoke the method inside the parametre within the defined time.
    InvokeRepeating("UpdateTarget", 0f, 0.5f);
  }

  /// <summary>
  /// This method is defined to find the nearest target in the range and move to the way the target goes.
  /// </summary>
  void UpdateTarget() {
    float near = Mathf.Infinity;
    GameObject newTarget = null;
    GameObject[] gameObject = GameObject.FindGameObjectsWithTag(tag);//get all the gameobject tagged as enemy in the array
    foreach(GameObject enemy in gameObject) {
      float distance = Vector3.Distance(transform.position, enemy.transform.position);
      if(distance < near) {
        near = distance;
        newTarget = enemy; // updating the target

      }
      if(newTarget != null && near <= range) { //if there is no target in the range it will search for the new target
        target = newTarget.transform;
        targetEnemy = newTarget.GetComponent<Enemy>();
      } else {
        target = null;
      }
    }

  }

  // Update is called once per frame
  /// <summary>
  /// This is a unity method which will allow the turrets to shoot the enemies. And the target will be updated each frame.
  /// </summary>
  void Update() {
    if(target == null) {
      if(laserBeam == true) {
        if(lineRenderer.enabled) {
          lineRenderer.enabled = false;
        }
      }
      return;
    }
    targetLocked();

    if(laserBeam == true) {
      laserShoot();
    } else {

      if(rateOfFire <= 0f) {
        Shoot();
        rateOfFire = 1f / fireRate;

      }
    }

    rateOfFire -= Time.deltaTime;
  }
  /// <summary>
  /// This method will allow the laser beamer to shoot laser towards to the enemy and damage over time.
  /// It will also slow down the enemy speed.
  /// </summary>
  private void laserShoot() {
    if(!lineRenderer.enabled) {
      lineRenderer.enabled = true;
    }
    targetEnemy.DamageEnemy(damage: damageOverTime * Time.deltaTime);
    targetEnemy.slow(slowingVar);
    lineRenderer.SetPosition(0, fireDirection.position);
    lineRenderer.SetPosition(1, target.position);

  }
  /// <summary>
  /// This method is for the laser beamer to target the enemey Object.
  /// </summary>
  private void targetLocked() {
    //this variable will indicate the direction that the head of the turret will move
    Vector3 direction = target.position - transform.position;
    Quaternion move = Quaternion.LookRotation(direction);

    //For the smooth rotation we used lerp and set the distance of the rotation and the time variable which is mjultiplied with the delta time to see the rotation speed
    Vector3 rotation = Quaternion.Lerp(head.rotation, move, Time.deltaTime * 10).eulerAngles;
    head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
  }

  /// <summary>
  /// This method will be used for the bullets to isntantiate and set the target for the enemies.
  /// </summary>
  void Shoot() {

    GameObject bulletObject = Instantiate(bullets, fireDirection.position, fireDirection.rotation);
    BulletChase bulletChase = bulletObject.GetComponent<BulletChase>(); //get the bullet comonent where the script is been attached

    if(bulletChase != null) {
      bulletChase.setTarget(target);
    }
  }

  /// <summary>
  /// A unity call back function that will reveal the range of the turret. The range will be dawn only when we select the turret.
  /// </summary>
  void OnDrawGizmosSelected() {
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, range);

  }
}
