using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class esc_meni : MonoBehaviour
{
    public bool pauzirano = false;
    public GameObject meni;

    private void Start()
    {
        meni.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauzirano)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        meni.SetActive(false);
        Time.timeScale = 1f;
        pauzirano = false;
    }

    void Pause()
    {
        meni.SetActive(true);
        Time.timeScale = 0f;
        pauzirano = true;
    }

    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        Application.Quit();
    }

}
