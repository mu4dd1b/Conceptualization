using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public Animation box;
    public Text body;
    public Text title;


    public void ShowText(string bodyText, string titleText, string animClip)
    {
        body.text = bodyText;
        title.text = titleText;

        box.Play(animClip);
    }
}
