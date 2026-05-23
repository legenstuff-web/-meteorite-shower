using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCtrlCampaign : MonoBehaviour
{
    public float elapsedTime;
    public float min;
    public float sec;
    public float ms;

    public bool timestopped = false;

    public TMP_Text timeui;
    public TMP_Text goaltimeui;
    public TMP_Text missiongoal;

    public AudioSource buttonClickedSource;

    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("BestTime", 0);
        //PlayerPrefs.SetString("BestTimeString", "TTT");
        elapsedTime = PlayerPrefs.GetInt("Mission");
        min = Mathf.Floor(elapsedTime / 60);
        sec = Mathf.Floor(elapsedTime - (min * 60));
        //Debug.Log(elapsedTime + " " + sec + " " + min);
        ms = (elapsedTime - sec - (min * 60)) * 100;
        goaltimeui.text = System.String.Format("Goal:\n{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms));
        elapsedTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime <= PlayerPrefs.GetInt("Mission"))
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log(elapsedTime);
            min = Mathf.Floor(elapsedTime / 60);
            sec = Mathf.Floor(elapsedTime - (min * 60));
            //Debug.Log(elapsedTime + " " + sec + " " + min);
            ms = (elapsedTime - sec - (min * 60)) * 100;
            timeui.text = System.String.Format("Time:\n{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms));
        }
        else if (elapsedTime >= PlayerPrefs.GetInt("Mission") && GameObject.Find("Ship") != null)
        {
            GameOverScreen(true);
            Destroy(GameObject.Find("Ship"));
        }
        //else if (timestopped == false)
        //{
        //    timestopped = true;
        //    if (elapsedTime > PlayerPrefs.GetFloat("BestTime", 0))
        //    {
        //        Debug.Log("TEST");
        //        PlayerPrefs.SetFloat("BestTime", elapsedTime);
        //        PlayerPrefs.SetString("BestTimeString", System.String.Format("Best Time:\n{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms)));
        //   }
        //}
    }

    public void GameOverScreen(bool victory)
    {
        GameOver.SetActive(true);
        if (victory == true)
        {
            missiongoal.text = "You survived";
            if (PlayerPrefs.GetInt("UnlockedLevels") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevels") + 1);
            }
        } else
        {
            missiongoal.text = "You failed";
        }
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Campaign");
    }

    public void LevelScreen()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    //public IEnumerator Reset()
    // {
    //   buttonClickedSource.Play();
    //    yield return new WaitForSeconds(0.1f);
    //    SceneManager.LoadScene("Game");
    //}
    //public void BacktoHome()
    // {
    //    StartCoroutine(GoBacktoHome());
    // }

    //public IEnumerator GoBacktoHome()
    // {
    //   buttonClickedSource.Play();
    //    yield return new WaitForSeconds(0.1f);
    //    SceneManager.LoadScene("Home");
    //}
}