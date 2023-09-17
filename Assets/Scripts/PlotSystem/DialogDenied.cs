using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDenied : MonoBehaviour
{
    [SerializeField] string message;

    public void ShowMessage()
    {
        Debug.Log(message);
    }
}
