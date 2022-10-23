using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static MusicControl instance = null;
    public static MusicControl Instance
    {
        get {return instance; }
    }

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
