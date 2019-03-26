﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float tiberium = 0;

    public TextMeshPro text;

    public GameObject fighterPrefab;
    public GameObject baseTower;

    // Start is called before the first frame update
    void Start()
    {


        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + tiberium;

        //Increase tiberium as time goes on
        tiberium += Time.deltaTime;


        if(tiberium > 10)
        {
            Instantiate(fighterPrefab, new Vector3(0, 0, 0), Quaternion.identity );
            tiberium = tiberium - 10;

        }
    }
}
