using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject GenericVRPlayerPrefab;

    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (PhotonNetwork.IsConnectedAndReady) 
        {
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);
        
        }
    }

    public void avaload() 
    {
        Debug.Log("tHE pHOTON sTATUS IS "+PhotonNetwork.IsConnectedAndReady);
        
            
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);

        
        
        
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}