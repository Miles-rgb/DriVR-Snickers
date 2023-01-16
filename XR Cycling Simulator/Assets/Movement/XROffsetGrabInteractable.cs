using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;
    private void Start()
    {
        if(!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot= attachTransform.localRotation;
    }

    [System.Obsolete]
    protected override void OnSelectEntering(XRBaseInteractor args)
    {
        if(args is XRBaseInteractor)
        {
            attachTransform.position = args.transform.position;
            attachTransform.rotation = args.transform.rotation;
        }
        else
        {
            attachTransform.position = initialAttachLocalPos;
            attachTransform.rotation = initialAttachLocalRot;
        }

        base.OnSelectEntering(args);
    }
}
