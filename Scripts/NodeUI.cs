using UnityEngine;
/// <summary>
/// This class is used for setting active the UI for upgrading.
/// </summary>
public class NodeUI : MonoBehaviour {
  [SerializeField] private GameObject uiElement;
  /// <summary>
  /// This method will be responsible for the UI to set active to the position where the mouse is clicked.
  /// </summary>
  /// <param name="position">The position where the mouse is clicked.</param>
  public void setPosition(Vector3 position) {
    transform.position = position;
    uiElement.SetActive(true);
  }
  /// <summary>
  /// This method will be used to hide the object with the help of the script.
  /// </summary>
  public void HideObject() => this.gameObject.SetActive(false);
}
