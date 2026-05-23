using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : MonoBehaviour
{
    public GameObject Meteor;
    public GameObject NewMeteor;
    public GameObject GameOver;
    public GameObject Restart;
    public GameObject BacktoHome;

    public int random;
    public int random2;

    public bool playeralive = true;

    public AudioSource deathSource;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 0.1f, 0.1f);
    }

    void SpawnMeteor()
    {
        //0: spawns along -x
        //1: spawns along x
        //2: spawns along -y
        //3: spawns along y
        random = Random.Range(0, 4);
        random2 = Random.Range(0, 4);
        if (random == random2)
        {
            if (random2 == 3)
            {
                random2 = Random.Range(0, 3);
            }
            else if (random2 == 2)
            {
                random2 += 1;
            }
            else if (random2 == 1)
            {
                random2 += 1;
            }
            else if (random2 == 0)
            {
                random2 = Random.Range(1, 4);
            }
        }
        if (random == 0)
        {
            NewMeteor = Instantiate(Meteor, new Vector2(Camera.main.aspect * Camera.main.orthographicSize * -1 - 1, Random.Range(Camera.main.orthographicSize * -1 - 1, Camera.main.orthographicSize + 1)), Meteor.transform.rotation);
        }
        else if (random == 1)
        {
            NewMeteor = Instantiate(Meteor, new Vector2(Camera.main.aspect * Camera.main.orthographicSize + 1, Random.Range(Camera.main.orthographicSize * -1 - 1, Camera.main.orthographicSize + 1)), Meteor.transform.rotation);
        }
        else if (random == 2)
        {
            NewMeteor = Instantiate(Meteor, new Vector2(Random.Range(Camera.main.aspect * Camera.main.orthographicSize * -1 - 1, Camera.main.aspect * Camera.main.orthographicSize + 1), Camera.main.orthographicSize * -1 - 1), Meteor.transform.rotation);
        }
        else if (random == 3)
        {
            NewMeteor = Instantiate(Meteor, new Vector2(Random.Range(Camera.main.aspect * Camera.main.orthographicSize * -1 - 1, Camera.main.aspect * Camera.main.orthographicSize + 1), Camera.main.orthographicSize + 1), Meteor.transform.rotation);
        }
        if (random2 == 0)
        {
            NewMeteor.GetComponent<MeteorCtrl>().target = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * -1, Random.Range(Camera.main.orthographicSize * -1, Camera.main.orthographicSize));
        }
        if (random2 == 1)
        {
            NewMeteor.GetComponent<MeteorCtrl>().target = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Random.Range(Camera.main.orthographicSize * -1, Camera.main.orthographicSize));
        }
        if (random2 == 2)
        {
            NewMeteor.GetComponent<MeteorCtrl>().target = new Vector2(Random.Range(Camera.main.aspect * Camera.main.orthographicSize * -1, Camera.main.aspect * Camera.main.orthographicSize), Camera.main.orthographicSize * -1);
        }
        if (random2 == 3)
        {
            NewMeteor.GetComponent<MeteorCtrl>().target = new Vector2(Random.Range(Camera.main.aspect * Camera.main.orthographicSize * -1, Camera.main.aspect * Camera.main.orthographicSize), Camera.main.orthographicSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playeralive == true)
        {
            InputMovement();
        }
    }

    public void InputMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > 0 - (Camera.main.aspect * Camera.main.orthographicSize))
            {
                transform.position = new Vector3(transform.position.x - 3f * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < (Camera.main.aspect * Camera.main.orthographicSize))
            {
                transform.position = new Vector3(transform.position.x + 3f * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > 0 - (Camera.main.orthographicSize))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 3f * Time.deltaTime, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < (Camera.main.orthographicSize))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 3f * Time.deltaTime, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 45), 1500f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 135), 1500f * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 90), 1500f * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -135), 1500f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -45), 1500f * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -90), 1500f * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 135), 1500f * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), 1500f * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -45), 1500f * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 1500f * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            this.GetComponent<Animator>().SetTrigger("done");
            deathSource.Play();
            playeralive = false;
            Invoke("Destroyself", 1);
        }
    }

    public void Destroyself()
    {
        Destroy(this.gameObject);
        GameOver.SetActive(true);
        Restart.SetActive(true);
        BacktoHome.SetActive(true);
    }
}