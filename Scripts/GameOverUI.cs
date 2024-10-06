using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class is responsible to activate the game over UI upon player's defeat.
/// </summary>
public class GameOverUI : MonoBehaviour {
  [SerializeField] private TextMeshProUGUI rounds;

  /// <summary>
  /// A unity method which will display the enemy that has been killed and the rounds
  /// </summary>
  public void OnEnable() => rounds.text = "Rounds Survived: " + playerStats.stats.getRounds().ToString();

  /// <summary>
  /// Rety button of the game over script will be binded with this method to allow to load the same scene that the player could not clear
  /// </summary>
  public void retry() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

  /// <summary>
  /// This method will be binded with the Continue button to allow the player to go to the main menu to exit or play different level.
  /// </summary>
  public void cont() {
    SceneManager.LoadScene("MainMenu");
  }
  /// <summary>
  /// Ths will allow the player to load the next level.
  /// </summary>
  /// <param name="level">Scene name</param>
  public void nextLevel(string level) {
    SceneManager.LoadScene(level);
  }
}
