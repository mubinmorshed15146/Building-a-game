using UnityEngine;
using UnityEngine.Tilemaps;
/// <summary>
/// This is a unity generated class to handle the building of the turrets upon clicking the turret button
/// </summary>
public class BuildManager : MonoBehaviour {
  //Singleton Instance
  public static BuildManager Instance;
  //making this field public because I am going to use access it in other classes
  public GridLayout layout;
  private Grid grid;
  //Indicating the tiles on the grids
  [SerializeField] private Tilemap mainTile;
  //This field is to indicate the taken area of my grid system
  [SerializeField] private TileBase whiteTiles;
  private ObjectBuild placableObject;
  [SerializeField] private GameObject bulletTurret;
  [SerializeField] private GameObject MissileLauncherPrefab;
  [SerializeField] private GameObject laserbeamerPrefab;
  [SerializeField] private GameObject UI;
  private Vector3 tempPosition;
  [SerializeField]
  private Color hoverColour;
  private Color color; //This will be our start color
  private Renderer render;
  [SerializeField]
  private NodeUI ui;
  #region Unity Methods
  /// <summary>
  /// This method is to handle the singleton to initialize
  /// </summary>
  public void Awake() {
    if(Instance != null) {
      Debug.Log("There is a build manager is active");
      return;
    }
    Instance = this;
    grid = layout.gameObject.GetComponent<Grid>();
  }
  /// <summary>
  /// This method is used for rendering the colors.
  /// </summary>
  public void Start() {
    render = GetComponent<Renderer>();
    color = render.material.color;

  }
  /// <summary>
  /// This mthod will change the color when the mouse enter in the region
  /// </summary>
  public void OnMouseEnter() {
    render.material.color = hoverColour;
  }
  public void OnMouseExit() {
    render.material.color = color;
  }
  /// <summary>
  /// This method will be activated if we right click on the moouse and it will try to set active the ui.
  /// </summary>
  public void OnMouseDown() {

    if(gameObject.CompareTag("Turret")) {
      ui.setPosition(transform.position - WorldMousePosition());
      Debug.Log("Turret clicked");
    } else {
      ui.HideObject();
    }
  }
  #endregion

  #region Utilities
  /// <summary>
  /// This method is to get the vector3 location of the world position.
  /// This is a ray casting method to find out the position from the map.
  /// </summary>
  /// <returns>The ray cast hit point or center of the unity world</returns>
  public static Vector3 WorldMousePosition() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if(Physics.Raycast(ray, out RaycastHit rayCastHit)) {
      return rayCastHit.point;
    } else {
      return Vector3.zero;
    }
  }
  /// <summary>
  /// This method is created to align everything and getting the world position
  /// into snap position which will be an round up integer value.
  /// </summary>
  /// <param name="position">This is a vector3 parametre which will be used to contain the position of the cells</param>
  /// <returns>position to indicate the grid co ordinate of the grid layout</returns>
  public Vector3 SnapCoordinateToGrid(Vector3 position) {
    Vector3Int cellPosition = layout.WorldToCell(position);
    position = grid.GetCellCenterWorld(cellPosition);
    return position;
  }

  #endregion
  #region Placement of the object
  /// <summary>
  /// This is the method to place the object on the mouse drag and down.
  /// </summary>
  /// <param name="building">The para metre is a prefab which will be turrets in case of my game</param>
  public void InitiateObject(GameObject building) {
    tempPosition = WorldMousePosition();
    Vector3 position = SnapCoordinateToGrid(tempPosition);
    GameObject obj = Instantiate(building, position, Quaternion.identity);
    placableObject = obj.GetComponent<ObjectBuild>();
    obj.AddComponent<ObjectPlace>();

  }
  #endregion
}
