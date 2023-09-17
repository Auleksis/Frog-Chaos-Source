using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Saver : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveSession(string data);

    public void Save()
    {
        LoadedObject loadedObject = new LoadedObject();

        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();


        loadedObject.playerHealth = player.GetHealth();
        loadedObject.playerMoney = player.GetMoney();
        loadedObject.roomName = SceneManager.GetActiveScene().name;

        string result = JsonUtility.ToJson(loadedObject);

        SaveSession(result);
    }
}
