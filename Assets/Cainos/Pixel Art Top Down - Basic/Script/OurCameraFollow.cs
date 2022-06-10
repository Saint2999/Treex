using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//let camera follow target
public class OurCameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        targetPos = target.position + offset;


        if (target.position.y <= 2.42f && target.position.y >= -1.8f)
        {
            transform.position = new Vector3(offset.x, target.position.y + offset.y, offset.z);
        }
    }

}
