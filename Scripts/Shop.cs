using UnityEngine;

/// <summary>
/// This clss will be used for buying the turrets through the shop.
/// </summary>
public class Shop : MonoBehaviour {
  private BuildManager buildManager;
  private playerStats stats;
  private int money;
  [SerializeField]
  private TurretFactory missileLauncher;
  [SerializeField]
  private TurretFactory standardTurret;
  [SerializeField]
  private TurretFactory laserBeamer;





  #region Unity utilities
  public void Start() {
    buildManager = BuildManager.Instance;
    stats = playerStats.stats;

  }
  public void Update() {
    money = stats.getMoney();

  }
  #endregion

  #region shoping functionalities
  /// <summary>
  /// This method will be binded to the standard turret button and upon clicking it the 
  /// standard turret will be purchased and instantiated in the game. The player will be unable to
  /// buy any turret if he has no money.
  /// </summary>
  public void shopTurret() {
    if(gameObject.tag == "Turret") {
      Debug.Log("You cannot build over any object");
    } else if(standardTurret.getCost() > money) {
      Debug.Log("Insufficient money");
      return;
    } else {
      Debug.Log("Bullet Turret is purchased");
      buildManager.InitiateObject(standardTurret.GetbuildingPrefab());
      money -= standardTurret.getCost();
      stats.setMoney(money);

    }

  }
  /// <summary>
  /// This method will be binded to the missile turret button and upon clicking it the 
  /// missile turret will be purchased and instantiated in the game. The player will be unable to
  /// buy any turret if he has no money.
  /// </summary>
  public void shopMissileturret() {
    if(missileLauncher.getCost() < money || gameObject.tag != "Turret") {
      Debug.Log("Missile Turret is purchased");
      buildManager.InitiateObject(missileLauncher.GetbuildingPrefab());
      money -= missileLauncher.getCost();
      stats.setMoney(money);


    } else {
      Debug.Log("Insufficient money");
      return;
    }
  }
  /// <summary>
  /// This method will be binded to the laser beamer button and upon clicking it the 
  /// laser beamer  will be purchased and instantiated in the game. The player will be unable to
  /// buy any turret if he has no money.
  /// </summary>
  public void shopLaserbeamer() {
    if(laserBeamer.getCost() < money || gameObject.tag != "Turret") {
      Debug.Log("Laser Beamer Turret is purchased");
      buildManager.InitiateObject(laserBeamer.GetbuildingPrefab());
      money -= laserBeamer.getCost();
      stats.setMoney(money);

    } else {
      Debug.Log("Insufficient money");
      return;
    }

  }
  #endregion
}

