using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenuController : MonoBehaviour
{

    //attack action currently directly enables the target panel

    [SerializeField]
    public GameObject combatPanel;
    [SerializeField]
    public GameObject targetPanel;
    private Vector3 targetPanelLastPosition = new Vector3(0, -318, 0);

    [SerializeField]
    public UIUnitInfo[] allyUnits;
    //private void Start()
    //{
    //    targetPanelLastPosition = targetPanel.GetComponent<RectTransform>().localPosition;
    //    Debug.Log(targetPanelLastPosition.x);
    //    Debug.Log(targetPanelLastPosition.y);

    //}

    public void UpdateTargetPanel()
    {

    }
    /// <summary>
    /// moves target panel off screen which allows target updating more easily
    /// </summary>
    /// <param name="value"></param>
    public void ToggleTargetPanel(bool value)  
    {
        
        if (value)
        {
            targetPanel.GetComponent<RectTransform>().localPosition = Vector3.zero;

        }
        else
        {
            targetPanel.GetComponent<RectTransform>().localPosition = targetPanelLastPosition;

        }
    }
    public void DisableCombatPanel()
    {
        combatPanel.SetActive(false);
    }

    public void EnableCombatPanel()
    {
        combatPanel.SetActive(true);

    }

    
    public void UpdateUnitUIHealth(int health)
    {
        allyUnits[0].UpdateHealth(health);
    }

    public void SetUnitMaxHealth(int healthMax)
    {
        allyUnits[0].UpdateMaxHealth(healthMax);

    }
}
