using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerContoller : MonoBehaviour
{
    public SteamVR_Action_Vector2 inputLJoy;
    public float speed = 1.5f;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(inputLJoy.axis.magnitude > 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(inputLJoy.axis.x, 0, inputLJoy.axis.y));

            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up));
        }

        characterController.Move(-new Vector3(0, 9.81f, 0) * Time.deltaTime);
    }
}
