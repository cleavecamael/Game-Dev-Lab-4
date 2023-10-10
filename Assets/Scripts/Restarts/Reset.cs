using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//custom script to apply custom restart behaviours
public class Reset : MonoBehaviour
{
    
    public BaseRestart restart;

    public void Restart()
    {
        restart.Restart();
    }
}
