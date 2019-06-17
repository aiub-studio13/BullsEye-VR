using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandController : MonoBehaviour
{
    public SteamVR_Action_Boolean uGrabAction = null;
    private SteamVR_Behaviour_Pose uPose = null;
    private FixedJoint ujoint = null;
    public List<BaseBallBatInteractable> UContactInteractAbles=new List<BaseBallBatInteractable>();
    private BaseBallBatInteractable uCurrentInteractable = null;
    private void Awake()
    {
        uPose = GetComponent<SteamVR_Behaviour_Pose>();
        ujoint = GetComponent<FixedJoint>();
    }
    // Update is called once per frame
    void Update()
    {
        if (uGrabAction.GetStateDown(uPose.inputSource))
        {
            print(uPose.inputSource + " Trigger down");
            Pickup();
        }

        if (uGrabAction.GetStateUp(uPose.inputSource))
        {
            print(uPose.inputSource + " Trigger UP");
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        UContactInteractAbles.Add(other.gameObject.GetComponent<BaseBallBatInteractable>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        UContactInteractAbles.Remove(other.gameObject.GetComponent<BaseBallBatInteractable>());
    }

    public void Pickup()
    {
        uCurrentInteractable = GetNearestInteractable();
        if (!uCurrentInteractable)
        {
            return;
        }
        if (uCurrentInteractable.uActiveHand)
        {
            uCurrentInteractable.uActiveHand.Drop();
        }
        uCurrentInteractable.transform.position = transform.position;
        Rigidbody targetBody = uCurrentInteractable.GetComponent<Rigidbody>();
        ujoint.connectedBody = targetBody;
        uCurrentInteractable.uActiveHand = this;
        
    }

    public void Drop()
    {
        if (!uCurrentInteractable)
        {
            return;
        }
        Rigidbody targetBody = uCurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = uPose.GetVelocity();
        targetBody.angularVelocity = uPose.GetAngularVelocity();

        ujoint.connectedBody = null;

        uCurrentInteractable.uActiveHand = null;
        uCurrentInteractable = null;

    }

    private  BaseBallBatInteractable GetNearestInteractable()
    {
        BaseBallBatInteractable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;
        foreach (BaseBallBatInteractable interactable in UContactInteractAbles)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            if(distance< minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }
        return nearest;
    }
}
