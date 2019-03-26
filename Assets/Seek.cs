﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public GameObject currentTarget = null;

    public GameObject targetGameObject1 = null;
    public GameObject targetGameObject2 = null;
    public GameObject targetGameObject3 = null;
    public GameObject targetGameObject4 = null;

    public GameObject baseGameObject = null;
    public GameObject fighter = null;

    public Vector3 target = Vector3.zero;

    public float targetVal = 0.0f;
    public float targetInt = 0;

    public float tiberium = 0;

    public bool inBase = false;


    public void Start()
    {
        tiberium = 7;

        //Debug.Log(targetInt);
        targetSelect();
       

    }

    public void targetSelect()
    {
        targetVal = UnityEngine.Random.Range(1.0f, 4.0f);
        //Returns the values 1->4
        targetInt = Mathf.Round(targetVal);


        switch (targetInt)
        {
            case 1:
                currentTarget = targetGameObject1;
                break;

            case 2:
                currentTarget = targetGameObject2;
                break;

            case 3:
                currentTarget = targetGameObject3;
                break;

            case 4:
                currentTarget = targetGameObject4;
                break;

            default:
                currentTarget = targetGameObject1;
                break;


        }

    }

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (currentTarget != null)
            {
                target = currentTarget.transform.position;
            }
            //Gizmos.DrawLine(transform.position, target);
        }
    }
    
    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);    
    }

    public void Update()
    {
        if (currentTarget != null)
        {
            target = currentTarget.transform.position;
        }

        //when out of fuel return to base
        if(tiberium == 0)
        {
            //Sets target to home and variable to check if in base is set to true
            target = fighter.transform.parent.position;
            inBase = true;
        }

        //if in the base and has enough tiberium - chooses new target and leaves base
        if(inBase == true && tiberium >= 7)
        {
            targetSelect();
            inBase = false;

        }

    }
}


