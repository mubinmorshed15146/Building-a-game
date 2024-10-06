using UnityEngine;

/// <summary>
/// This script is used to move the camera in the game.
/// </summary>
public class CameraController : MonoBehaviour {
  [SerializeField] private float speedVariable = 35f; // speed of moving of the cameras.

  // Update is called once per frame
  /// <summary>
  /// This is a Unity method which is used to move the camera around the map in the game.
  /// </summary>
  void Update() {
    if(GameManager.manager.isGameOver() == true) {
      enabled = false;

    }
    if(Input.GetKey(KeyCode.W)) {
      transform.Translate(Vector3.forward * speedVariable * Time.deltaTime, Space.World);
    } else if(Input.GetKey(KeyCode.S)) {
      transform.Translate(Vector3.back * speedVariable * Time.deltaTime, Space.World);
    } else if(Input.GetKey(KeyCode.A)) {
      transform.Translate(Vector3.left * speedVariable * Time.deltaTime, Space.World);
    } else if(Input.GetKey(KeyCode.D)) {
      transform.Translate(Vector3.right * speedVariable * Time.deltaTime, Space.World);
    } else if(Input.GetAxis("Mouse ScrollWheel") > 0) {
      if(GetComponent<Camera>().fieldOfView < 10) {
        return;
      } else {
        GetComponent<Camera>().fieldOfView--;
      }
    } else if(Input.GetAxis("Mouse ScrollWheel") < 0) {
      if(GetComponent<Camera>().fieldOfView > 60) {
        return;
      } else {
        GetComponent<Camera>().fieldOfView++;
      }
    } else {
      return;
    }
  }
}
