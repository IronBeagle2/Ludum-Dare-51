using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayYoureFired : MonoBehaviour
{
    public static int score;
    public static int delivered;
    public TMP_Text scoreTxt;
    public TMP_Text deliversTxt;

    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();

        scoreTxt.text = "Score: " + score;
        deliversTxt.text = "Deliveries: " + delivered;
    }
}
