
using UnityEngine;
/// <summary>
/// This class will allow the object that is attached with this script to drag over the terrain in game runtime.
/// </summary>
public class ObjectPlace : MonoBehaviour {
  //this variable will be used for saving the distance between
  //mouse position and center of the object and help us to avoid jumping
  private Vector3 mPosition;
  /// <summary>
  /// This method is to save the position from the world mouse position and our mouse position
  /// </summary>
  public void OnMouseDown() {
    mPosition = transform.position - BuildManager.WorldMousePosition();

  }

  /// <summary>
  /// This is a method to save the world mouse position with our mouse position
  /// </summary>
  public void OnMouseDrag() {
    Vector3 pos = BuildManager.WorldMousePosition() + mPosition;
    transform.position = BuildManager.Instance.SnapCoordinateToGrid(pos);
  }
}
