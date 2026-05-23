using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCtrl : MonoBehaviour
{
    public Vector2 target;

    float scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(0.3f, 1.5f);
        this.transform.localScale = new Vector3(scale, scale, 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target, 3f * Time.deltaTime);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z + 10f), 100f * Time.deltaTime);
        if (Mathf.Abs(this.transform.position.x - target.x) < 0.1f && Mathf.Abs(this.transform.position.y - target.y) < 0.1f)
        {
            Destroy(this.gameObject);
        }
    }
}

