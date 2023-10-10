using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D marioBody;
    public float upSpeed = 10;
    private bool onGroundState = true;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    public TextMeshProUGUI scoreText;
    public GameObject enemies;


    public Animator marioAnimator;
    public AudioSource marioAudio;
    public AudioSource deathAudio;
    public AudioClip marioDeath;
    public GameManager gameManager;
    public float deathImpulse;
    private bool moving = false;
    private bool jumpedState = false;
    public GameObject GameOverPanel;
    public TextMeshProUGUI gameOverText;
    [System.NonSerialized]
    public Vector2 startPosition;
    [System.NonSerialized]
    public bool alive = Variables.alive;
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7) | (1 <<8);

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        Time.timeScale = 1.0f;
        Variables.alive = true;
        SceneManager.activeSceneChanged += SetStartingPosition;

    }

    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
    }
    public float maxSpeed = 20;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
          
            marioAnimator.SetBool("onGround", onGroundState);
        }
        if ((col.gameObject.tag) == "Enemy"){
            if (col.gameObject.GetComponent<EnemyMovement>().alive){
                if (!marioAnimator.GetBool("deadLock"))
                {
                    onGroundState = true;
                    // update animator state
                    marioAnimator.SetBool("onGround", onGroundState);
                    marioAnimator.SetTrigger("died");
                    marioAnimator.SetBool("deadLock", true);
                }
            }
            
        }
    }
    // FixedUpdate may be called once per frame. See documentation for details.
    void FixedUpdate()
    {
        

        if (Variables.alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }



    }




    void Move(int value)
    {
        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.velocity.magnitude < maxSpeed)
            marioBody.AddForce(movement * speed);
    }
    public void MoveCheck(int value)
    {
   
        if (value == 0)
        {
            
            moving = false;
        }
        else
        {
           
            FlipMarioSprite(value);
            moving = true;
            Move(value);
        }
    }
    void FlipMarioSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;
            if (marioBody.velocity.x > 0.05f)
                marioAnimator.SetTrigger("onSkid");

        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
            if (marioBody.velocity.x < -0.05f)
                marioAnimator.SetTrigger("onSkid");
        }
    }

    public void Jump()
    {
       
        if (Variables.alive && onGroundState)
        {
            // jump
          
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);

        }
    }

    public bool isBig()
    {
        return !(this.GetComponent<PowerUpManager>().state.Equals(MarioState.small));
    }
    public void JumpHold()
    {
        if (Variables.alive && jumpedState)
        {
            // jump higher
            marioBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;

        }
    }


    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }
    void PlayJumpSound()
    {
        // play jump sound
        marioAudio.PlayOneShot(marioAudio.clip);
    }

    void PlayDeathSound()
    {
        deathAudio.PlayOneShot(deathAudio.clip);
    }
    private void gameOver()
    {
       marioAnimator.SetBool("onGround",true);
        gameManager.GameOverScene();
    }
    public void SetStartingPosition(Scene current, Scene next)
    {
        if (next.name == "Stage 1-2")
        {
            // change the position accordingly in your World-1-2 case
            Debug.Log("yes");
        }
    }
    public IPowerup getPowerup()
    {
        return this.GetComponent<PowerUpManager>().currPowerup;
    }
}
