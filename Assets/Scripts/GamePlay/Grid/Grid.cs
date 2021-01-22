using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class Grid {
    public bool showDebug = true;

    public Vector2Int dimension {
        get {
            return new Vector2Int(width, height);
        }
        set {
            width = value.x;
            height = value.y;
        }
    }
    private int width;
    private int height;
    private Vector2 cellSize;
    private int[] gridArray;
    public int[] gridState {
        get {
            return gridArray;
        }
        set {
            gridArray = value;
        }
    }

    public Grid(int width, int height) {
        this.width = width;
        this.height = height;
        cellSize.x = Screen.currentResolution.width / width;
        cellSize.y = Screen.currentResolution.height / height;
        gridArray = new int[width * height];
    }

    private void ComputeXY(Vector2 position, out int x, out int y) {
        x = Mathf.FloorToInt(position.x / cellSize.x);
        y = Mathf.FloorToInt(position.y / cellSize.y);
    }

    public bool SetValue(int x, int y, int value) {
        if (x >= 0 && y >= 0 && x < width && y < height && gridArray[Utils.ConvertTo1DPosition(x, y, width)] == 0) {
            gridArray[Utils.ConvertTo1DPosition(x, y, width)] = value;
            return true;
        }
        return false;
    }

    public bool SetValue(Vector2 position, int value) {
        int x, y;
        ComputeXY(position, out x, out y);
        return SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[Utils.ConvertTo1DPosition(x, y, width)];
        }
        else
            return 0;
    }

    public int GetValue(Vector2 position) {
        int x, y;
        ComputeXY(position, out x, out y);
        return GetValue(x, y);
    }

}
