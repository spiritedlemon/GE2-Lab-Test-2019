using System;
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

    public GameObject fighter;
    public GameObject bulletPrefab;

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

    //This method is used to select a target base for the fighter
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

        //If fighter targets own tower targetSelect will be called again
        if (currentTarget == fighter.transform.parent.gameObject)
        {
            targetSelect();
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
        if (tiberium == 0)
        {
            //Sets target to home and variable to check if in base is set to true
            target = 
                fighter.transform.parent.position;
            inBase = true;
        }



        //if in the base and has enough tiberium - chooses new target and leaves base
        

        //If fighter is within 5 units of target
        if (Vector3.Distance(fighter.transform.position, target) <= 5)
        {
            //if fighter has ammo it will spend 1 tiberium to create 1 bullet
            if (tiberium > 0)
            {
                var bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                tiberium--;
            }

            //if fighter has no ammo and is near base it will reload and choose target
            if(tiberium == 0 && inBase == true)
            {
                tiberium = 7;

                //Chooses new target and leaves base

                targetSelect();
                inBase = false;

            }
        }




    }
}
