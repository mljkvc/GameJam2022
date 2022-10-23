using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pr2 : MonoBehaviour
{ 
    void OnEnable() {
        SceneManager.LoadScene("Epilog", LoadSceneMode.Single);
    }
}
