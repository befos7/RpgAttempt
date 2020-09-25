using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject menuPanel;
    //Text menuPanelText;
    [SerializeField]
    public GameObject talentTreePanel;
    [SerializeField]
    public GameObject[] talentTreePanelArray;
    private int tempRow, tempCol;
    [SerializeField]
    public GameObject[] talentTreeButtons;
    private GameObject[,] talentTreeButtonArray = new GameObject[3,3];


    Color greenColor, whiteColor;
    // Start is called before the first frame update
    void Start()
    {
        //menuPanelText = menuPanel.GetComponentInChildren<Text>();
        talentTreeButtonArray[0, 0] = talentTreeButtons[0];
        talentTreeButtonArray[0, 1] = talentTreeButtons[1];
        talentTreeButtonArray[0, 2] = talentTreeButtons[2];
        talentTreeButtonArray[1, 0] = talentTreeButtons[3];
        talentTreeButtonArray[1, 1] = talentTreeButtons[4];
        talentTreeButtonArray[1, 2] = talentTreeButtons[5];
        talentTreeButtonArray[2, 0] = talentTreeButtons[6];
        talentTreeButtonArray[2, 1] = talentTreeButtons[7];
        talentTreeButtonArray[2, 2] = talentTreeButtons[8];

        greenColor = Color.green;
        whiteColor = Color.white;

        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (PersistantData.talentPoints[r,c])
                {
                    talentTreeButtonArray[r, c].GetComponent<Image>().color = greenColor;
                    //talentTreeButtonArray[r, c].GetComponent<Button>().interactable = false;
                    if (r == 0)
                    {
                        OpenUpTalentRow(1);
                    }
                    if (r == 1)
                    {
                        OpenUpTalentRow(2);

                    }

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMenu()
    {
        
        menuPanel.SetActive(!menuPanel.activeSelf);
        //if (menuPanel.activeSelf)
        //{
        //    menuPanelText.text = "Close";
        //}
        //else
        //{
        //    menuPanelText.text = "Menu";

        //}
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

    public void SetTalentPointRow(int row)//make sure this is called before the column
    {
        tempRow = row;

    }
    public void SetTalentPointcolumn(int col)
    {
        tempCol = col;
        SetTalentTreeValue(tempRow, tempCol);
    }

    private void SetTalentTreeValue(int row, int col)
    {
        PersistantData.talentPoints[row, col] = true; ;
        talentTreeButtonArray[row, col].GetComponent<Image>().color = greenColor;
       
    }
    
    public void OpenUpTalentRow(int rowToOpen)
    {
        for (int i = 0; i < 3; i++)
        {
        talentTreeButtonArray[rowToOpen, i].GetComponent<Button>().interactable = true;

        }

    }

    public void ResetTalents()
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (r>0)
                {
                    talentTreeButtonArray[r, c].GetComponent<Button>().interactable = false;
                }
                talentTreeButtonArray[r,c].GetComponent<Image>().color = whiteColor;
                PersistantData.talentPoints[r, c] = false;

            }
        }
    }
}
