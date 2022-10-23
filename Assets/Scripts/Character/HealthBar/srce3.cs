using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class srce3 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Player.health > 75f)
            GetComponent<Image>().enabled = true;
        else
            GetComponent<Image>().enabled = false;
    }
}
