using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public UsernameValidator usernameValidator;
    public void Pressed()
    {
        usernameValidator.Validate();
    }
}
