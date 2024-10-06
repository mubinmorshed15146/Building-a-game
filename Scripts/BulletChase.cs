using UnityEngine;

public class BulletChase : MonoBehaviour {
  private Transform target;
  [SerializeField] private float speedOfBullet = 80f;
  [SerializeField] private GameObject effect;
  [SerializeField] private float explosionRadius;
  [SerializeField] private int damage;

  /// <summary>
  /// Setting the new target
  /// </summary>
  /// <param name="target">The position of the targetted objects</param>
  public void setTarget(Transform target) {
    this.target = target;
  }

  // Update is called once per frame
  /// <summary>
  /// Upadate method will be used to set the taret for the bullet or destroy the bullet if the target is not found.
  /// </summary>
  void Update() {
    if(target == null) {
      Destroy(gameObject);
      return;

    }
    Vector3 dir = target.position - transform.position;
    float distance = Time.deltaTime * speedOfBullet;
    if(dir.magnitude < distance) {
      hitTarget();
      return;
    }

    transform.Translate(dir.normalized * distance, Space.World);
    transform.LookAt(target);
  }

  /// <summary>
  /// This method is to destroy the bullet object after hitting the enemy
  /// </summary>
  private void hitTarget() {
    GameObject hitEffect = Instantiate(effect, transform.position, transform.rotation);
    Destroy(hitEffect, 5f);
    if(explosionRadius > 0) {
      explode();
    } else {
      damageObj(target);
    }
    Destroy(gameObject);
  }

  /// <summary>
  /// This method is for the missile to explode and damage the game objects tagged with Enemy.
  /// </summary>
  public void explode() {
    Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius);
    foreach(Collider item in enemies) {
      if(item.tag == "Enemy") {
        damageObj(item.transform);
      }

    }
  }


  /// <summary>
  /// This methos is created to damage and destroy the enemies with the bullets
  /// </summary>
  /// <param name="enemy">parametere "enemy" is a game object which will be targeted by the bullet</param>
  public void damageObj(Transform enemy) {
    Enemy enemyObj = enemy.GetComponent<Enemy>();
    if(enemyObj != null) {
      enemyObj.DamageEnemy(damage);
    }

  }
  public void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawSphere(transform.position, explosionRadius);
  }
}
