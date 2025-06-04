using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public bool clicked()
    {
        return Input.anyKeyDown;
    }

    public bool mouseLeftClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool mouseRightClicked()
    {
        return Input.GetMouseButtonDown(1);
    }

    public bool wKeyClicked()
    {
        return Input.GetKey(KeyCode.W);
    }
    public bool aKeyClicked()
    {
        return Input.GetKey(KeyCode.A);
    }
    public bool sKeyClicked()
    {
        return Input.GetKey(KeyCode.S);
    }
    public bool dKeyClicked()
    {
        return Input.GetKey(KeyCode.D);
    }

    public bool qKeyClicked()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }
}
