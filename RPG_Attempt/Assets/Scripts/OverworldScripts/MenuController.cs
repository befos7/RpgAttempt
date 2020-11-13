using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject menuPanel;
    
    [SerializeField]
    public GameObject talentTreePanel;
    [SerializeField]
    public GameObject[] talentTreePanelArray;
    


   
   

    public void ToggleMenu()
    {
        
        menuPanel.SetActive(!menuPanel.activeSelf);
       
    }

    public void GoBackFromTalentMenu()
    {
        CloseTalentPanels();
        talentTreePanel.SetActive(false);
    }
    public void GoToTalentMenuScreen()
    {
        talentTreePanel.SetActive(true);
        CloseTalentPanels();

    }
    public void OpenTalentPanel(int value)
    {
        CloseTalentPanels();
        talentTreePanelArray[value].SetActive(true);
    }
    void CloseTalentPanels()
    {
        for (int i = 0; i < talentTreePanelArray.Length; i++)
        {
            talentTreePanelArray[i].SetActive(false);
        }
    }
   

}
