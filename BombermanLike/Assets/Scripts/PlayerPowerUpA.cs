using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpA : MonoBehaviour
{
    [SerializeField]
    private bool _havePowerUp;
    [SerializeField]
    private KeyCode _usePowerUp;
    [SerializeField]
    private WallManager _myWalls;
    [SerializeField]
    private PlayerMovement _myMovements;
    [SerializeField]
    private Explosion _prefabExplosion;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_usePowerUp) && _havePowerUp == true)
        {
            _myMovements.bombPower += 1;
            _havePowerUp = false;
        }
    }
}
