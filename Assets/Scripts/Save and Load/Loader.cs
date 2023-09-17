using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Loader : MonoBehaviour
{ 

    public void LoadSession(string json)
    {
        LoadedObject room = JsonUtility.FromJson<LoadedObject>(json);

        SceneManager.LoadScene(room.roomName);
    }
}
