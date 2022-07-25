using UnityEngine;
using System;

public class InputInfo : MonoBehaviour
{
    public static event Action onIndicateClick;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            IndicateClick();
    }

    public float MouseX()
    {
        return Input.GetAxis("Mouse X");
    }

    public float MouseY()
    {
        return Input.GetAxis("Mouse Y");
    }

    public float ForwardInput()
    {
        return Input.GetAxis("Vertical");
    }

    public float RightInput()
    {
        return Input.GetAxis("Horizontal");
    }

    private void IndicateClick()
    {
        if (onIndicateClick != null)
            onIndicateClick();
    }
}
