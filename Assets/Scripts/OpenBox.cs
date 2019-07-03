using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {
    float z_rotation = 0.0f;
    bool OpenChack = false;
    float OffSetRotation = 2.0f;

    public void Box_Open( ) {
        StartCoroutine(D_Open( ));
    }

    IEnumerator D_Open( ) {
        if (!OpenChack) {
            while (true) {
                this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, z_rotation);
                if (-90.0f >= z_rotation) break;
                z_rotation -= OffSetRotation;

                yield return null;
            }
            this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);

            OpenChack = true;
        }
        else {
            while (true) {
                this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, z_rotation);
                if (0.0f <= z_rotation) break;
                z_rotation += OffSetRotation;

                yield return null;
            }
            this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            OpenChack = false;
        }
    }
}