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

    /*
    void color()
    {

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }

    }
    */

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (Mathf.Round(tiberium));

        //Increase tiberium as time goes on
        tiberium += Time.deltaTime;


        if(tiberium > 10)
        {
            var fighter = Instantiate(fighterPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity );
            fighter.transform.parent = baseTower.transform;



            tiberium = tiberium - 10;

        }
    }
}
