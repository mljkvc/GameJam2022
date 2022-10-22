using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Update is called once per frame
    public Transform firePoint;
    public GameObject bulletPrefab;


    //marko pravio
    public Canvas canvas;
    private esc_meni escMain;


    private void Start()
    {

        //marko pravio
        escMain = canvas.GetComponent<esc_meni>();


    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(escMain.pauzirano == false)
                Shoot();
        }
    }
    void Shoot()
    {
        // Shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
