using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UICtrl : MonoBehaviour
{
    public GameObject Levels;
    public GameObject Mission;

    public int[] LevelMissions;
    public int[] LevelDifficulties;
    public GameObject[] LevelLocks;
    public float min;
    public float sec;
    public float ms;

    public TMP_Text mission;
    public TMP_Text missiondifficulty;
    // Start is called before the first frame update
    void Start()
    {
        LevelMissions = new int[10] { 10, 15, 30, 45, 60, 15, 30, 30, 60, 45 };
        LevelDifficulties = new int[10] { 1, 1, 1, 1, 1, 2, 2, 3, 3, 4 };

        if (PlayerPrefs.GetInt("UnlockedLevels") == 0)
        {
            PlayerPrefs.SetInt("UnlockedLevels", 1);
        }

        for (int i = 0; i < LevelLocks.Length; i++)
        {
            Debug.Log(i + " " + LevelLocks[i] + " " + PlayerPrefs.GetInt("UnlockedLevels"));
            if (i <= PlayerPrefs.GetInt("UnlockedLevels")-1)
            {
                LevelLocks[i].SetActive(false);
            }
        }
    }

    public void PlayLevel()
    {
        PlayerPrefs.SetInt("Mission", LevelMissions[PlayerPrefs.GetInt("Level") - 1]);
        PlayerPrefs.SetInt("Difficulty", LevelDifficulties[PlayerPrefs.GetInt("Level") - 1]);
        SceneManager.LoadScene("Campaign");
    }

    public void SetLevel(int n)
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") < n)
        {
            return;
        }
        PlayerPrefs.SetInt("Level", n);
        min = Mathf.Floor(LevelMissions[PlayerPrefs.GetInt("Level") - 1] / 60);
        sec = Mathf.Floor(LevelMissions[PlayerPrefs.GetInt("Level") - 1] - (min * 60));
        //Debug.Log(elapsedTime + " " + sec + " " + min);
        ms = (LevelMissions[PlayerPrefs.GetInt("Level") - 1] - sec - (min * 60)) * 100;
        mission.text = System.String.Format("{0:D2}:{1:D2}:{2:D2}", Mathf.RoundToInt(min), Mathf.RoundToInt(sec), Mathf.RoundToInt(ms));
        if (LevelDifficulties[PlayerPrefs.GetInt("Level") - 1] == 1)
        {
            missiondifficulty.color = new Color32(37, 147, 60, 255);
            missiondifficulty.text = "Difficulty: Easy";
        }
        else if (LevelDifficulties[PlayerPrefs.GetInt("Level") - 1] == 2)
        {
            missiondifficulty.color = new Color32(204, 237, 14, 255);
            missiondifficulty.text = "Difficulty: Medium";
        }
        else if (LevelDifficulties[PlayerPrefs.GetInt("Level") - 1] == 3)
        {
            missiondifficulty.color = new Color32(171, 7, 7, 255);
            missiondifficulty.text = "Difficulty: Hard";
        }
        else if (LevelDifficulties[PlayerPrefs.GetInt("Level") - 1] == 4)
        {
            missiondifficulty.color = new Color32(0, 0, 0, 255);
            missiondifficulty.text = "Difficulty: Extreme";
        }
        Levels.SetActive(false);
        Mission.SetActive(true);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene("Home");
    }
    
    public void InfoScreen()
    {
        SceneManager.LoadScene("InfoPage");
    }

    public void LevelScreen()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
