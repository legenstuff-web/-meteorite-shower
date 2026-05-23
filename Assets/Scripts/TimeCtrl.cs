using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCtrl : MonoBehaviour
{
    public float elapsedTime;
    public float min;
    public float sec;
    public float ms;

    public bool timestopped = false;

    public TMP_Text timeui;
    public TMP_Text besttimeui;

    public AudioSource buttonClickedSource;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("BestTime", 0);
        //PlayerPrefs.SetString("BestTimeString", "TTT");
        if (PlayerPrefs.GetFloat("BestTime", 0) > 0)
        {
            besttimeui.text = PlayerPrefs.GetString("BestTimeString");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Ship") != null)
        {
            elapsedTime += Time.deltaTime;
            //Debug.Log(elapsedTime);
            min = Mathf.Floor(elapsedTime / 60);
            sec = Mathf.Floor(elapsedTime - (min * 60));
            //Debug.Log(elapsedTime + " " + sec + " " + min);
            ms = (elapsedTime - sec - (min*60)) * 100;
            timeui.text = System.String.Format("Time:\n{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms));
        }
        else if (timestopped == false)
        {
            timestopped = true;
            if (elapsedTime > PlayerPrefs.GetFloat("BestTime", 0))
            {
                Debug.Log("TEST");
                PlayerPrefs.SetFloat("BestTime", elapsedTime);
                PlayerPrefs.SetString("BestTimeString", System.String.Format("Best Time:\n{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms)));
                besttimeui.text = System.String.Format("Best Time:\n{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms));
            }
        }
    }

    public void CallReset()
    {
        StartCoroutine(Reset());
    }

    public IEnumerator Reset()
    {
        buttonClickedSource.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Game");
    }
    public void BacktoHome()
    {
        StartCoroutine(GoBacktoHome());
    }

    public IEnumerator GoBacktoHome()
    {
        buttonClickedSource.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Home");
    }
}
