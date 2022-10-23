using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zvuk : MonoBehaviour
{
    [SerializeField] Slider slajder;

    public GameObject unmute1;
    public GameObject unmute2;
    public GameObject unmute3;
    public GameObject mute;

    public AudioSource muzika;
    public float jacina;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FirstPLay") == 0)
        {
            jacina = 0.75f;
            slajder.value = jacina;
            PlayerPrefs.SetFloat("BackgroundPref", 0.75f);
            PlayerPrefs.SetInt("FirstPlay", -1);
        }
        else
        {
            jacina = PlayerPrefs.GetFloat("BackgroundPref");
            slajder.value = jacina;
        }
            
    }

    private void Update()
    {
        if(slajder.value == 0)
        {
            mute.SetActive(true);
            unmute1.SetActive(false);
            unmute2.SetActive(false);
            unmute3.SetActive(false);
        }
        else if (slajder.value > 0 && slajder.value < 0.33)
        {
            mute.SetActive(false);
            unmute1.SetActive(true);
            unmute2.SetActive(false);
            unmute3.SetActive(false);
        }
        else if (slajder.value >= 0.33 && slajder.value < 0.66)
        {
            mute.SetActive(false);
            unmute1.SetActive(false);
            unmute2.SetActive(true);
            unmute3.SetActive(false);
        }
        else if (slajder.value >= 0.66)
        {    
            mute.SetActive(false);
            unmute1.SetActive(false);
            unmute2.SetActive(false);
            unmute3.SetActive(true);
        }


    }
    public void promeni_zvuk()
    {
        muzika.volume = slajder.value;

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
