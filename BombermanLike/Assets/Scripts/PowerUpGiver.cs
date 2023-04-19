using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGiver : MonoBehaviour
{
    public int powerUpGiven;
    public List<Color> myColors;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = myColors[powerUpGiven];
    }
}
