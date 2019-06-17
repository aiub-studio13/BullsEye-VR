using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BaseBallBatInteractable : MonoBehaviour
{
    [HideInInspector]
    public HandController uActiveHand = null;
}
