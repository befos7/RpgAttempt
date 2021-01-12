using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAbility : MonoBehaviour
{
    [SerializeField]
    private int talentTreeArrayNumber;
    [SerializeField]
    private int talentTreeValue;
    void Start()
    {
        if (!PersistantData.TalentPoints[talentTreeArrayNumber, talentTreeValue])
        {
            gameObject.SetActive(false);
        }
    }

    
}
