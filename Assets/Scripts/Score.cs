using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    float time;
    TextMeshProUGUI text;
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }


    public void displayScore()
    {
        time = Time.time;
        text.text = "Congratulations!\nYour time:\n" + time;
    }
}
