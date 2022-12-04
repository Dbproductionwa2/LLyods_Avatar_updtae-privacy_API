using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UpdateRoomOccupancy : MonoBehaviour
{
    int maxPlayerCount = 2;
    int currentPlayerCount = 0;
    public RoomOccupancy occupancy;
    public bool lookForChanges;
    public bool clearOnce;

    void Start()
    {
        lookForChanges = false;
        clearOnce = true;
    }

    public void Initiate()
    {
        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        lookForChanges = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookForChanges) {
            if (currentPlayerCount != PhotonNetwork.CurrentRoom.PlayerCount || (clearOnce && currentPlayerCount == 1))
            {
                currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;

                if (clearOnce)
                {
                    clearOnce = !clearOnce;
                }

                if (currentPlayerCount < maxPlayerCount) {

                    // If the last player in the room is advisor
                    // Advisors must stay back as they will be responsible
                    // to declare the room vacant and allow others to enter

                    if (VrLogin.userDetails.type == "Associate")
                    {
                        Debug.Log("Cleared room occupancy!");
                        occupancy.clear();
                    }
                }
            }
            // Debug.Log("Looking for player changes");
            
        }
    }
}
