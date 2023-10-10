using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPowerUpController : MonoBehaviour, IPowerupController
{
    private Rigidbody2D coinBlockBody;
    private GameObject itemObject;
    public BasePowerup powerup;
    public GameObject itemRecipe;
    private Rigidbody2D itemBody;
    public Vector2 coinImpulse;
    private AudioSource coinAudio;
    private bool itemHit = false;
    private bool resetBlock;
    private GameObject blockObject;
    private GameManager gameManager;
    public AudioClip breakblock;


    // Start is called before the first frame update
    void Start()
    {
        resetBlock = false;
        blockObject = GetComponent<Transform>().Find("Wood Block").gameObject;
        coinBlockBody = blockObject.GetComponent<Rigidbody2D>();
  
        coinAudio = GetComponent<AudioSource>();
        gameManager = GameManagers.getGameManager().GetComponent<GameManager>();
       
    }

    public void Disable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coinBlockBody.velocity.magnitude > 0.2)
        {
            if (GameManagers.getMario().GetComponent<PlayerMovement>().isBig())
            {
                Debug.Log("yes is big");
      
                this.gameObject.SetActive(false);
               
                
            }
        }
        
        if (coinBlockBody.velocity.magnitude > 0.2 && !itemHit)
        {
            blockHit();
        }

    }
    void FixedUpdate()
    {
        

    }
    public void spawnPowerup()
    {

        itemObject = Instantiate(itemRecipe, this.transform.position + Vector3.up, Quaternion.identity);

        itemObject.transform.parent = this.gameObject.transform;

    }
    void blockHit()
    {
        
        powerup.SpawnPowerup();
        
        itemHit = true;
        gameManager.IncreaseScore(1);
    }
    public void Reset()
    {
        itemHit = false;
        resetBlock = false;
        this.gameObject.SetActive(true);
        coinBlockBody.bodyType = RigidbodyType2D.Dynamic;
        blockObject.transform.localPosition = Vector3.zero;
        

    }
}
