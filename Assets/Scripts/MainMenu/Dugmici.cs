using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Dugmici : MonoBehaviour
{
    public GameObject opcije;
    public GameObject meni;

    public static bool dali = true;

    private void Start()
    {
        opcije.SetActive(false);
        meni.SetActive(true);
    }

    public void start(){
        //uzima trenutni br scene i ide +1 na sledecu scenu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
    public void menjaj()
    {
        if(dali == true)
        {
            opcije.SetActive(true);
            meni.SetActive(false);
            dali = false;
        }
        else
        {
            opcije.SetActive(false);
            meni.SetActive(true);
            dali = true;
        }


    }

    */
    public void exit(){
        //gasi app
        Application.Quit();
    }

}
