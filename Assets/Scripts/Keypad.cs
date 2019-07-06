using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;


public class Keypad : MonoBehaviour
{
    int[] passcode = { 3, 5, 1, 9, 0 };
    List<int> inputcode = new List<int>();
    bool check;
    OpenDoor doorFlag;
    TextMeshProUGUI displayText;
    AudioSource unlock;

    void Start()
    {
        doorFlag = GameObject.Find("Furniture/MainFurniture/Door").GetComponent<OpenDoor>();
        displayText = GameObject.Find("Furniture/MainFurniture/keypad/Display").GetComponent<TextMeshProUGUI>();
        displayText.text = "";
        unlock = GameObject.Find("Furniture/MainFurniture/Door/Bord").GetComponent<AudioSource>();
    }

    public void pushNumberKey(int number)
    {
        inputcode.Add(number);
        displayText.text += number;
    }

    public void pushGreenKey()
    {
        check = inputcode.SequenceEqual(passcode);
        if(check) {
            doorFlag.CanOpen = true;
            unlock.Play();
        }
        displayText.text = "";
    }

    public void pushRedKey()
    {
        inputcode.Clear();
        displayText.text = "";
    }

}
