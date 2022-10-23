using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public GameObject menu;

    
    private void Start()
    {
        menu.SetActive(false);
    }


    private void Update()
    {
            if (Player.health <= 0)
            {
                Player.health = 0;
                menu.SetActive(true);
                Time.timeScale = 0f;


            }
  
    }

    public void idiStart()
    {
        //uzima trenutni br scene i ide +1 na sledecu scenu
        Time.timeScale = 1f;
        Player.health = 100f;
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        //gasi app
        Application.Quit();
    }


}
