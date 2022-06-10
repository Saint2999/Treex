using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//let camera follow target
public class OurCameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1.0f;

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

        if (transform.position.y <= 5.88f && transform.position.y >= -0.5f)
        {
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
        }
    }

}
