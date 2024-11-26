using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Seconds Overall
    static public int timeLeft = 60;
    //UI Text Object
    public Text countdown;
    void Start()
    {
        //Calling method LoseTime
        StartCoroutine("LoseTime");
    }
    void Update()
    {
        //Showing the Score on the Canvas
        countdown.text = ("" + timeLeft);
    }
    //Simple Coroutine
        IEnumerator LoseTime()
    {
        while (true)
        {
            //waiting each second
            yield return new WaitForSeconds(1);
            //reducing the time by 1
            timeLeft--;
        }
    } 
    public void RestartStage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
