using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStat
{
    [Range(1, 5)]
    public int maxHEalth;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int maxLives = 3;
    [HideInInspector]
    public int currentLives = 3;

    public float playerSpeed;
    public float fireSpeed;

}
