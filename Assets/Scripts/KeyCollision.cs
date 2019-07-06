using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour {
    OpenSmallWindow OSW;
    Vector3 NowPosition;
    Vector3 PastPosition;
    public float D_time = 0.0f;
    AudioSource unrock;
    bool Flag = false;

    void Start( ) {
        OSW = GameObject.Find("Furniture/MainFurniture/TVSet").GetComponent<OpenSmallWindow>( );
        unrock = GameObject.Find("Furniture/MainFurniture/TVSet/Left_Right").GetComponent<AudioSource>( );
    }

    private void OnCollisionEnter(Collision collision) {
        if (!Flag) {
            if (collision.gameObject.name == "Left_Right") {
                OSW.KeyRock = false;
                unrock.Play( );
                Debug.Log("当たった");
                Flag = true;
            }
            else {
                Debug.Log("当たらなかった");
            }
        }
    }

    void Update( ) {
        NowPosition = this.gameObject.transform.position;

        if(NowPosition != new Vector3(-3.75f, 0.749279f, -0.5f)) {
            if(NowPosition == PastPosition) {
                D_time += Time.deltaTime;
            }
            else {
                D_time = 0.0f;
            }
        }

        if(15.0f < D_time) {
            this.gameObject.transform.position = new Vector3(-3.75f, 0.749279f, -0.5f);
            D_time = 0.0f;
        }

        PastPosition = NowPosition;
    }
}