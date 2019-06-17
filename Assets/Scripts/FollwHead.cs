using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwHead : Photon.MonoBehaviour
{
    public int index = 1;

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            switch (index)
            {
                case 1:
                    transform.position = ViveManager.instance.head.transform.position;
                    transform.rotation = ViveManager.instance.head.transform.rotation;
                    break;
                case 2:
                    transform.position = ViveManager.instance.leftHand.transform.position;
                    transform.rotation = ViveManager.instance.leftHand.transform.rotation;
                    break;
                case 3:
                    transform.position = ViveManager.instance.rightHand.transform.position;
                    transform.rotation = ViveManager.instance.rightHand.transform.rotation;
                    break;
            }

        }
        
    }
}
