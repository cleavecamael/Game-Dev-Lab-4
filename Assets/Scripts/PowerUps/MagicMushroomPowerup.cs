
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    // setup this object's type
    // instantiate variables
    public AudioClip spawnclip;
    AudioSource spawnSource;
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.MagicMushroom;
        spawnSource = this.GetComponent<AudioSource>();
  
        spawned = false;
        SpawnPowerup();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(spawned.ToString());
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: do something when colliding with Player

            // then destroy powerup (optional)
            Debug.Log("sucess");
            GameManagers.getMario().GetComponent<PowerUpManager>().powerUpMushroom();
            DestroyPowerup();

        }
        else if (col.gameObject.layer == 10) // else if hitting Pipe, flip travel direction
        {
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);

            }
        }
    }

    // interface implementation
    public override void SpawnPowerup()
    {
       
        Debug.Log(spawnSource.name);
        spawnSource.PlayOneShot(spawnclip);
        spawned = true;
        Debug.Log("hello");
        rigidBody.AddForce( Vector2.up * 100);

    }
    public void moveMushroom(Vector2 velocity)
    {
        rigidBody.MovePosition(rigidBody.position + velocity  * Time.fixedDeltaTime);
    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object

    }
     void Update()
    {
        if (spawned)
        {
            Vector3 v = rigidBody.velocity;
            v.x = 2.0f;
            rigidBody.velocity = v;
        }
        
    }
}