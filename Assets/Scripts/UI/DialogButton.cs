using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button button;
    [SerializeField] DialogEvent dialogPoint;
    private DialogPanel panel;

    private UIManager uIManager;

    private void Start()
    {
        panel = transform.parent.parent.GetComponent<DialogPanel>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void OnClicked()
    {
        /*ConditionalEnding ending = dialogPoint.Answer();
        if (ending != null)
        {
            gameObject.SetActive(false);
            Debug.Log(ending.answer + "\n" + ending.player_biography);
            panel.Hide();
        }*/
        /*else
            Debug.Log("�� �� ��������� ������� ��� ������ �� ��� ������");*/

        if(dialogPoint != null)
        {
            uIManager.GetMessageBox().AddToQueue(dialogPoint.GetAnswer());
            uIManager.GetMessageBox().Show();
            panel.Hide();
        }
        else
        {
            uIManager.GetMessageBox().AddToQueue("����������� ������");
            uIManager.GetMessageBox().Show();
            panel.Hide();
        }
    }

    public void SetDialog(DialogEvent dialogPoint)
    {
        this.dialogPoint = dialogPoint;
        if (dialogPoint != null)
        {
            text.text = "*\t" + dialogPoint.GetDialogText();
        }
        else
        {
            text.text = "*\t" + "�� ������������ ��������. �������� ���, ���� ����������� ������ ������� RNG �� ������� ��� ������ ���������";
        }
    }
}
