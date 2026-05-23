using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCtrlCampaign : MonoBehaviour
{
    public Vector2 target;

    float scale;

    float minsize;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 1 || PlayerPrefs.GetInt("Difficulty") == 2)
        {
            speed = 3f;
            minsize = 0.3f;
        }
        else if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            speed = 3f;
            minsize = 0.75f;
        }
        else if (PlayerPrefs.GetInt("Difficulty") == 4)
        {
            speed = 5f;
            minsize = 0.75f;
        }
        scale = Random.Range(minsize, 1.5f);
        this.transform.localScale = new Vector3(scale, scale, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("Difficulty") + "Difficulty");
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z + 10f), 100f * Time.deltaTime);
        Debug.Log("location" + Mathf.Abs(this.transform.position.x - target.x));
        if (Mathf.Abs(this.transform.position.x - target.x) < 0.1f && Mathf.Abs(this.transform.position.y - target.y) < 0.1f)
        {
            Destroy(this.gameObject);
        }
    }
}

