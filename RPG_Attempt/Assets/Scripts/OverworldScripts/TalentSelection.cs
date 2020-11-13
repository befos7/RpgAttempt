using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TalentSelection : MonoBehaviour
{
    [SerializeField]
    private int talentTreeValue = 0;
   

    [SerializeField]
    public GameObject[] talentTreeButtons;
   
    Color greenColor, whiteColor;

    private void Start()
    {
        

        greenColor = Color.green;
        whiteColor = Color.white;

       


        for (int i = 0; i < 9; i++)
        {
            if (PersistantData.TalentPoints[talentTreeValue,i])
            {
                talentTreeButtons[i].GetComponent<Image>().color = greenColor;
                if (i<4)
                {
                    OpenUpTalentRow(2);

                }
                if (i<7)
                {
                    OpenUpTalentRow(3);

                }
            }
        }
    }
   
    public void SetTalentPoint(int Value)
    {
        PersistantData.TalentPoints[talentTreeValue, Value] = true;
        talentTreeButtons[Value].GetComponent<Image>().color = greenColor;
    }

   

    public void OpenUpTalentRow(int rowToOpen)
    {
       
        if (rowToOpen == 1)
        {
            talentTreeButtons[3].GetComponent<Button>().interactable = true;
            talentTreeButtons[4].GetComponent<Button>().interactable = true;
            talentTreeButtons[5].GetComponent<Button>().interactable = true;


        }
        else if (rowToOpen == 2)
        {
            talentTreeButtons[6].GetComponent<Button>().interactable = true;
            talentTreeButtons[7].GetComponent<Button>().interactable = true;
            talentTreeButtons[8].GetComponent<Button>().interactable = true;
        }

    }

    public void ResetTalents()
    {
      

        for (int i = 0; i < 9; i++)
        {
            if (i>2)
            {
            talentTreeButtons[i].GetComponent<Button>().interactable = false;

            }
            talentTreeButtons[i].GetComponent<Image>().color = whiteColor;
            PersistantData.TalentPoints[talentTreeValue, i] = false;
        }
    }
   
}
