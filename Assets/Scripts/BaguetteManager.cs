﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaguetteManager : MonoBehaviour
{
    public static bool isBaguette;

    public GameObject spawnObject;
    private Vector3 Center;

    // Use this for initialization
    void Start()
    {
        Center = gameObject.transform.localPosition;
        isBaguette = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBaguette)
        {
            GameObject baguette = Instantiate(spawnObject);
            baguette.transform.SetParent(gameObject.transform);
            baguette.transform.localPosition =
            new Vector3(
                Random.Range(-1.2f, 1.2f),
                Random.Range(-0.55f, 0.57f),
                -0.108f
            );
            baguette.transform.eulerAngles = new Vector3(90, 0, 90);
            isBaguette = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (gameObject.transform.childCount > 1)
            {
                Destroy(gameObject.transform.GetChild(1).gameObject);
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
            if (gameObject.transform.childCount > 0)
                Destroy(gameObject.transform.GetChild(0).gameObject);
            isBaguette = false;
        }
    }
}
