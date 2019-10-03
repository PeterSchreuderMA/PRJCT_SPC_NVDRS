using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _canInput = true;

    public void ChangeAllowInput(bool tempI)
    {
        _canInput = tempI;
    }

    public float GetHorizontal()
    {
        if (_canInput)
        {
            return Input.GetAxisRaw("Horizontal");
        }
        return 0f;
    }

    public bool GetFire()
    {
        if (_canInput)
        {
            return Input.GetButtonDown("Fire");
        }
        return false;
    }
}
