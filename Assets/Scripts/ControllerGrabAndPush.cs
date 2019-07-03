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

    private GameObject collidingObject;
    private GameObject objectInHand;

    private GameCtrBotton GCB;
    private OpenSmallWindow OSW;
    private ChangeParsonScale CPS;

    private void Start( ) {
        trackedObj = GetComponent<SteamVR_TrackedObject>( );

        GCB = GameObject.Find("GameController").GetComponent<GameCtrBotton>( );
        OSW = GameObject.Find("Furniture/MainFurniture/TVSet").GetComponent<OpenSmallWindow>( );
        CPS = GameObject.Find("[CameraRig]").GetComponent<ChangeParsonScale>( );
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
            Debug.Log("赤"); 
        }

        if (collider.gameObject.name == "BlueButton") {
            GCB.ClickBlue( );
            Debug.Log("青");
        }

        if (collider.gameObject.name == "GreenButton") {
            GCB.ClickGreen( );
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
    }

    private void OpenDoorUnpossible( ) {
            LL = false;
            LR = false;
            RL = false;
            RR = false;
    }

    public void OnTriggerEnter(Collider other) {
        SetCollidingObject(other);
        PushButtonPossible(other);
        OpenDoorPossible(other);
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
            if (collidingObject) {
                GrabObject( );
            }

            if (LL) {
                OSW.LL_Open( );
            }

            if (LR) {
                OSW.LR_Open( );
            }

            if (RL) {
                OSW.RL_Open( );
            }

            if (RR) {
                OSW.RR_Open( );
            }
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
            if (objectInHand) {
                ReleaseObject( );
            }
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            CPS.ChangeScale( );
        }
    }
}