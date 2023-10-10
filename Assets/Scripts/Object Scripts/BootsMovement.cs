using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class BootsMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bootAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePosition()
    {
        float currX = this.transform.position.x;
        float playerBoundsY = GameManagers.getMario().GetComponent<SpriteRenderer>().bounds.min.y;
        this.transform.localPosition = new Vector2(currX, playerBoundsY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            bootAudio.PlayOneShot(bootAudio.clip,0.9f);
            //inefficient method
            collision.gameObject.GetComponent<EnemyMovement>().alive = false;
            collision.gameObject.GetComponent<Animator>().SetTrigger("onKill");
           
            
        }
    }
}
