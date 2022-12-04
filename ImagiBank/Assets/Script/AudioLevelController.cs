using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLevelController : MonoBehaviour
{
    public float ambientVolume;
    public AudioSource videoAudio;

    public void toggleMute()
    {
        if (videoAudio.volume > 0)
        {
            videoAudio.volume = 0;
        }   else    {
            videoAudio.volume = ambientVolume;
        }
    }

    public void changeVolume(float volume)
    {
        videoAudio.volume = volume;
    }
}
