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

    }

    void Update()
    {
        if (FindObjectOfType<Player>().getWeaponType() == 1 && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
