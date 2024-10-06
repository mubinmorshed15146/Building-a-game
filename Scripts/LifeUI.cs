using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour {
  /// <summary>
  /// This class will allow to display the lives of the player to display on the UI.
  /// </summary>
  [SerializeField] private TextMeshProUGUI lifeText;

  // Update is called once per frame
  void Update() {
    lifeText.text = playerStats.stats.getLives().ToString();
  }
}
