using UnityEngine;

[CreateAssetMenu(fileName = "EventManager", menuName = "ScriptableObjects/EventManager", order = 3)]
public class EventManager : ScriptableObject
{
    public delegate void GameEvent();
    public GameEvent onRestart;
    public GameEvent onPause;
    public GameEvent onResume;
    public GameEvent onNextScene;
}

