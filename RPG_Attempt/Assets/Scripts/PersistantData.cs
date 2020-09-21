using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistantData
{
    public static UnitScriptableObject player;
    public static int health;
    public static int playerTeamCount;

    public static bool specialEncounter;

    public static int[] talentPoints = new int[3];
}
