using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCity : MonoBehaviour
{
    Transform playerCarTransform;
    [SerializeField] Transform otherCityTransform;
    [SerializeField] float halfLength;
    // Start is called before the first frame update
    void Start()
    {
        playerCarTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerCarTransform.position.z > transform.position.z + halfLength+10f)
        {
            transform.position = new Vector3(0, 0, otherCityTransform.position.z + halfLength * 2);
        }
    }
}
