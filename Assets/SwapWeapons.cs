using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapons : MonoBehaviour
{
    public GameObject primary;
    public GameObject secondary;
    public float swapSpeed = 1f;

    private void Update()
    {
        if (Input.GetButtonDown("SwapToSecondary"))
        {
            Debug.Log("Swap to secondary");
            StartCoroutine(SwapToSecondary());   

        }
        else if (Input.GetButtonDown("SwapToPrimary"))
        {
            Debug.Log("Swap to primary");
            StartCoroutine(SwapToPrimary());
        }
    }

    IEnumerator SwapToPrimary()
    {
        secondary.SetActive(false);
        yield return new WaitForSeconds(swapSpeed);
        primary.SetActive(true);
    }
    IEnumerator SwapToSecondary()
    {
        primary.SetActive(false);
        yield return new WaitForSeconds(swapSpeed);
        secondary.SetActive(true);
    }
}
