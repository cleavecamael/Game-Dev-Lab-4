public class GameEvents : Singleton<GameEvents>
{
    //Top Level Game related Events
    public delegate void onRestart();
    public delegate void onMapLoad();
    public delegate void onStart();
    public delegate void onDeath();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
