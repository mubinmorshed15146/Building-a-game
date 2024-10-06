
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This method is responsible to load the Level scene and quit the game.
/// </summary>
public class MainMenu : MonoBehaviour {
  /// <summary>
  /// This method will allow to load the Level scene
  /// </summary>
  public void Play() {
    SceneManager.LoadScene("Level");
  }
  /// <summary>
  /// This method will allow the player to exit the game and close the window.
  /// </summary>
  public void quit() {
    Debug.Log("Quiting");
    Application.Quit();
  }
}
