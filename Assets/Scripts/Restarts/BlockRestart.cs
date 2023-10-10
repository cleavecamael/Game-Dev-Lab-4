using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRestart : BaseRestart
{
    GameObject powerBlocks;
    GameObject coinBlocks;
    GameObject regularBlocks;
    // Start is called before the first frame update
    void Start()
    {
        powerBlocks = GameObject.Find("Power Blocks");
        coinBlocks = GameObject.Find("Coin Blocks");
        eventManager.onRestart += Restart;
    }

    new public void Restart()
    {
        powerBlocks = GameObject.Find("Power Blocks");
        coinBlocks = GameObject.Find("Coin Blocks");
      
        foreach (Transform powerBlock in powerBlocks.transform)
        {
            Debug.Log(powerBlock.name);
            powerBlock.gameObject.GetComponent<QuestionBoxPowerupController>().Reset();
        }
        foreach (Transform coinBlock in coinBlocks.transform)
        {

            coinBlock.gameObject.GetComponent<BrickPowerUpController>().Reset();
        }
        
    }
}
