using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    float y_rotation=0.0f;
    bool OpenChack = false;
    float OffSetRotation = 2.0f;

    public void Open( ) {
        StartCoroutine(D_Open( ));
    }

    IEnumerator D_Open( ) {
        if (!OpenChack) {
            while (true) {
                this.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rotation, 0.0f);
                if (120.0f <= y_rotation) break;
                y_rotation += OffSetRotation;

                yield return null;
            }
            this.gameObject.transform.eulerAngles = new Vector3(0.0f, 120.0f, 0.0f);

            OpenChack = true;
        }
        else {
            while (true) {
                this.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rotation, 0.0f);
                if (0.0f >= y_rotation) break;
                y_rotation -= OffSetRotation;

                yield return null;
            }
            this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            OpenChack = false;
        }
    }
}