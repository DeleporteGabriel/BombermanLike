using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpB : MonoBehaviour
{

    public PlayerMovement myMovement;
    [SerializeField]
    private bool _havePowerUp;
    [SerializeField]
    private KeyCode _usePowerUp;

    [SerializeField]
    private SplashZone _mySplashZone;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_usePowerUp) && _havePowerUp == true)
        {
            _havePowerUp = false;
            var mySplash = Instantiate(_mySplashZone, new Vector3(0.5f, 0.5f, -5), Quaternion.identity);
            mySplash.myPlayer = gameObject.GetComponent<PlayerPowerUpB>();
            myMovement.speed = 0;
            myMovement.canSpawnBomb = false;
        }
    }
}
