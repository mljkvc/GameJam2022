using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveTextUP : MonoBehaviour
{
    // Start is called before the first frame update

    //public Transform pos;
    public float speed;
    public TextMeshPro dis;
    public float fadeOutStep;

    void Start()
    {
        dis.text = "25";
        dis.color = Color.red;

        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform != null && transform.childCount>0)
        {
            transform.GetChild(0).gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, -2 * Time.deltaTime);
            if (transform.GetChild(0).gameObject.transform.position.z < -15 || transform.GetChild(0).gameObject.transform.position.y > 2f) Destroy(this.gameObject);
        }
    }

    public IEnumerator FadeOut()
    {

        while(dis.alpha > 0)
        {
            dis.alpha -= fadeOutStep;
            yield return null;
        }
    }
}
