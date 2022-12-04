using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using TMPro;

public class VrLogin : MonoBehaviour
{
    string authAapi = "49219b2e-3a4f-4c4e-971b-371957df4ff6";
    string apiStore = "http://34.170.21.181:80";
    string authenticationRoute = "/vrauthunity";
    string loginCode;
    public float notificationDelay = 5f;

    [System.Serializable]
    public class Schedules
    {
        public string summary;
        public string startTime;
        public string endTime;
        public string timing;
    }
    // userdata class
    public class UserData
    {
        public string name;
        public string type;
        public bool enterVR;
        public string id;
        public int status;
        public string roomId;
        public Schedules[] schedules;
    }

    public static UserData userDetails = new UserData();

    public Button loginButton;
    public TMP_InputField loginCodeInput;
    public TMP_Text status;
    public EnableGlitchPatch controller;

    // Start is called before the first frame update
    void Start()
    {
        loginCodeInput.onValueChanged.AddListener(UpdateCode);
        Button btn = loginButton.GetComponent<Button>();
        btn.onClick.AddListener(UserAuth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UserAuth()
    {

        GameObject patchController = GameObject.FindWithTag("glitchPatch");
        GlitchPatch patch = patchController.GetComponent<GlitchPatch>();
        
        // Fetch user details
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(apiStore + authenticationRoute + "?code=" + loginCode + "&apiKey=" + authAapi));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        userDetails = JsonUtility.FromJson<UserData>(jsonResponse);

        // If user is allowed to enter in VR and the status is 200, allow the user to go further
        if (userDetails.enterVR && userDetails.status == 200) {
            
            patch.fadeIn();
            Invoke(nameof(SwitchScene), 3);

        // If the user is not allowed to enter VR, display an error message
        }   else    {
            setStatusMessage(false);
            StartCoroutine(clearStatus());
        }
    }

    // Wait for notification duration and clear the notification
    IEnumerator clearStatus()
    {
        yield return new WaitForSeconds(notificationDelay);
        setStatusMessage(true);
    }

    // Set status message
    public void setStatusMessage(bool clear)
    {
        if (clear) {
            status.text = " ";
        }   else    {
            status.text = userDetails.id;
        }
    }

    // update the login code based on user input
    public void UpdateCode(string input) {
        loginCode = input;
    }

    // Go to banking lobby and join the designated room
    public void SwitchScene()
    {   
        controller.pauseVideo();
        VirtualWorldManager.Instance.LeaveRoomAndLoadScene(userDetails.roomId);
    }

}
