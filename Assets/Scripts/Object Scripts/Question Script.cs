using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D questionBlockBody;
    public GameObject itemObject;
    private Rigidbody2D itemBody;
    public Vector2 itemImpulse;
    private AudioSource questionAudio;
    private bool itemHit = false;
    private bool resetBlock;
    private SpriteRenderer questionSprite;
    public Sprite usedBlock;
    private GameObject blockObject;
    private Animator questionAnimator;
    public GameManager gameManager;
    public BasePowerup powerup;
    [SerializeField, SerializeReference]
    private IPowerup currentState;
    void Start()
    {
        resetBlock = false;
        blockObject = GetComponent<Transform>().Find("Power Block").gameObject;
        questionBlockBody = blockObject.GetComponent<Rigidbody2D>();
        itemBody = itemObject.GetComponent<Rigidbody2D>();
        questionAudio = GetComponent<AudioSource>();
        questionSprite = blockObject.GetComponent<SpriteRenderer>();
        questionAnimator = blockObject.GetComponent<Animator>();
        
    }

    public void Reset()
    {
        
        itemHit = false;
        resetBlock = false;
        questionBlockBody.bodyType = RigidbodyType2D.Dynamic;
        
        questionAnimator.enabled = true;
        questionAnimator.SetTrigger("reset");
        itemObject.SetActive(true);
        itemObject.GetComponent<Animator>().SetTrigger("reset");
        blockObject.transform.localPosition = Vector3.zero;
        itemObject.transform.localPosition = Vector3.zero;
    }



    // Update is called once per frame
    void Update()
    {
        
        if (questionBlockBody.velocity.magnitude > 0.2 && !itemHit)
        {
            blockHit();
        }
        
    }

    void FixedUpdate()
    {
        //remove items once finished moving
        if (itemHit && (Vector3.Distance(blockObject.transform.localPosition, Vector3.zero) < 0.001))
        {
            questionBlockBody.bodyType = RigidbodyType2D.Static;
            resetBlock = true;
        }
      
    }
    void blockHit()
    {
        Debug.Log("Block");
        powerup.SpawnPowerup();
        //questionAudio.PlayOneShot(questionAudio.clip);
        questionAnimator.enabled = false;
        questionSprite.sprite = usedBlock;
        itemHit = true;
        //gameManager.IncreaseScore(1);//
    }
}
