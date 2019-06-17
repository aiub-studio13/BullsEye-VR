using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMovement : MonoBehaviour
{
    Vector3 realPosition;
    Quaternion realRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        GetComponent<PhotonView>().RPC("ChangePosition", PhotonTargets.All, transform.position,transform.rotation);
    }

    [PunRPC]
    public void ChangePosition(Vector3 position,Quaternion rotation)
    {
            realPosition = position;
            realRotation = rotation;
            transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
        
    }
    

    
}
