using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;

    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform centerOfMassTransform;

    private Rigidbody rigidBody;

    private float verticalInput;
    private float horizontalInput;

    private float motorForce = 100f;
    private float maxSteerAngle = 30f;
    private float brakeForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass = centerOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
        GetInput();
        Steering();
        ApplyBrakes();
        PowerSteering();

    }

    void MotorForce()
    {
        backLeftWheelCollider.motorTorque = motorForce * verticalInput;
        backRightWheelCollider.motorTorque = motorForce * verticalInput;
    }

    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontLeftWheelCollider.brakeTorque = brakeForce;
            frontRightWheelCollider.brakeTorque = brakeForce;
            backLeftWheelCollider.brakeTorque = brakeForce;
            backRightWheelCollider.brakeTorque = brakeForce;
            rigidBody.drag = 1f;
        }
        else
        {
            frontLeftWheelCollider.brakeTorque = 0f;
            frontRightWheelCollider.brakeTorque = 0f;
            backLeftWheelCollider.brakeTorque = 0f;
            backRightWheelCollider.brakeTorque = 0f;
            rigidBody.drag = 0f;
        }
        
    }

    void Steering()
    {
        frontRightWheelCollider.steerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = maxSteerAngle * horizontalInput;
    }

    void PowerSteering()
    {
        if (horizontalInput == 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime);
        }
    }

    void UpdateWheels()
    {
        RotateWheel(backRightWheelCollider, backRightWheelTransform);
        RotateWheel(backLeftWheelCollider, backLeftWheelTransform);
        RotateWheel(frontRightWheelCollider, frontRightWheelTransform);
        RotateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
    }

    void RotateWheel(WheelCollider wheelCollider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;

    }

    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
