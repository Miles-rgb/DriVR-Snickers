using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public float speed;
    public XRNode inputSource;
    public float gravityForce;
    public LayerMask groundLayer;
    public float additionalHeight;

    private float fallingSpeed;
    private XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        playerController.Move(direction * Time.fixedDeltaTime * speed);

        //gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
            fallingSpeed = 0;
        else
            fallingSpeed += gravityForce * Time.fixedDeltaTime;
        
        playerController.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);        
    }

    private void CapsuleFollowHeadset()
    {
        playerController.height = rig.CameraInOriginSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        playerController.center = new Vector3(capsuleCenter.x, playerController.height / 2 + playerController.skinWidth, capsuleCenter.z);
    }

    private bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(playerController.center);
        float rayLength = playerController.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, playerController.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
