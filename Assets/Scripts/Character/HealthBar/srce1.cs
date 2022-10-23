using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class srce1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Player>().health > 25f)
            GetComponent<Image>().enabled = true;
        else
            GetComponent<Image>().enabled = false;
    }
}
