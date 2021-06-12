using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddParametersToAgentInspector : MonoBehaviour
{
    public string agentName;
    public string agentHp;
    public AgentsController ac;

    public TextMeshProUGUI agentNameText;
    public TextMeshProUGUI agentHpText;
    public Image agentIcon;

    public Color imageColor;


    // Start is called before the first frame update
    void Start()
    {
        agentNameText.text = "Agent Name";
        agentHpText.text = "HP: ??/??";
    }

    // Update is called once per frame
    void Update()
    {
        ClickOnObject();
        UpdateParameters();
    }

    private void ClickOnObject() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.transform.tag == "Agent") 
                    ac = hit.transform.gameObject.GetComponent<AgentsController>();
                else 
                {
                    ac = null;
                    agentNameText.text = "Agent Name";
                    agentHpText.text = "HP: ??/??";
                    imageColor = Color.white;
                    agentIcon.color = imageColor;
                }
                    
            }   
        }
    }

    private void UpdateParameters()
    {
        agentNameText.text = ac.GetName();
        agentHpText.text = "HP: " + ac.GetActualAgentLife() +"/3";
        imageColor = ac.GetRend().material.color;
        agentIcon.color = imageColor;
    }
}
