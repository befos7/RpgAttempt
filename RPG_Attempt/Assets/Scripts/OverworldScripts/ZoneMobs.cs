using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMobs : MonoBehaviour
{
    [SerializeField]
    public UnitScriptableObject[] zoneMobs;
    [SerializeField]
    public int zoneMobCount;

    private void Start()
    {
        PersistantData.zoneMobs = zoneMobs;
        PersistantData.maxMobCount = zoneMobCount;
    }
}
