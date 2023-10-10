using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    public IntVariable highScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        highScore.ResetHighestValue();
    }
}
