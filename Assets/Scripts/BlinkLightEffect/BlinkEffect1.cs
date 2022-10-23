using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
 
public class BlinkEffect1 : MonoBehaviour
{
    bool isBright = true;

    void Update(){
        if(isBright){
            Invoke("Darken", 0.3f);
        }
        else{
            Invoke("Brighten", 0.7f);
        }

        if(GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity == 0){
            isBright = false;
        }
        if(GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity == 1.5f){
            isBright = true;
        }

        //GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= 0.01 * Time.deltaTime;
    }

    void Brighten(){
        GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1.5f;

    }
    void Darken(){
        GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0;
    }
}
