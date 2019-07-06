using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabAndPush : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private bool LL = false;
    private bool LR = false;
    private bool RL = false;
    private bool RR = false;
    private bool n_door = false;

    private GameObject collidingObject;
    private GameObject objectInHand;
    private AudioSource ButtonSound;

    private GameCtrBotton GCB;
    private OpenSmallWindow OSW;
    private ChangeParsonScale CPS;
    private OpenDoor OD; 

    private void Start( ) {
        trackedObj = GetComponent<SteamVR_TrackedObject>( );

        ButtonSound = GameObject.Find("Furniture/MainFurniture/keypad/Cube").GetComponent<AudioSource>( );

        GCB = GameObject.Find("GameController").GetComponent<GameCtrBotton>( );
        OSW = GameObject.Find("Furniture/MainFurniture/TVSet").GetComponent<OpenSmallWindow>( );
        CPS = GameObject.Find("[CameraRig]").GetComponent<ChangeParsonScale>( );
        OD = GameObject.Find("Furniture/MainFurniture/Door").GetComponent<OpenDoor>( );
    }

    private void SetCollidingObject(Collider collider) {
        if (collidingObject || !collider.GetComponent<Rigidbody>( )) {
            return;
        }

        collidingObject = collider.gameObject;
    }

    private void PushButtonPossible(Collider collider) {
        if (collider.gameObject.name == "RedButton") {
            GCB.ClickRed( );
            Controller.TriggerHapticPulse(2000);
            Debug.Log("赤"); 
        }

        if (collider.gameObject.name == "BlueButton") {
            GCB.ClickBlue( );
            Controller.TriggerHapticPulse(2000);
            Debug.Log("青");
        }

        if (collider.gameObject.name == "GreenButton") {
            GCB.ClickGreen( );
            Controller.TriggerHapticPulse(2000);
            Debug.Log("緑");
        }
    }

    private void OpenDoorPossible(Collider other) {
        if (other.gameObject.name == "Left_Left") {
            LL = true;
        }
        else {
            LL = false;
        }

        if (other.gameObject.name == "Left_Right") {
            LR = true;
        }
        else {
            LR = false;
        }

        if (other.gameObject.name == "Right_Left") {
            RL = true;
        }
        else {
            RL = false;
        }

        if (other.gameObject.name == "Right_Right") {
            RR = true;
        }
        else {
            RR = false;
        }

        if (other.gameObject.name == "Sphere") {
            n_door = true;
        }
        else {
            n_door = false;
        }
    }

    private void OpenDoorUnpossible( ) {
        LL = false;
        LR = false;
        RL = false;
        RR = false;
        n_door = false;
    }

    private void KeyPadEnter(Collider other) {
        if (other.gameObject.name == "K_Button_1") {
            Controller.TriggerHapticPulse(2000);
            ButtonSound.Play( );

        }
        if (other.gameObject.name == "K_Button_2") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_3") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_4") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_5") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_6") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_7") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_8") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_9") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_0") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_Green") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
        if (other.gameObject.name == "K_Button_Red") {
            ButtonSound.Play( );
            Controller.TriggerHapticPulse(2000);


        }
    }

    public void OnTriggerEnter(Collider other) {
        SetCollidingObject(other);
        PushButtonPossible(other);
        OpenDoorPossible(other);
        KeyPadEnter(other);
    }

    public void OnTriggerStay(Collider other) {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other) {
        if (!collidingObject) {
            return;
        }
        collidingObject = null;

        OpenDoorUnpossible( );
        Debug.Log("外れた");
    }

    private void GrabObject( ) {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint( );
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>( );
    }

    private FixedJoint AddFixedJoint( ) {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>( );
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject( ) {
        if (GetComponent<FixedJoint>( )) {
            GetComponent<FixedJoint>( ).connectedBody = null;
            Destroy(GetComponent<FixedJoint>( ));

            objectInHand.GetComponent<Rigidbody>( ).velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>( ).angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;
    }

    private void Update( ) {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            if (collidingObject && !CPS.SmallFlag) {
                GrabObject( );
                Controller.TriggerHapticPulse(2000);
            }

            if (LL) {
                OSW.LL_Open( );
                Controller.TriggerHapticPulse(2000);
            }

            if (LR) {
                OSW.LR_Open( );
                Controller.TriggerHapticPulse(2000);
            }

            if (RL) {
                OSW.RL_Open( );
                Controller.TriggerHapticPulse(2000);
            }

            if (RR) {
                OSW.RR_Open( );
                Controller.TriggerHapticPulse(2000);
            }

            if (n_door)
            {
                OD.Open();
                Controller.TriggerHapticPulse(2000);
            }
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
            if (objectInHand) {
                ReleaseObject( );
            }
        }

        if (objectInHand&& CPS.SmallFlag)
        {
            ReleaseObject();
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            CPS.ChangeScale( );
        }
    }
}