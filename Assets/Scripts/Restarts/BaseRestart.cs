using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRestart : EventManagerBehavior, IRestart
{
    // Start is called before the first frame update
    public void Start()
    {
        eventManager.onRestart += Restart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        
    }
}
