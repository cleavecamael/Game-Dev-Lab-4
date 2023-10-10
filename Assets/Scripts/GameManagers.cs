using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static class to get important objects directly
public static class GameManagers
{
   public static GameObject getGameManager()
    {
     return GameObject.Find("GameManager");
    }
    public static GameObject getMario()
    {
        return GameObject.Find("Mario");
    }
    public static GameObject getBoots()
    {
        return GameObject.Find("Boots");
    }
}
