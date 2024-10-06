using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class will activate the pause menu upon clicking P from the keyboard.
/// </summary>
public class PauseMenu : MonoBehaviour {
  [SerializeField] private GameObject m_gameObject;
  // Update is called once per frame
  public void Update() {
    if(Input.GetKeyDown(KeyCode.P)) {
      Toggle();

    }
  }
  /// <summary>
  /// This method will be called to de acttivate the UI and continue the game.
  /// </summary>

  public void Toggle() {
    m_gameObject.SetActive(!m_gameObject.activeSelf);
    if(m_gameObject.activeSelf) {
      GameManager.manager.setGameover(false);
      Time.timeScale = 0f;
    } else {
      Time.timeScale = 1f;
    }
  }
  /// <summary>
  /// This method will allow the player to restart the game.
  /// </summary>
  public void Retry() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Toggle();
  }
  /// <summary>
  /// This method will allow the player to return to the main menu.
  /// </summary>
  public void Menu() {
    SceneManager.LoadScene("MainMenu");
  }
}
