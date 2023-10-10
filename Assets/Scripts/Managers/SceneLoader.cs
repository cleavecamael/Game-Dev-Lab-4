using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : EventManagerBehavior
{
    // Start is called before the first frame update
    Settings settings;
    GameObject mario;
    GameObject boots;
    Camera camera;
    void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        mario = GameObject.Find("Mario");
        boots = GameObject.Find("Boots");

        eventManager.onNextScene += updateScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateScene()
    {
        Debug.Log("updating scene");
        mario.transform.localPosition = settings.settings.StartMarioPosition;
        boots.transform.localPosition = settings.settings.StartBootsPosition;
        camera.transform.localPosition = settings.settings.StartCameraPosition;
    }

}
