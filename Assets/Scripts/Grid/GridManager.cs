using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSize;
    public Vector3 originPosition;
    bool clicked;
    private int[] drawnGrid;

    private Grid grid = null;
    private int[] gridState = null;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            gridState = null;
            if (!clicked) {
                clicked = true;
                Vector3 gridPosition = Utils.GetMouseWorldPosition();
                gridPosition.x -= width / 2;
                gridPosition.y -= height / 2;
                grid = new Grid(width, height, cellSize, gridPosition);
            }
        }
        else if (Input.GetMouseButton(0)) {
            gridState = null;
            grid.SetValue(Utils.GetMouseWorldPosition(), 1);
        }
        else if (Input.GetMouseButtonUp(0)) {
            gridState = grid.getGridState();
            clicked = false;
            grid.Delete();
        }
    }

    public MovementData getGridState()
    {
        int[] tmp = gridState;
        gridState = null;
        MovementData data = new MovementData(tmp);
        return data;
    }
}
