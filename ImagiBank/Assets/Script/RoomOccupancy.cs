using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;

public class RoomOccupancy : MonoBehaviour
{
    int roomOccupied = 0;
    string authAapi = "8530892c-c53e-4611-b8cd-036a6128469e";
    string apiStore = "http://34.170.21.181:80";
    string updateOccupancyRoute = "/updateRoomOccupancy";
    string getOccupancyRoute = "/getRoomOccupancy";
    public class Occupancy
    {
        public bool occupied;
        public string userId;
    }

    // public static VrLogin login;
    public Occupancy occupancy = new Occupancy();

    public void clear()
    {
        roomOccupied = 0;
        updateRoomOccupancyData();
    }

    public void fill()
    {
        roomOccupied = 1;
        updateRoomOccupancyData();
    }

    public void updateRoomOccupancyData()
    {
        Debug.Log(VrLogin.userDetails.id);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiStore + updateOccupancyRoute + "?id=" + VrLogin.userDetails.id + "&apiKey=" + authAapi + "&roomId=" + VrLogin.userDetails.roomId + "&occupancy=" + roomOccupied));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        occupancy = JsonUtility.FromJson<Occupancy>(jsonResponse);
    }

    public void getRoomOccupancyData()
    {
        Debug.Log(VrLogin.userDetails.type);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiStore + getOccupancyRoute + "?id=" + VrLogin.userDetails.id + "&apiKey=" + authAapi + "&roomId=" + VrLogin.userDetails.roomId));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        occupancy = JsonUtility.FromJson<Occupancy>(jsonResponse);
    }
}
