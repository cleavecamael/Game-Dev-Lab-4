using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // lives
    int maxLives;

    // Mario's movement
    int speed;
    int maxSpeed;
    int upSpeed;
    int deathImpulse;
    Vector3 marioStartingPosition;

    // Goomba's movement
    float goombaPatrolTime;
    float goombaMaxOffset;
}

