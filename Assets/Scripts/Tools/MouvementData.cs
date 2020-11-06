using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MouvementData {
    public int[] grid;

    public MouvementData(int[] grid) {
        this.grid = grid;
    }
}
