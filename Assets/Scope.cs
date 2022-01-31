using System.Collections;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;
    public float scopedFOV = 15f;
    public float scopedSensitivity = 200f;
    private float normalFOV;
    

    public bool isScoped { get; private set; }

    private void Awake()
    {
        isScoped = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = true;
            animator.SetBool("isScoped", isScoped);
            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                StartCoroutine(OnUnscoped());
            }

        } else if (Input.GetButtonUp("Fire2"))
        {
            isScoped = false;
            animator.SetBool("isScoped", isScoped);
            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                StartCoroutine(OnUnscoped());
            }
        }
    }


    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }
    IEnumerator OnUnscoped()
    {
        yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }





}
