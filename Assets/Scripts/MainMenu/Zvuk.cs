using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zvuk : MonoBehaviour
{
    [SerializeField] Slider slajder;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("zvuk"))
        {
            PlayerPrefs.SetFloat("zvuk", 1);
            Load();
        }
        else
            Load();
        
    }
    public void promeni_zvuk()
    {
        AudioListener.volume = slajder.value;
        Save();
    }

    private void Load()
    {
        slajder.value = PlayerPrefs.GetFloat("zvuk");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("zvuk", slajder.value);
    }

}
