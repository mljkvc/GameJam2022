using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void idiStart()
    {
        //uzima trenutni br scene i ide +1 na sledecu scenu
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        //gasi app
        Application.Quit();
    }


}
