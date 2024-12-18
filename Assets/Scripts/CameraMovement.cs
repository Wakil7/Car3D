using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform playerCarTransform;
    [SerializeField] float offset = -10
        ;
    // Start is called before the first frame update
    void Start()
    {
        playerCarTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerCarTransform.position.z + offset;
        transform.position = cameraPos;
    }
}
