using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrBotton : MonoBehaviour {
    int NowCount = 0;
    int Count = 0;
    int[] Number = { 0, 0, 0, 0, 0 ,0};
    int[] CorrectNumber = { 2, 1, 3, 1, 1, 2 };
    bool ChackInput = false;
    bool ChackCorrect =false;
    OpenBox O_Box;

    void Start( ) {
        O_Box = GameObject.Find("Furniture/SubFurniture/Box/Open").GetComponent<OpenBox>( );
    }

    public void ClickRed( ) {
        if (!ChackInput) {
            Number[NowCount] = 1;
            NowCount++;
            Check( );
        }
    }

    public void ClickBlue( ) {
        if (!ChackInput) {
            Number[NowCount] = 2;
            NowCount++;
            Check( );
        }
    }

    public void ClickGreen( ) {
        if (!ChackInput) {
            Number[NowCount] = 3;
            NowCount++;
            Check( );
        }
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
        O_Box.Box_Open( );
    }
}