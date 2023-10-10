using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : BasePowerup
{
    public AudioClip spawnClip;
    public AudioSource spawnSource;

    protected override void Start()
    {
        this.gameObject.SetActive(false);
        spawnSource = this.GetComponent<AudioSource>();
        SpawnPowerup();
    }
    public override void SpawnPowerup()
    {
        
        spawned = true;
        
        Debug.Log("animating");
        this.gameObject.SetActive(true);
        spawnSource.PlayOneShot(spawnClip);
       
        this.gameObject.GetComponent<Animator>().SetTrigger("jumped");
   
        GameManagers.getGameManager().GetComponent<GameManager>().IncreaseScore(1);
        
    }
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object

    }
}
