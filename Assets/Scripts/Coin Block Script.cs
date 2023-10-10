using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlockScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D coinBlockBody;
    public GameObject itemObject;
    private Rigidbody2D itemBody;
    public Vector2 coinImpulse;
    private AudioSource coinAudio;
    private bool itemHit = false;
    private bool resetBlock;
    private GameObject blockObject;
    public GameManager gameManager;

    void Start()
    {
        resetBlock = false;
        blockObject = GetComponent<Transform>().Find("Wood Block").gameObject;
        coinBlockBody = blockObject.GetComponent<Rigidbody2D>();
        itemBody = itemObject.GetComponent<Rigidbody2D>();
        coinAudio = GetComponent<AudioSource>();
        

    }

  
    // Update is called once per frame
    void Update()
    {

        if (coinBlockBody.velocity.magnitude > 0.2 && !itemHit)
        {
            blockHit();
        }

    }

    void FixedUpdate()
    {
        //remove items once finished moving
        
        if (resetBlock && (Vector3.Distance(itemObject.transform.localPosition, Vector3.zero) < 0.001))
        {
            itemObject.SetActive(false);
        }
    }
    void blockHit()
    {
        itemBody.AddForce(coinImpulse);
        coinAudio.PlayOneShot(coinAudio.clip);
        itemHit = true;
        gameManager.IncreaseScore(1);
    }

    public void Reset()
    {
        itemHit = false;
        resetBlock = false;
        coinBlockBody.bodyType = RigidbodyType2D.Dynamic;
        itemObject.SetActive(true);
        blockObject.transform.localPosition = Vector3.zero;
        itemObject.transform.localPosition = Vector3.zero;

    }
}
