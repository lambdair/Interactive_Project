using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private Vector3 hitPoint;
    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    private Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    public LayerMask Defalt;
    private bool shouldTeleport;
    private Vector3 difference;
    private RaycastHit hit;
    private ChangeParsonScale CPS;

    void Start( ) {
        trackedObj = GetComponent<SteamVR_TrackedObject>( );
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
        reticle.SetActive(false);
        teleportReticleOffset = new Vector3(0.0f, 0.0125f, 0.0f);
        CPS = GameObject.Find("[CameraRig]").GetComponent<ChangeParsonScale>( );
    }

    private void P_Teleport( ) {
        shouldTeleport = false;
        reticle.SetActive(false);
        difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }

    void Update( ) {
        if (!CPS.SmallFlag) {
            teleportReticleTransform.localScale = new Vector3(0.2f, 0.025f, 0.2f);
            teleportReticleOffset = new Vector3(0.0f, 0.0125f, 0.0f);
        }
        else {
            teleportReticleTransform.localScale = new Vector3(0.08f, 0.01f, 0.08f);
            teleportReticleOffset = new Vector3(0.0f, 0.005f, 0.0f);
        }

        if (Controller.GetHairTrigger()) {
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 50, teleportMask)) {
                hitPoint = hit.point;
                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                shouldTeleport = true;
            }
            else {
                reticle.SetActive(false);
                shouldTeleport = false;
            }
        }

        if (Controller.GetHairTriggerUp() && shouldTeleport) {
            P_Teleport( );
        }
    }
}