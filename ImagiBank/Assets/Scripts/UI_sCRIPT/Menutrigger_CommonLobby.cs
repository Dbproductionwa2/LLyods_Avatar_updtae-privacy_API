using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class Menutrigger_CommonLobby : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject Keyboardd;
    //public Canvas Menu_UI;

    [SerializeField]
    GameObject UIController;

    [SerializeField]
    GameObject VRkeyboardd;

    [SerializeField]
    GameObject VRkeyboardd1;

    [SerializeField]
    GameObject VRkeyboardd2;

    [SerializeField]
    GameObject BaseController;

    [SerializeField]
    GameObject UICanvasGameobject;

    bool isUICanvasActive = false;

    XRRayInteractor intersector;
    XRInteractorLineVisual lineVisual;

    private void Start()
    {
        //Deactivating UI Canvas Gameobject by default
        if (UICanvasGameobject != null)
        {
         GameObject panel =  UICanvasGameobject.transform.GetChild(0).gameObject;
         //   panel.SetActive(false);
        }
        runAfter();
    }

    void runAfter()
    {
        if (GameObject.Find("/aatest1(Clone)/XR Rig/Camera Offset/LeftHand Parent/LeftHand UI Controller") && GameObject.Find("/aatest1(Clone)/XR Rig/Camera Offset/LeftHand Parent/LeftHand Base Controller"))
        {
            UIController = GameObject.Find("/aatest1(Clone)/XR Rig/Camera Offset/LeftHand Parent/LeftHand UI Controller");
            BaseController = GameObject.Find("/aatest1(Clone)/XR Rig/Camera Offset/LeftHand Parent/LeftHand Base Controller");
        
            //Deactivating UI Controller by default
            intersector = UIController.GetComponent<XRRayInteractor>();
            lineVisual = UIController.GetComponent<XRInteractorLineVisual>();

            if (intersector && lineVisual) {
                intersector.enabled = false;
                lineVisual.enabled = false;
            }   else    {
                Invoke("runAfter", 0.25f);
            }
        }   else    {
            Invoke("runAfter", 0.25f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isUICanvasActive = true;

            //Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
            UIController.GetComponent<XRRayInteractor>().enabled = true;
            UIController.GetComponent<XRInteractorLineVisual>().enabled = true;

            //Deactivating Base Controller by disabling its XR Direct Interactor
            BaseController.GetComponent<XRDirectInteractor>().enabled = false;



            //Activating the UI Canvas Gameobject
            //  UICanvasGameobject.SetActive(true);

            GameObject panel = UICanvasGameobject.transform.GetChild(0).gameObject;
            panel.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isUICanvasActive = false;

        //De-Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
        UIController.GetComponent<XRRayInteractor>().enabled = false;
        UIController.GetComponent<XRInteractorLineVisual>().enabled = false;

        //Activating Base Controller by disabling its XR Direct Interactor
        BaseController.GetComponent<XRDirectInteractor>().enabled = true;

        //De-Activating the UI Canvas Gameobject
        //UICanvasGameobject.SetActive(false);

        GameObject panel = UICanvasGameobject.transform.GetChild(0).gameObject;
        panel.SetActive(false);

        VRkeyboardd.SetActive(false);
        VRkeyboardd1.SetActive(false);
        VRkeyboardd2.SetActive(false);
    }



}
