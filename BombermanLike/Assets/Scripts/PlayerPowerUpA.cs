using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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
    [SerializeField]
    private Image _myPowerUpImage;

    private void Start()
    {
        var newColor = _myPowerUpImage.color;
        newColor.a = 0.5f;
        _myPowerUpImage.color = newColor;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_usePowerUp) && _havePowerUp == true)
        {
            _myMovements.bombPower += 1;
            _havePowerUp = false;
            var newColor = _myPowerUpImage.color;
            newColor.a = 0.5f;
            _myPowerUpImage.color = newColor;
        }
    }

    public void TriggerPowerUp(InputAction.CallbackContext context)
    {
        if (_havePowerUp == true)
        {
            _myMovements.bombPower += 1;
            _havePowerUp = false;
            var newColor = _myPowerUpImage.color;
            newColor.a = 0.5f;
            _myPowerUpImage.color = newColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUpGiver>() != null)
        {
            if (collision.GetComponent<PowerUpGiver>().powerUpGiven == 0)
            {
                _havePowerUp = true;
                var newColor = _myPowerUpImage.color;
                newColor.a = 1f;
                _myPowerUpImage.color = newColor;
            }
            Destroy(collision.gameObject);
        }
    }
}
