using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIUnitInfo : MonoBehaviour
{

    [SerializeField]
    Transform unitHealth, unitMaxHealth, unitName;

    

    public void UpdateHealth(int newHealth)
    {
        unitHealth.GetComponent<TextMeshProUGUI>().SetText(newHealth.ToString());
    }
    public void UpdateMaxHealth(int maxHealth)
    {
        unitMaxHealth.GetComponent<TextMeshProUGUI>().SetText(maxHealth.ToString());
    }

}
