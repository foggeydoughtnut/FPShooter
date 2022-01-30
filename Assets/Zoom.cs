using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float defaultZoom = 15f;
    public float amountZoomed = 60f;

    public Camera fpsCam;
    public GameObject gunParts;
    public GameObject scope;
    public GameObject regularCrossHair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (fpsCam.focalLength == defaultZoom)
            {
                fpsCam.focalLength = amountZoomed;
                gunParts.SetActive(false);
                scope.SetActive(true);
                regularCrossHair.SetActive(false);
            }
            // Use this if you want a more haloesc feel
            else
            {
                fpsCam.focalLength = defaultZoom;
                gunParts.SetActive(true);
                scope.SetActive(false);
                regularCrossHair.SetActive(true);
            }
        }
        // Use this if you want hold to zoom
/*        if (Input.GetButtonUp("Fire2"))
        {
            if (fpsCam.focalLength == amountZoomed)
            {
                gunParts.SetActive(true);
                crosshair.SetActive(false);
                fpsCam.focalLength = defaultZoom;
                
            }
        }*/
    }
}
