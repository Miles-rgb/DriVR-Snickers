using UnityEngine;
using UnityEngine.XR;

public class BikeController : MonoBehaviour
{
    public WheelCollider frontWheel;
    public WheelCollider backWheel;

    public float acceleration;
    public float breakingForce;
    public Transform steeringWheel;

    public XRNode inputSourceLeft;
    public XRNode inputSourceRight;

    public float minRot;
    public float maxRot;

    private float minVel = -0.1f;
    private float maxVel = 0.1f;

    private float currentAcceleration;
    private float currentBreakForce;
    private float currentTurnAngle;

    private float accelerationInput;
    private float breakingInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice accelerationDevice = InputDevices.GetDeviceAtXRNode(inputSourceLeft);
        InputDevice breakingDevice = InputDevices.GetDeviceAtXRNode(inputSourceRight);
        accelerationDevice.TryGetFeatureValue(CommonUsages.trigger, out accelerationInput);
        breakingDevice.TryGetFeatureValue(CommonUsages.trigger, out breakingInput);

        currentAcceleration = acceleration * accelerationInput;

        if (breakingInput > 0f)
        {
            currentBreakForce = breakingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }

        if (breakingInput > 0f && accelerationInput == 0 && (frontWheel.attachedRigidbody.velocity.x <= maxVel && frontWheel.attachedRigidbody.velocity.y <= maxVel && frontWheel.attachedRigidbody.velocity.z <= maxVel) || (frontWheel.attachedRigidbody.velocity.x <= minVel && frontWheel.attachedRigidbody.velocity.y <= minVel && frontWheel.attachedRigidbody.velocity.z <= minVel))
        {
            frontWheel.attachedRigidbody.velocity = Vector3.zero;
        }

        frontWheel.motorTorque = currentAcceleration;

        frontWheel.brakeTorque = currentBreakForce;

        backWheel.brakeTorque = currentBreakForce;

        currentTurnAngle = steeringWheel.localRotation.eulerAngles.y;

        frontWheel.steerAngle = currentTurnAngle;

        
    }

    private void FixedUpdate()
    {
        if (transform.rotation.eulerAngles.z < minRot)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                minRot
            );
        }
        else if (transform.rotation.eulerAngles.z > maxRot)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                maxRot
             );
        }
    }
}
