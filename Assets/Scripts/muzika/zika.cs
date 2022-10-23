using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zika : MonoBehaviour
{

    public static zika obj;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(obj == null)
        {
            obj = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
