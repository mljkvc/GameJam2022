using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Dugmici : MonoBehaviour
{

    public void start(){
        //uzima trenutni br scene i ide +1 na sledecu scenu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exit(){
        //gasi app
        Application.Quit();
    }

}
