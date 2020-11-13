using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistantData
{

    // player data
    public static UnitScriptableObject player;
    public static int health;
    public static int playerTeamCount;

    // scene transition
    public static int sceneValue;
    public static Vector3 playerLocation;
    public static int locationToSpawn = 0;
    public static bool locationSaved = false;



    //battle data
    public static bool specialEncounter;
    public static UnitScriptableObject[] zoneMobs;
    public static int maxMobCount;
    
    //Menu data
    public static bool[,] TalentPoints = new bool[4, 9];


}
