using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGiver : MonoBehaviour
{
    public int powerUpGiven;
    [SerializeField]
    private List<Color> myColors;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = myColors[powerUpGiven];
    }
}
