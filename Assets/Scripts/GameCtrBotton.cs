using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrBotton : MonoBehaviour {
    int NowCount = 0;
    int Count = 0;
    int[] Number = { 0, 0, 0, 0, 0 ,0};
    int[] CorrectNumber = { 2, 1, 3, 1, 1, 2 };
    bool ChackInput = false;
    bool ChackCorrect = false;
    OpenBox O_Box;
    GameObject OB;
    GameObject redButton;
    GameObject blueButton;
    GameObject greenButton;
    public AudioClip Collect;
    public AudioClip False;

    void Start( ) {
        OB = GameObject.Find("Furniture/SubFurniture/Box/Open");
        O_Box= OB.GetComponent<OpenBox>( );
        redButton = GameObject.Find("Walls/MainWalls/BottonSet/RedButton");
        blueButton = GameObject.Find("Walls/MainWalls/BottonSet/BlueButton");
        greenButton = GameObject.Find("Walls/MainWalls/BottonSet/GreenButton");
    }

    public void ClickRed( ) {
        if (!ChackInput) {
            Number[NowCount] = 1;
            NowCount++;
            redButton.GetComponent<AudioSource>().Play();
            Check( );
        }
    }

    public void ClickBlue( ) {
        if (!ChackInput) {
            Number[NowCount] = 2;
            NowCount++;
            blueButton.GetComponent<AudioSource>().Play();
            Check( );
        }
    }

    public void ClickGreen( ) {
        if (!ChackInput) {
            Number[NowCount] = 3;
            NowCount++;
            greenButton.GetComponent<AudioSource>().Play();
            Check( );
        }
    }

    IEnumerator D_Sound( ) {
        yield return new WaitForSeconds(3);

        OB.GetComponent<AudioSource>( ).Play( );
    }

    void Check( ) {
        if (NowCount == 6) {
            for (int i = 0; i < 6; i++) {
                if(Number[i] != CorrectNumber[i]) {
                    Count = 0;
                    break;
                }
                Count++;
            }

            if (Count == 6) {
                ChackCorrect = true;
            }

            if (ChackCorrect) {
                KeyCreate( );
                ChackInput = true;
            }
            else {
                GetComponent<AudioSource>( ).PlayOneShot(False);
                Debug.Log("やり直し");
                for (int i = 0; i < 6; i++) {
                    Number[i] = 0;
                }
                NowCount = 0;
            }
        }
    }

    void KeyCreate( ) {
        Debug.Log("Open");
        GetComponent<AudioSource>().PlayOneShot(Collect);
        O_Box.Box_Open( );
        StartCoroutine(D_Sound( ));
    }
}
