using UnityEngine;
/// <summary>
/// This class will be used to generate methods and handle the turrets purchase.
/// It will be not a part of an unity components but all the components of this class will be used in the Builder.cs
/// class.
/// </summary>
/// 
[System.Serializable]
public class TurretFactory {
  [SerializeField]
  private GameObject turrets;
  [SerializeField]
  private int cost;
  public int getCost() {
    return cost;
  }
  /// <summary>
  /// Getter for the turret prefab
  /// </summary>
  /// <returns>Turret prefab</returns>
  public GameObject GetbuildingPrefab() => turrets;
}
