using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using TMPro;

public class MeetingInfo : MonoBehaviour
{
    public TMP_Text meetingTimings;
    public TMP_Text meetingAgenda;
    public TMP_Text meetingStatus;
    public Color upcomingMeetingColor;
    public Color ongoingMeetingColor;
    // Start is called before the first frame update
    void Start()
    {
        
        if (VrLogin.userDetails.type == "Customer") {
            meetingAgenda.text = VrLogin.userDetails.schedules[0].summary;
            meetingTimings.text = VrLogin.userDetails.schedules[0].timing;
            
        }   else if (VrLogin.userDetails.type == "Associate")    {
            
            // Update info for associate as well
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
