using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public string playerTagString = "Player";
    private string bodyText;
    private TextBox textBox;
    public string messageText;
    
    private void Start()
    {
        GameObject a = GameObject.Find("TextBoxGrp");
        textBox = a.GetComponent<TextBox>();
        /*   if (transform.GetChild(0).GetComponent<TextMeshPro>())
           {
               bodyText = transform.GetChild(0).GetComponent<TextMeshPro>().text;
           }
           if (transform.GetChild(0).GetComponent<HiddenText>())
           {
               bodyText = transform.GetChild(0).GetComponent<HiddenText>().text;
          }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTagString)
        {
            textBox.enabled = true;
            textBox.ShowText(messageText, name, "UIPop_Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTagString)
        {
            textBox.ShowText(messageText, name, "UIPop_Close");
        }
    }

}
