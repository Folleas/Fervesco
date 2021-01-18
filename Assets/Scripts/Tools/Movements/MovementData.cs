using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementData {
    public int[] grid;

    public MovementData(int[] grid) {
        this.grid = grid;
    }
}
