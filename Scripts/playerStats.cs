using UnityEngine;
/// <summary>
/// This class will display the money and lives.
/// </summary>
public class playerStats : MonoBehaviour {

  //Singleton Initializer
  public static playerStats stats;
  [SerializeField] private int Money;
  private static int initialMoney = 400;
  [SerializeField] private int lives;

  private int rounds;

  #region Unity utilities
  void Start() {
    Money = initialMoney;

    rounds = 0;
  }
  public void Awake() {

    stats = this;

  }
  #endregion

  #region getters and setters

  public int getMoney() {
    return Money;
  }
  public void setMoney(int currency) {
    Money = currency;
  }
  public int getLives() {
    return lives;
  }
  public void setLives(int life) {
    lives = life;
  }
  public int getRounds() {
    return rounds;
  }
  public void setRounds() {
    rounds++;
  }
  #endregion
}
