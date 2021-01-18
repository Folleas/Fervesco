using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]
    public bool spawned;
    public float animationLength = 5f;
    private float scaleY = 0;

    void Start()
    {
        scaleY = transform.localScale.y;
        transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
        spawned = false;
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Animation()
    {
        float timePassed = 0;
        while (timePassed <= animationLength) {
            timePassed += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(0.01f, scaleY, timePassed / animationLength), transform.localScale.z);
            yield return null;
        }
        gameObject.GetComponent<MiscellaneousSpawner>().Run();
        spawned = true;
    }
}
