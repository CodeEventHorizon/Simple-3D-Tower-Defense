using UnityEngine;

public class TileClass : MonoBehaviour
{
    public Tower towerPrefab;
    public bool isTowerPlaceable;
    void OnMouseDown()
    {
        if (isTowerPlaceable && !transform.parent.tag.Equals("Paused"))
        {
            bool isTowerPlaced = towerPrefab.BuildTower(towerPrefab, transform.position);
            isTowerPlaceable = !isTowerPlaced;
        }
    }
    public bool IsTowerPlaceable
    {
        get
        {
            return isTowerPlaceable;
        }
    }
}
