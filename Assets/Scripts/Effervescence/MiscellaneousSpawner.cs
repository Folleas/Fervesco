using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscellaneousSpawner : MonoBehaviour
{
    public List<GameObject> source;
    private List<GameObject> objects = new List<GameObject>();
    private void Start() {
    }

    private void InstantiateMiscellaneous() {
        foreach (GameObject obj in source) {
            GameObject miscellaneous = Instantiate(obj) as GameObject;
            objects.Add(miscellaneous);
        }
    }
    void Update()
    {
    }

    public void Run() {
        InstantiateMiscellaneous();
        Vector3 size = gameObject.GetComponent<Renderer>().bounds.size;    
        foreach (GameObject obj in objects) {
            obj.transform.localScale = new Vector3(transform.localScale.x * 0.095f, transform.localScale.y * 0.097f, transform.localScale.z * 0.051f);
            obj.transform.position = new Vector3(Random.Range(transform.position.x - (size.x / 2), transform.position.x + (size.x / 2)), transform.position.y + size.y / 2 + obj.GetComponent<Renderer>().bounds.size.y / 2, Random.Range(transform.position.z - size.z / 2, transform.position.z + size.z / 2));
        }
    }
}
