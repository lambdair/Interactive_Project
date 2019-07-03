using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour {
    OpenSmallWindow OSW;

    void Start( ) {
        OSW = GameObject.Find("Furniture/MainFurniture/TVSet").GetComponent<OpenSmallWindow>( );
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Left_Right") {
            OSW.KeyRock = false;
            Debug.Log("当たった");
        }
        else {
            Debug.Log("当たらなかった");
        }
    }
}