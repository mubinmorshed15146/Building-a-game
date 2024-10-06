using UnityEngine;

/// <summary>
/// This class is responsible to activate the UI elements for game over and level passed.
/// </summary>
public class GameManager : MonoBehaviour {
  [SerializeField] private bool endGame;
  [SerializeField] private GameObject gameOverUI;
  [SerializeField] private GameObject LevelClearedUI;

  [HideInInspector]
  public static GameManager manager;
  #region unity methods
  // Start is called before the first frame update
  void Start() {
    manager = this;
    endGame = false;
  }

  // Update is called once per frame
  /// <summary>
  /// This method will be called every frame to check the players life and end the game or let the game continue.
  /// </summary>
  public void Update() {
    if(endGame) {
      return;
    }
    if(playerStats.stats.getLives() <= 0) {
      gameEnd();
    }
    if(Input.GetKey(KeyCode.Escape)) {
      gameEnd();

    }
  }
  #endregion
  #region setters

  /// <summary>
  /// This method will allow the UI for gameOver activate and show up in the screen while stopping all the fnctionalities of the game.
  /// </summary>
  public void gameEnd() {
    endGame = true;
    gameOverUI.SetActive(true);
  }
  /// <summary>
  /// Checking for the boolean
  /// </summary>
  /// <returns>The boolean value</returns>
  public bool isGameOver() {
    return endGame;
  }
  /// <summary>
  /// Access modifier for the endGame boolean which will be used for stopping the game.
  /// </summary>
  /// <param name="endGame">Bollean value to set the endGame</param>
  public void setGameover(bool endGame) {
    this.endGame = endGame;
  }
  #endregion

  /// <summary>
  /// This method is used to activate the UI when the level is cleared.
  /// </summary>
  public void levelPassed() {
    Debug.Log("level passed");
    LevelClearedUI.SetActive(true);
    setGameover(true);

  }

}
