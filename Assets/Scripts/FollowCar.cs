using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    private Transform camPointTransform;
    private Transform carTransform;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        carTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camPointTransform = carTransform.Find("CameraPoint").GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(carTransform);
        transform.position = Vector3.SmoothDamp(transform.position, camPointTransform.position, ref velocity, 5f*Time.deltaTime);
    }
}
