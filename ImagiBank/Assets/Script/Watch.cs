using UnityEngine;
using TMPro;

public class Watch : MonoBehaviour
{
    public TextMeshProUGUI Clock;
    // Start is called before the first frame update
    void Start()
    {
        GetTime();
        var time = System.DateTime.Now;
        InvokeRepeating(nameof(GetTime), 60 - time.Second, 60);
    }

    void GetTime()
    {
        var time = System.DateTime.Now;
        string timeString;
        if (time.Hour.ToString().Length == 1)
        {
            timeString = "0" + time.Hour;
        }
        else
        {
            timeString = "" + time.Hour;
        }
        timeString += ":";
        if (time.Minute.ToString().Length == 1)
        {
            timeString += "0" + time.Minute;
        }
        else
        {
            timeString += time.Minute;
        }
        Clock.text = timeString;
    }
}
