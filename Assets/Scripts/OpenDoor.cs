using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    float y_rotation = 0.0f;
    float OffSetRotation = 2.0f;
    public bool CanOpen = false;
    AudioSource O_D;
    AudioSource C_D;

    void Start( ) {
        O_D = GameObject.Find("Furniture/MainFurniture/Door").GetComponent<AudioSource>( );
        C_D = GameObject.Find("Furniture/MainFurniture/Door/Bord").GetComponent<AudioSource>( );
    }

    public void Open( ) {
        Debug.Log("kkk");
        if (CanOpen) {
            StartCoroutine(D_Open( ));
            O_D.Play( );
        }
        else {
            C_D.Play( );
        }
    }

    IEnumerator D_Open( ) {
        while (true) {
            this.gameObject.transform.eulerAngles = new Vector3(0.0f, y_rotation, 0.0f);
            if (120.0f <= y_rotation) break;
            y_rotation += OffSetRotation;

            yield return null;
            }
        this.gameObject.transform.eulerAngles = new Vector3(0.0f, 120.0f, 0.0f);
    }
}
