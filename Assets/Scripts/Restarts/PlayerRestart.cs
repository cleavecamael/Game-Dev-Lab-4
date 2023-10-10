using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : BaseRestart
{
    public GameObject boots;
    public GameObject mario;
    private Rigidbody2D marioBody;
    public Camera gameCamera;
    private SpriteRenderer marioSprite;
    public Animator marioAnimator;
    StageSettings settings;
    new void Start()
    {
        marioBody = mario.GetComponent<Rigidbody2D>();
        marioSprite = mario.GetComponent<SpriteRenderer>();
        eventManager.onRestart += Restart;

    }
    
    new public void Restart()
    {
  
        settings = GameObject.Find("Settings").GetComponent<Settings>().settings;
        marioAnimator.SetTrigger("gameRestart");
        marioAnimator.SetBool("deadLock", false);
        mario.GetComponent<PowerUpManager>().turnSmall();
        mario.GetComponent<PowerUpManager>().updateRender();
        boots.GetComponent<BootsMovement>().updatePosition();
        gameCamera.transform.position = settings.StartCameraPosition;
        marioBody.velocity = Vector3.zero;
        mario.transform.localPosition = settings.StartMarioPosition;
        boots.transform.localPosition = settings.StartBootsPosition;
        // reset sprite direction
        marioSprite.flipX = false;
        Variables.alive = true;
        Time.timeScale = 1.0f;

    }
    
}
