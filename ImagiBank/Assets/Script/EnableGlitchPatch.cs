using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGlitchPatch : MonoBehaviour
{
    public GameObject patchController;
    public GlitchPatch patch;
    public GameObject videoPlayer;
    public AudioSource audioPlayer;
    public bool videoSource;
    public bool updateRoomChanges;
    public UpdateRoomOccupancy vacancyUpdate;
    public Vector3 Position;
    public Vector3 Rotation;

    // Start is called before the first frame update
    void Start()
    {
        runAfter();
    }

    void runAfter()
    {
        if (GameObject.FindWithTag("glitchPatch")) {
            CancelInvoke();
            patchController = GameObject.FindWithTag("glitchPatch");
            patch = patchController.GetComponent<GlitchPatch>();
            patch.enable();
            StartCoroutine("fadeOutSphere");
        }   else    {
            Invoke("runAfter", 0.25f);
        }
        
    }

    void Update()
    {
        
    }

    IEnumerator fadeOutSphere()
    {
        yield return new WaitForSeconds(2.5f);
        patch.fadeOut();
        if (updateRoomChanges) {
            vacancyUpdate.Initiate();
        }

        if (videoSource) {
            playVideo();
        }

        transformPlayer();
    }

    void transformPlayer()
    {
        GameObject player = GameObject.Find("aatest1(Clone)");
        if (player)
        {
            player.transform.position = Position;
            Quaternion spawnRotation = Quaternion.Euler(Rotation);
            player.transform.rotation = spawnRotation;
            // StartCoroutine("fadeOutSphere");
        }   else    {
            Invoke("transformPlayer", 0.25f);
        }
    }

    public void fadeInSphere()
    {
        patch.fadeIn();
    }

    void playVideo()
    {
        videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        audioPlayer.Play();
    }

    public void pauseVideo()
    {
        videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().Pause();
        audioPlayer.Pause();
    }
}
