using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlitchPatch : MonoBehaviour
{
    // public TMP_Text loadingText;
    public Material blockingSphereMaterial;
    public Color block;
    public Color nonBlock;
    // public Color highLight;
    float steps = 100.0f;
    float speedInverseModifier = 200.0f;
    static bool fade;
    static float factor = 0;
    static float alpha = 0;
    public bool fadeAudio = false;
    public AudioSource audioSource;
    float audioVolume = 0;
    // static bool text;
    // Start is called before the first frame update
    void Start()
    {
        fade = true;
        factor = 1/steps;
        if (GameObject.FindWithTag("AudioSource"))
        {
            fadeAudio = true;
            audioSource = GameObject.FindWithTag("AudioSource").GetComponent<AudioSource>();
            audioVolume = audioSource.volume;
        }
    }

    // Changes the loading text
    // public void changeLoadingText(string content)
    // {
    //     loadingText.text = content;
    // }

    // public void setTarget(bool target)
    // {
    //     text = target;
    // }

    public void enable()
    {
        // if (text) {
        //     loadingText.color = Color.Lerp(nonBlock, highLight, 1);
        // }   else    {
            blockingSphereMaterial.color = Color.Lerp(nonBlock, block, 1);
        // }
    }
    public void disable()
    {
        // if (text) {
        //     loadingText.color = Color.Lerp(nonBlock, highLight, 0);
        // }   else    {
            blockingSphereMaterial.color = Color.Lerp(nonBlock, block, 0);
        // }
    }

    // Fades out the black patch to reveal the scene
    public void fadeOut()
    {
        fade = false;
        alpha = 1;
        InvokeRepeating(nameof(lerp), 0.1f, 1.0f/speedInverseModifier);
    }

    // Fades in the black patch to hide the scene
    public void fadeIn()
    {
        Debug.Log("fadein");
        fade = true;
        alpha = 0;
        InvokeRepeating(nameof(lerp), 0.1f, 1.0f/speedInverseModifier);
    }

    public void lerp()
    {
        if (fade) {
            alpha += factor;
        }   else    {
            alpha -= factor;
        }
        if (alpha < 0 || alpha > 1) {
            CancelInvoke();
        }   else    {

            // Debug.Log(alpha);
            // if (text) {
            //     loadingText.color = Color.Lerp(nonBlock, highLight, alpha);
            // }   else    {
                blockingSphereMaterial.color = Color.Lerp(nonBlock, block, alpha);
                if (fadeAudio)
                {
                    float volume = (1-alpha)*audioVolume;
                    audioSource.volume = volume;
                }
            // }
        }
    }
}
