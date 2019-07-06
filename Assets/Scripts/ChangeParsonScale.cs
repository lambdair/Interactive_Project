using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParsonScale : MonoBehaviour {
    public bool SmallFlag = false;
    float p_scale = 1.0f;
    float offsetscale = 0.025f;
    GameObject s_bottom;
    GameObject f_bottom_1;
    GameObject f_bottom_2;
    GameObject C_GO;

    private void Start( ) {
        s_bottom = GameObject.Find("Walls/MainWalls/Bottom_2");
        f_bottom_1 = GameObject.Find("Walls/SubWalls/SBottom/SPlane_1");
        f_bottom_2 = GameObject.Find("Walls/SubWalls/SBottom/SPlane_2");
    }

    public void ChangeScale( ) {
        if (!SmallFlag) {
            StartCoroutine(Down( ));
            Movable_Place( );
            SmallFlag = true;
        }
        else {
            StartCoroutine(Reset( ));
            Unmovable_Place( );
            SmallFlag = false;
        }
    }

    IEnumerator Down( ) {
        while (true) {
            this.gameObject.transform.localScale = new Vector3(p_scale, p_scale, p_scale);
            if (p_scale <= 0.2f) break;
            p_scale -= offsetscale;
            yield return null;
        }
        this.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    IEnumerator Reset( ) {
        while (true) {
            this.gameObject.transform.localScale = new Vector3(p_scale, p_scale, p_scale);
            if (p_scale >= 1.0f) break;
            p_scale += offsetscale;
            yield return null;
        }
        this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Movable_Place( ) {
        s_bottom.layer = LayerMask.NameToLayer("MovablePlace");
        f_bottom_1.layer = LayerMask.NameToLayer("MovablePlace");
        f_bottom_2.layer = LayerMask.NameToLayer("MovablePlace");
    }

    void Unmovable_Place( ) {
        s_bottom.layer = LayerMask.NameToLayer("Default");
        f_bottom_1.layer = LayerMask.NameToLayer("Default");
        f_bottom_2.layer = LayerMask.NameToLayer("Default");
    }
}