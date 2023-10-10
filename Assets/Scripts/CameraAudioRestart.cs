using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraAudioReset : MonoBehaviour
{
    AudioSource cameraAudio;
    // Start is called before the first frame update
    void Start()
    {
        cameraAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   
}
