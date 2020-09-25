using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{



    public static DamagePopup Create(Vector3 position, int damageAmount, Color color)
    {
        Transform damagePopupTranform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        damagePopupTranform.GetComponent<TextMeshPro>().SetText(damageAmount.ToString());
        damagePopupTranform.GetComponent<TextMeshPro>().faceColor = color;
        DamagePopup damagePopUp = damagePopupTranform.GetComponent<DamagePopup>();
        //damagePopUp.Setup(damageAmount);
        
        return damagePopUp;
    }


   
    public void Setup(int damageAmount)
    {
        
    }
    // Update is called once per frame
    
}
