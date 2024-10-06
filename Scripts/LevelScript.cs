using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// This is a script to give the functionality and the access to the levels for the player.
/// </summary>
public class LevelScript : MonoBehaviour {
  [SerializeField]
  private Button[] levelAccessButtons;
  public int levelCount;// this variable is for keeping track of the level that the player has been completed
  #region UnityMethods
  /// <summary>
  /// This start method will be used at the start of the game to disable
  /// all the buttons except the first one or the completed level.
  /// </summary>
  public void Start() {
    levelCount = PlayerPrefs.GetInt("levelCount", 1); // setting the default value of the levelCount as 1
    for(int i = 0; i < levelAccessButtons.Length; i++) {
      if(i + 1 > levelCount) {
        levelAccessButtons[i].interactable = false; // make the button unintereactable if it is not the button same as levelCount.
      }
    }
  }
  #endregion
  /// <summary>
  /// This method is for the level button to load the scenes with the reference with their names as string.
  /// </summary>
  /// <param name="level">Is the scene name which will passed as the referrence</param>
  public void selectLevel(string level) {
    SceneManager.LoadScene(level);
  }
}
