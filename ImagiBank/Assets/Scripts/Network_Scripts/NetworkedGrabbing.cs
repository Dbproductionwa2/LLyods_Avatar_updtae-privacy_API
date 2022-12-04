using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks , IPunOwnershipCallbacks
{
    PhotonView m_photonview;
    Rigidbody rb;

    bool isBeingHeld = false;
    private void Awake()
    {
        m_photonview = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            rb.isKinematic = true;
            gameObject.layer = 11;
        }
        else 
        {
            rb.isKinematic = false;
            gameObject.layer = 9;
        }
    }

    private void TransferOwnership() 
    {
        m_photonview.RequestOwnership();
    
    }

    public void OnSelectEntered() 
    {

        Debug.Log("Grabbed");
        m_photonview.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);
        TransferOwnership();

        if (m_photonview.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("we do not request the ownership. Already mine");
        }
        else 
        {
            TransferOwnership();
        }
        
    }

    public void OnSelectedExited() 
    {

        Debug.Log("Released");
        m_photonview.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);

    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != m_photonview) 
        {
            return;
        }
        Debug.Log("Ownership Requested for : " + targetView.name + " from " + requestingPlayer.NickName);
        m_photonview.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("OnOwnership Transferred to " + targetView.name + " from " + previousOwner.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        
    }

    [PunRPC]
    public void StartNetworkGrabbing() 
    {
        isBeingHeld = true;
    
    }

    [PunRPC]
    public void StopNetworkGrabbing()
    {
        isBeingHeld = false;
    }
}
