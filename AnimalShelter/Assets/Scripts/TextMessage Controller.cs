using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMessageController : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI displayText;
    private string message;


    private void Update()
    {
        displayText.text = message;
    }

    private void MarcoPolo() 
    {
        for(int i = 1; i <= 100; i++) 
        {
            if (i % 3 == 0)
                message += " Marco";
            else if (i % 5 == 0)
                message += " Polo";
            else if (i % 3 == 0 && i % 5 == 0)
                message += " " + i;
        }
    }

}
