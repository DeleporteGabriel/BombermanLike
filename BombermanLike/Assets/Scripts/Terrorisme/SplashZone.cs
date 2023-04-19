using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplashZone : MonoBehaviour
{
    public KeyCode left, right, down, up, use;
    [SerializeField]
    private GameObject _prefabExplosion;

    public PlayerPowerUpB myPlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(left))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(right))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(up))
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(down))
        {
            transform.position += new Vector3(0, -1, 0);
        }

        //activer le power up
        if (Input.GetKeyDown(use))
        {
            Instantiate(_prefabExplosion, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, -4), Quaternion.identity);
            Instantiate(_prefabExplosion, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, -4), Quaternion.identity);
            Instantiate(_prefabExplosion, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, -4), Quaternion.identity);
            Instantiate(_prefabExplosion, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, -4), Quaternion.identity);

            myPlayer.myMovement.speed = 3;
            myPlayer.myMovement.canSpawnBomb = true;

            Destroy(gameObject);
        }
    }

    //danser bouger
    public void IsUp(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }
    public void IsDown(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }
    public void IsLeft(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }
    public void IsRight(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    //activate explosion
    public void UseExplosions(InputAction.CallbackContext context)
    {        
        Instantiate(_prefabExplosion, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, -4), Quaternion.identity);
        Instantiate(_prefabExplosion, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, -4), Quaternion.identity);
        Instantiate(_prefabExplosion, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, -4), Quaternion.identity);
        Instantiate(_prefabExplosion, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, -4), Quaternion.identity);

        myPlayer.myMovement.speed = 3;
        myPlayer.myMovement.canSpawnBomb = true;

        Destroy(gameObject);
    }
}
