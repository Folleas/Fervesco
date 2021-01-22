using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementData {
    public int[] grid;
    public int width;
    public int height;
    public string movementID;

    public MovementData(string movementID, int[] grid, int width, int height) {
        this.movementID = movementID;
        this.grid = grid;
        this.width = width;
        this.height = height;
    }
}
