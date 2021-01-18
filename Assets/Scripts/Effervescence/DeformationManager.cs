using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeformationManager : MonoBehaviour {
    public int sources = 3;
    public int iterations = 1;
    [Range(1.1f,2.0f)]
    public float scaleCoefficient = 2f;
    public GameObject source;
    public float rotateUpCoef = 25f;
    public float rotateForwardCoef = 25f;
    public float rotateRightCoef = 25f;
    public float spawnPositionRatio = 2f;
    private bool deformationStatus;

    // Start is called before the first frame update
    void Start()
    {
        deformationStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!deformationStatus && gameObject.GetComponent<BuildingManager>().spawned) {
            StartDeformation();
            deformationStatus = true;
        }
    }

    void StartDeformation() {
        for (int i = 0; i < sources && iterations > 0; i++) {
            CreateSpineDeformation(source.GetComponent<Renderer>().bounds.size.y / spawnPositionRatio, iterations - 1);
        }
    }

    void CreateSpineDeformation(float halfSizeY, int iterations)
    {
        GameObject deformation = Instantiate(source) as GameObject;
        deformation.transform.position = transform.position + Vector3.up * halfSizeY;

        deformation.transform.localScale = transform.localScale / scaleCoefficient;

        deformation.transform.RotateAround(transform.position, transform.up, UnityEngine.Random.Range(rotateUpCoef * -1, rotateUpCoef));
        deformation.transform.RotateAround(transform.position, transform.right, UnityEngine.Random.Range(rotateRightCoef * -1, rotateRightCoef));
        deformation.transform.RotateAround(transform.position, transform.forward, UnityEngine.Random.Range(rotateForwardCoef * -1, rotateForwardCoef));

        //deformation.transform.SetParent(transform);

        DeformationManager deformationManager = deformation.GetComponent<DeformationManager>();
        deformationManager.iterations = iterations;
        deformationManager.scaleCoefficient = scaleCoefficient;
        deformationManager.sources = 1;
    }
    DeformationManager CreateDeformation(GameObject source, Transform parent, float halfSizeY, float scaleCoefficient, int iterations)
    {
        GameObject deformation = Instantiate(source) as GameObject;
        deformation.transform.position = parent.position + Vector3.up * halfSizeY;
        deformation.transform.localScale = parent.transform.localScale / scaleCoefficient;

        deformation.transform.RotateAround(parent.position, parent.up, UnityEngine.Random.Range(rotateUpCoef * -1, rotateUpCoef));
        deformation.transform.RotateAround(parent.position, parent.right, UnityEngine.Random.Range(rotateRightCoef * -1, rotateRightCoef));
        deformation.transform.RotateAround(parent.position, parent.forward, UnityEngine.Random.Range(rotateForwardCoef * -1, rotateForwardCoef));

        deformation.transform.SetParent(parent);

        DeformationManager deformationManager = deformation.GetComponent<DeformationManager>();
        deformationManager.iterations = iterations;
        deformationManager.scaleCoefficient = scaleCoefficient;
        deformationManager.sources = 1;
        return deformationManager;
    }
    DeformationManager CreateBugSpineDeformation(GameObject source, Transform parent, float halfSizeY, float scaleCoefficient, int iterations)
    {
        GameObject deformation = Instantiate(source) as GameObject;
        deformation.transform.position = parent.position + Vector3.up * halfSizeY;

        //Transform parentTransform = parent.transform.parent;
        //parent.transform.parent = null;
        deformation.transform.localScale = parent.transform.localScale / scaleCoefficient;
        //parent.transform.parent = parentTransform;

        deformation.transform.RotateAround(parent.position, parent.up, UnityEngine.Random.Range(-10.00f, 25.00f));
        deformation.transform.RotateAround(parent.position, parent.right, UnityEngine.Random.Range(-25.00f, 25.00f));
        deformation.transform.RotateAround(parent.position, parent.forward, UnityEngine.Random.Range(-25.00f, 25.00f));

        deformation.transform.SetParent(parent);

        DeformationManager deformationManager = deformation.GetComponent<DeformationManager>();
        deformationManager.iterations = iterations;
        deformationManager.scaleCoefficient = scaleCoefficient;
        deformationManager.sources = 1;
        return deformationManager;
    }
}
