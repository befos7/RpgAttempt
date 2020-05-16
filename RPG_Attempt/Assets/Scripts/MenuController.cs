using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    private GameObject talentTreePanel;
    [SerializeField]
    GameObject[] talentTreePanelArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    public void GoBackFromTalentMenu()
    {
        CloseTalentPanels();
        talentTreePanel.SetActive(false);
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
