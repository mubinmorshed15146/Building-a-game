using UnityEngine;

/// <summary>
/// This class will allow to get all the way points in an array as the child objects and loop through all the childs.
/// </summary>
public class WayPoints : MonoBehaviour {
  public static Transform[] wayPoints;

  public void Awake() {
    /* this variable is created to get all  the prefabs in the waypoints array */
    wayPoints = new Transform[transform.childCount];
    for(int i = 0; i < wayPoints.Length; i++) {
      wayPoints[i] = transform.GetChild(i);

    }
  }
}

