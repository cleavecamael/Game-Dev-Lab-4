using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxPowerupController : MonoBehaviour, IPowerupController
{
    public Animator powerupAnimator;
    public BasePowerup powerup; // reference to this question box's powerup
    private Rigidbody2D questionBlockBody;
    public GameObject itemRecipe;
    private GameObject itemObject;
    private Rigidbody2D itemBody;
    public Vector2 itemImpulse;
    private AudioSource questionAudio;
    private bool itemHit = false;
    private bool resetBlock;
    private SpriteRenderer questionSprite;
    public Sprite usedBlock;
    public GameObject blockObject;
    private Animator questionAnimator;
    public GameManager gameManager;
   

    void Start()
    {
        resetBlock = false;
        questionBlockBody = blockObject.GetComponent<Rigidbody2D>();
        questionAudio = GetComponent<AudioSource>();
        questionSprite = blockObject.GetComponent<SpriteRenderer>();
        questionAnimator = blockObject.GetComponent<Animator>();
        Debug.Log(questionAnimator.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(questionBlockBody.velocity.magnitude > 0.2 && !itemHit)
        {
            Debug.Log("hitting block");
            blockHit();
        }
    }
    void FixedUpdate()
    {
        //remove items once finished moving
        if (itemHit && (Vector3.Distance(blockObject.transform.localPosition, Vector3.zero) < 0.005))
        {
            Disable();
        }

    }
    void blockHit()
    {
        Debug.Log("Block");
        itemHit = true;
        spawnPowerup();
        //questionAudio.PlayOneShot(questionAudio.clip)
        Debug.Log("queestion " + questionAnimator.name);
        questionAnimator.enabled = false;
        questionSprite.sprite = usedBlock;
  
        //gameManager.IncreaseScore(1);//
    }

    public void spawnPowerup()
    {
        Debug.Log("spawn");
        itemObject = Instantiate(itemRecipe, this.transform.position + Vector3.up,Quaternion.identity);
       
        itemObject.transform.parent = this.gameObject.transform;
        Debug.Log("Change position");
       
    }   
    public void Reset()
    {

        itemHit = false;
        resetBlock = false;
        questionBlockBody.bodyType = RigidbodyType2D.Dynamic;

        questionAnimator.enabled = true;
        questionAnimator.SetTrigger("reset");
        //itemObject.SetActive(true);
        //itemObject.GetComponent<Animator>().SetTrigger("reset");
        blockObject.transform.localPosition = Vector3.zero;
       
    }

    // used by animator
    public void Disable()
    {
  
        blockObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //transform.localPosition = new Vector3(0, 0, 0);
        resetBlock = true;
    }



}