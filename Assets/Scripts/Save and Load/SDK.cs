using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveSession(string data);

    [DllImport("__Internal")]
    private static extern void Log();

    [DllImport("__Internal")]
    private static extern void LoadLastSession();

    public void SaveSession()
    {
        LoadedObject loadedObject = new LoadedObject();

        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();


        loadedObject.playerHealth = player.GetHealth();
        loadedObject.playerMoney = player.GetMoney();
        loadedObject.roomName = SceneManager.GetActiveScene().name;

        string result = JsonUtility.ToJson(loadedObject);

        SaveSession(result);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            LoadLastSession();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Saver saver = GameObject.Find("UIManager").GetComponent<Saver>();

            saver.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Log();
        }
    }
}
