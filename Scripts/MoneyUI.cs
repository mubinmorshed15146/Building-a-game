using TMPro;
using UnityEngine;

/// <summary>
/// This is a Unity script class to show the money in the screen.
/// </summary>
public class MoneyUI : MonoBehaviour {
  [SerializeField]
  private TextMeshProUGUI money;


  // Update is called once per frame
  void Update() {
    money.text = "$" + playerStats.stats.getMoney().ToString();

  }
}
