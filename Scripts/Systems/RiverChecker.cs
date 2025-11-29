using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RiverChecker : MonoBehaviourPun
{
    public Seeker1 seeker;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WorldSpawner" || other.gameObject.tag == "WorldSpawner2" || other.gameObject.tag == "WorldSpawner3" || other.gameObject.tag == "WorldSpawner4" || other.gameObject.tag == "WorldSpawner5")
        {
            if (seeker.isRiverTurn == false)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    photonView.RPC("DestroyMe", RpcTarget.All);
                }
            }
        }
    }

    [PunRPC]
    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
