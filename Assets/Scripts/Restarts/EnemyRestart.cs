using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRestart : BaseRestart
{
    GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.Find("Enemies");
        eventManager.onRestart += Restart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    new public void Restart()
    {
        enemies = GameObject.Find("Enemies");
        foreach (Transform enemy in enemies.transform)
        {
            enemy.gameObject.GetComponent<EnemyMovement>().alive = true;
            enemy.gameObject.SetActive(true);
            enemy.gameObject.GetComponent<Animator>().SetTrigger("onRestart");
            enemy.gameObject.GetComponent<EnemyMovement>().Reset();
            enemy.gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
