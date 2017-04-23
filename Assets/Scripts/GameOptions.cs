using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    public Button Button1;
    string countdownText = "";

    //SnakeMovement sm = new SnakeMovement();

    //private int speedOfSnake;

    void Start()
    {
        Pause();
    }

    // Реализуем через булевы переменные

    public void Pause()
    {
        //GetComponent<SnakeMovement>().speed = 0;

        //GameObject SnakeMainObj = GameObject.Find("SnakeMain").GetComponent<SnakeMovement>(); //.GetComponent("SceneManager")();
        //SnakeMainObj.GetComponent<string>();

        //TailMovement.mainSnake.setSpeed(0.0f);
        //speedOfSnake = SnakeMainObj. FindChild("speed").GetComponent<string>();
        //SceneManager sm = SnakeMainObj.GetComponent("SceneManager")();
        
        Time.timeScale = 0;
        //StartCoroutine(Countdown());
 
    }

    public void UnPause()
    {


        Time.timeScale = 1;
        //TailMovement.mainSnake.setSpeed(7.0f);
        Button1.gameObject.SetActive(false);
    }

    void OnGUI()
    {

        //GUI.skin.label.fontSize = 40;

        //if (countdownText != "")    GUI.Label(new Rect((Screen.width - 100) / 2, (Screen.height - 30) / 2, 100, 30), countdownText);

    }

    IEnumerator Countdown()
    {
        countdownText = "3";
        yield return new WaitForSeconds(1);
        countdownText = "2";
        yield return new WaitForSeconds(1);
        countdownText = "1";
        yield return new WaitForSeconds(1);
        countdownText = "0";
        yield return new WaitForSeconds(1);
        countdownText = "Go!!!";
        yield return new WaitForSeconds(1);
        countdownText = "";
    }

}