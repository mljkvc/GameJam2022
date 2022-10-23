using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public GameObject menu;

    private float health = Player.health;
    private void Start()
    {
        menu.SetActive(false);
    }


    private void Update()
    {
        Debug.Log(health);
        if(health <= 0)
        {
            health = 0;
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void idiStart()
    {
        //uzima trenutni br scene i ide +1 na sledecu scenu
        Time.timeScale = 1f;
        health = 100f;
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        //gasi app
        Application.Quit();
    }


}
