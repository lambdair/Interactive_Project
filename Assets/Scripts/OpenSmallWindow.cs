using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSmallWindow : MonoBehaviour {
    GameObject ll_transrate;
    GameObject lr_transrate;
    GameObject rl_transrate;
    GameObject rr_transrate;
    float y_ll_rotation = -90.0f;
    float y_lr_rotation = -90.0f;
    float y_rl_rotation = -90.0f;
    float y_rr_rotation = -90.0f;
    bool ll_OpenChack = false;
    bool lr_OpenChack = false;
    bool rl_OpenChack = false;
    bool rr_OpenChack = false;
    float OffSetRotation = 2.0f;

    public bool KeyRock = true;

    void Start( ) {
        ll_transrate = transform.Find("Left_Left").gameObject;
        lr_transrate = transform.Find("Left_Right").gameObject;
        rl_transrate = transform.Find("Right_Left").gameObject;
        rr_transrate = transform.Find("Right_Right").gameObject;
    }

    public void LL_Open( ) {
        StartCoroutine(LeftLeft( ));
        Debug.Log("LL");
    }

    public void LR_Open( ) {
        if (!KeyRock) {
            StartCoroutine(LeftRight( ));
            Debug.Log("空いてる");
        }
        else {
            Debug.Log("閉まってる");
        }
        Debug.Log("LR");
    }

    public void RL_Open( ) {
        StartCoroutine(RightLeft( ));
        Debug.Log("RL");
    }

    public void RR_Open( ) {
        StartCoroutine(RightRight( ));
        Debug.Log("RR");
    }

    IEnumerator LeftLeft( ) {

        if (!ll_OpenChack) {
            while (true) {
                ll_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_ll_rotation, 0.0f);
                if (0.0f <= y_ll_rotation) break;
                y_ll_rotation += OffSetRotation;

                yield return null;
            }
            ll_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            ll_OpenChack = true;
        }
        else {
            while (true) {
                ll_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_ll_rotation, 0.0f);
                if (-90.0f >= y_ll_rotation) break;
                y_ll_rotation -= OffSetRotation;

                yield return null;
            }
            ll_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);

            ll_OpenChack = false;
        }
    }

    IEnumerator LeftRight( ) {
        if (!lr_OpenChack) {
            while (true) {
                lr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_lr_rotation, 0.0f);
                if (-180.0f >= y_lr_rotation) break;
                y_lr_rotation -= OffSetRotation;

                yield return null;
            }
            lr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);

            lr_OpenChack = true;
        }
        else {
            while (true) {
                lr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_lr_rotation, 0.0f);
                if (-90.0f <= y_lr_rotation) break;
                y_lr_rotation += OffSetRotation;

                yield return null;
            }
            lr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);

            lr_OpenChack = false;
        }
    }

    IEnumerator RightLeft( ) {
        if (!rl_OpenChack) {
            while (true) {
                rl_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rl_rotation, 0.0f);
                if (0.0f <= y_rl_rotation) break;
                y_rl_rotation += OffSetRotation;

                yield return null;
            }
            rl_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            rl_OpenChack = true;
        }
        else {
            while (true) {
                rl_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rl_rotation, 0.0f);
                if (-90.0f >= y_rl_rotation) break;
                y_rl_rotation -= OffSetRotation;

                yield return null;
            }
            rl_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);

            rl_OpenChack = false;
        }
    }

    IEnumerator RightRight( ) {
        if (!rr_OpenChack) {
            while (true) {
                rr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rr_rotation, 0.0f);
                if (-180.0f >= y_rr_rotation) break;
                y_rr_rotation -= OffSetRotation;

                yield return null;
            }
            rr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);

            rr_OpenChack = true;
        }
        else {
            while (true) {
                rr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rr_rotation, 0.0f);
                if (-90.0f <= y_rr_rotation) break;
                y_rr_rotation += OffSetRotation;

                yield return null;
            }
            rr_transrate.gameObject.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);

            rr_OpenChack = false;
        }
    }
}