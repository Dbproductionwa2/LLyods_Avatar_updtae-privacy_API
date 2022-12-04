using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;

public class ServerLog : MonoBehaviour
{
    private string serverLogAPI = "8530892c-c53e-4611-b8cd-036a6128469e";
    private string apiStore = "http://192.168.1.2:80";
    private string logRoute = "/serverLog";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Send(String log) {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiStore + logRoute + "?id=" + VrLogin.userDetails.id + "&apiKey=" + serverLogAPI + "&Log=" + log));
        // HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        // StreamReader reader = new StreamReader(response.GetResponseStream());
        // string jsonResponse = reader.ReadToEnd();
        // occupancy = JsonUtility.FromJson<Occupancy>(jsonResponse);
    }
}
