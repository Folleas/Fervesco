using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMatcher : MonoBehaviour {
    public int[] grid1Values;
    public int[] grid2Values;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            Grid grid1 = new Grid(5, 5);
            Grid grid2 = new Grid(5, 5);

            grid1.gridState = grid1Values;
            grid2.gridState = grid2Values;
            Debug.Log(PatternMatching.MatchPattern(grid1, grid2));
        }
    }
}
