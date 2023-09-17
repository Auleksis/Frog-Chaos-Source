using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Sprite[] healthSprites;

    [SerializeField] DialogPanel dialogPanel;

    [SerializeField] MessageBox messageBox;

    [SerializeField] ChaosDisplayer chaosDisplayer;

    [SerializeField] HealthBar healthBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DialogPanel GetDialogPanel()
    {
        return dialogPanel;
    }

    public MessageBox GetMessageBox()
    {
        return messageBox;
    }

    public ChaosDisplayer GetChaosDisplayer()
    {
        return chaosDisplayer;
    }

    public HealthBar GetHealthBar()
    {
        return healthBar;
    }
}
