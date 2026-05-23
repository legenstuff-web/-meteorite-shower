using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeCtrl : MonoBehaviour
{
    public AudioSource buttonClickedSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FreePlay()
    {
        StartCoroutine(SwitchtoFreePlay());
    }

    public IEnumerator SwitchtoFreePlay()
    {
        buttonClickedSource.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Game");
    }

    public void Campaign()
    {
        StartCoroutine(SwitchtoCampaign());
    }

    public IEnumerator SwitchtoCampaign()
    {
        buttonClickedSource.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("LevelSelector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
