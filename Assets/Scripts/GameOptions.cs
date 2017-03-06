using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour

{
    public Button Button1;
    void Start()
    {
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;

    }

    public void UnPause()
    {
        Time.timeScale = 1;
        Button1.gameObject.SetActive(false);
    }
}