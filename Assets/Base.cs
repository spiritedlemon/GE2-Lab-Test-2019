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


    //This is the method for calculating damage
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);

            //Base loses .5 tiberium if hit with bullet
            tiberium = tiberium - 0.5f;
        }


    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (Mathf.Round(tiberium));

        //Increase tiberium as time goes on
        tiberium += Time.deltaTime;

        //spends 10 tiberium to make a fighter
        if(tiberium >= 10)
        {
            var fighter = Instantiate(fighterPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity );
            fighter.transform.parent = baseTower.transform;

            //sets fighter as child of base so they can return home


            tiberium = tiberium - 10;

        }
    }
}