using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class OnlineStatusUpdater : MonoBehaviour
{
    WebSocket ws;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(ws);
        // ws = new WebSocket("ws://192.168.1.2:3000");
        // ws.connect();
        // ws.OnMessage += (sender, e) => {
        //     Debug.Log("Message Recieved from" + ((WebSocket)sender).url + " Data:" + e.Data);
        // };
    }

    // Update is called once per frame
    private void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ws.Send("Hello");
        }
    }
}
