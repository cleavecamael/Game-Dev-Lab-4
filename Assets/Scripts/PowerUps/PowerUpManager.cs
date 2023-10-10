using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public RuntimeAnimatorController bigController;
    public RuntimeAnimatorController smallController;
    public AudioClip turnBig;
    private Animator currAnimator;
    SpriteRenderer renderer;
    BoxCollider2D collider;
    public IPowerup currPowerup;
    public MarioState state;
    
    // Start is called before the first frame update
    void Start()
    {
        //IT DEPENDS, by default i put small.
        state = MarioState.small; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void powerUpMushroom()
    {

        currAnimator = this.gameObject.GetComponent<Animator>();
        state = MarioState.big;
       
        //update bounds now
        startMushroomAnim();
        


    }

    public void turnSmall()
    {

        currAnimator = this.gameObject.GetComponent<Animator>();
        currAnimator.runtimeAnimatorController = smallController;
        state = MarioState.small;

     



    }
    //powerUpAnimations (Maybe abstract it to another file in the future)
    void startMushroomAnim()
    {
        currAnimator.runtimeAnimatorController = bigController;
        currAnimator.SetTrigger("powerUp");
        Debug.Log("anim starting");
        Time.timeScale = 0.01f;
    }
    void endMushroomAnim()
    {
        Debug.Log("resetting scale");
        Time.timeScale = 1.0f;
       
    }
   public void updateRender()
    {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        collider = this.gameObject.GetComponent<BoxCollider2D>();
        Vector3 v = renderer.bounds.size;
        collider.size = v;
        GameManagers.getBoots().GetComponent<BootsMovement>().updatePosition();
        
    }
    void playBigclip()
    {
        GetComponent<AudioSource>().PlayOneShot(turnBig);
    }
}
