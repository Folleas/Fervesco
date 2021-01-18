using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public int id;
    bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void onEnter() {
        selected = true;
    }
    public void OnExit() {
        selected = false;
    }
    public bool isSelected() {
        return selected;
    }
}
