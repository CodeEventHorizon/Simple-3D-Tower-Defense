using UnityEngine;
using TMPro; //TextMesh Pro

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordsText : MonoBehaviour
{
    public Color defClr = Color.white;
    public Color pathClr = Color.gray;
    TextMeshPro label;
    Vector2Int coords = new Vector2Int();
    TileClass tile;
    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        tile = GetComponentInParent<TileClass>();
        DisplayCoords();
    }
    void Update() {
        if(!Application.isPlaying) {
            DisplayCoords();
            UpdateLabelObjectName();
        }
        ChangeCoordsColor();
        DebugToggle();
    }
    void ChangeCoordsColor() {
        if(tile.IsTowerPlaceable) {
            label.color = defClr;
        } else {
            label.color = pathClr;
        }
    }
    void DebugToggle() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            label.enabled = !label.IsActive();
        }
    }
    void DisplayCoords() {
        coords.x = Mathf.RoundToInt(transform.parent.position.x);
        coords.y = Mathf.RoundToInt(transform.parent.position.z);
        label.text = coords.x + "," + coords.y;
    }

    void UpdateLabelObjectName() {
        transform.parent.name = coords.ToString();
    }
}
