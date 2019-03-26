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

    public Vector3 target = Vector3.zero;

    public float targetVal = 0.0f;
    public float targetInt = 0;


    public void Start()
    {

        targetVal = UnityEngine.Random.Range(1.0f, 4.0f);
        //Returns the values 1->4
        targetInt = Mathf.Round(targetVal);

        //Debug.Log(targetInt);

        switch(targetInt)
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



    }
}


