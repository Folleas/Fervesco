using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public int width;
    public int height;
    public float cellSize;
    public Vector3 originPosition;
    bool clicked;
    private int[] drawnGrid;

    private Grid _grid = null;
    public Grid grid {
        get {
            return _grid;
        }
    }
    private int[] gridState = null;

    private int index;

    // Start is called before the first frame update
    void Start() {
        clicked = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            gridState = null;
            if (!clicked) {
                clicked = true;
                _grid = new Grid(width, height);
                index = 1;
            }
        }
        else if (Input.GetMouseButton(0)) {
            gridState = null;
            Vector2 mousePosition = Input.mousePosition;
            mousePosition.y = 1080 - mousePosition.y;
            if (_grid.SetValue(mousePosition, index))
                index++;
        }
        else if (Input.GetMouseButtonUp(0)) {
            gridState = _grid.gridState;
            for (int i = 0; i != height; i++) {
                int[] line = new int[width];
                for (int j = 0; j != width; j++) {
                    line[j] = gridState[Utils.ConvertTo1DPosition(j, i, width)];
                }
                Debug.Log(i + ":   " + string.Join("",
                            new List<int>(line)
                            .ConvertAll(x => x.ToString())
                            .ToArray()));
            }
            clicked = false;
        }
    }

    public MovementData getGridState() {
        int[] tmp = gridState;
        gridState = null;
        MovementData data = new MovementData("", tmp, width, height);
        return data;
    }
}
