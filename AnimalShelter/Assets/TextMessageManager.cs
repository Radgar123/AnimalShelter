using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMessageManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    private string message;
    private bool isUse = true;

    private void MarcoPolo()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 != 0)
                message += "Marco ";
            else if (i % 5 == 0 && i % 3 != 0)
                message += "Polo ";
            else if (i % 3 == 0 && i % 5 == 0)
                message += "MarcoPolo ";
            else
                message += i + " ";
        }
    }

    private void DisplayOnClick() 
    {
        MarcoPolo();
        displayText.text = message;

        if (isUse)
        {
            MarcoPolo();
            displayText.text = message;
            isUse = false;
        }
        else 
        {
            message = null;
            displayText.text = null;
            isUse = true;
        }
            
    }
}
