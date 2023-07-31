using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform Indicator;
    public GameObject bulletPrefab;
    public LineRenderer laserRenderer;
    public int laserRange = 20;
    UnityEngine.Rendering.Universal.Light2D laserLight;

    
    void Start()
    {
        //UnityEngine.Rendering.Universal.Light2D laserLight = GameObject.Find("LaserLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        laserLight = GameObject.Find("LaserLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        laserRenderer.enabled = false;
        //yield return new WaitForSeconds(0.2f);
        laserLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UnityEngine.Debug.Log("Fire1");
            Shoot1();
        }

        //Down detects each press
        //If you want to detect while held, remove 'down' so it's just 'GetButton'

        if (Input.GetButtonDown("Fire2"))
        {
            UnityEngine.Debug.Log("Fire2");
            StartCoroutine(Shoot2());
        }
    }

    void Shoot1()
    {
        Instantiate(bulletPrefab, Indicator.position, firePoint.rotation);//shooting logic
    }

    IEnumerator Shoot2()
    {

        laserLight = GameObject.Find("LaserLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        Vector3 startPos = new Vector3(0, 0, 0); //Puts the laser's first point directly on the indicator
        Vector3 endPos;
        Vector3 standbyPos = new Vector3(0, 0, -10);

        laserRenderer.SetPosition(0, startPos);

        //laserRenderer.SetPosition(0, startPos);
        //laserRenderer.SetPosition(1, endPos);

        //Seems to be hitting the character
        //RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        RaycastHit2D hitInfo = Physics2D.Raycast(Indicator.position, firePoint.right, laserRange);

        if (hitInfo)
        {
            UnityEngine.Debug.Log("Fire2 hitInfo");

            endPos = new Vector3(hitInfo.distance, 0, 0);

            //Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            /*
             if(enemy != null)
            {
            enemy.TakeDamage(40);
            }
             */



            //laserRenderer.SetPosition(0, firePoint.position);
            //laserRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            //laserRenderer.SetPosition(1, hitInfo.point); //Hitting a wall? The character themselves perhaps?
        }
        else
        {

            endPos = new Vector3(10, 0, 0);
            UnityEngine.Debug.Log("Fire2 else");
            //laserRenderer.SetPosition(0, firePoint.position);
            //laserRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        laserRenderer.SetPosition(1, endPos);

        laserLight.enabled = true;
        laserRenderer.enabled = true;
        //yield return 0.02f;
        UnityEngine.Debug.Log("Laser appears");
        yield return new WaitForSeconds(0.2f);
        UnityEngine.Debug.Log("Laser disappears");
        laserRenderer.enabled = false;
        //yield return new WaitForSeconds(0.2f);
        laserLight.enabled = false;

        //laserRenderer.SetPosition(0, standbyPos);
        //laserRenderer.SetPosition(1, standbyPos);
    }


}
