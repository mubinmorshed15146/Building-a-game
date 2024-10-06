using System;
using UnityEngine;
/// <summary>
/// This class will be used to spawn the enemies.
/// </summary>
[Serializable]
public class Wave {
  [SerializeField]
  private GameObject enemy;// gameobject reference of the enemy that we are going to spawn
  [SerializeField]
  private int number;// ammount of the enemy that will be spawn.
  [SerializeField]
  private float rate; // spawning rate of the enemies

  #region getters and setters
  /// <summary>
  /// This is a getter for the enemy gameobject
  /// </summary>
  /// <returns>the enemy gamobject</returns>
  public GameObject getEnemy() {
    return enemy;
  }
  /// <summary>
  /// This method will be used to spawn the ammount of enemies.
  /// </summary>
  /// <returns>the number of the enmey as int</returns>
  public int getNumber() { return number; }
  /// <summary>
  /// Get the spawning rate 
  /// </summary>
  /// <returns>The rate in a integer</returns>
  public float getRate() { return rate; }

  #endregion

}
