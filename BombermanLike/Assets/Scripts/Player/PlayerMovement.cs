using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left, right, up, down, spawnBomb;
    [SerializeField]
    private int _facing = 0;
    private Vector2 _movement;

    public int speed;
    public bool canSpawnBomb = true;

    public int currentBomb, maxBomb, bombPower;
    [SerializeField]
    private BombExplosion _prefabBomb;
    [SerializeField]
    private PlayerLife _myLife;
    [SerializeField]
    private TextMeshProUGUI _bombsUI;

    [SerializeField]
    private WallManager _myWalls;

    void Update()
    {
        _bombsUI.text = "Munitions : " + (maxBomb - currentBomb).ToString();

        //déplacement du personnages
        if (Input.GetKey(left))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            _facing = 0;
        }
        if (Input.GetKey(right))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            _facing = 1;
        }
        if (Input.GetKey(up))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            _facing = 2;
        }
        if (Input.GetKey(down))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            _facing = 3;
        }

        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + _movement * speed * Time.deltaTime);
        //facing avec manette
        if (_movement.x < -0.5f) { _facing = 0; }
        if (_movement.x > 0.5f) { _facing = 1; }
        if (_movement.y > 0.5f) { _facing = 2; }
        if (_movement.y < -0.5f) { _facing = 3; }

        //spawn bomb
        if (Input.GetKeyDown(spawnBomb) && currentBomb < maxBomb && canSpawnBomb == true)
        {
            var decalageBomb = Vector3.zero;

            switch (_facing)
            {
                case 0:
                    decalageBomb = new Vector3(-1, 0, 0);
                    break;
                case 1:
                    decalageBomb = new Vector3(1, 0, 0);
                    break;
                case 2:
                    decalageBomb = new Vector3(0, 1, 0);
                    break;
                case 3:
                    decalageBomb = new Vector3(0, -1, 0);
                    break;
            }

            var Bomb = Instantiate(_prefabBomb, transform.position + decalageBomb, Quaternion.identity);
            Bomb.monPlayer = gameObject.GetComponent<PlayerMovement>();
            Bomb.explosionLenght = bombPower;
            Bomb.myWalls = _myWalls;
            currentBomb += 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //se faire toucher par l'explosion
        if (collision.gameObject.GetComponent<Explosion>() != null)
        {
            _myLife.playerHit();
        }
    }

    //Controles Manette

    public void SpawningBomb(InputAction.CallbackContext context)
    {
        //spawn bomb
        if (currentBomb < maxBomb && canSpawnBomb == true && context.action.triggered)
        {
            var decalageBomb = Vector3.zero;

            switch (_facing)
            {
                case 0:
                    decalageBomb = new Vector3(-1, 0, 0);
                    break;
                case 1:
                    decalageBomb = new Vector3(1, 0, 0);
                    break;
                case 2:
                    decalageBomb = new Vector3(0, 1, 0);
                    break;
                case 3:
                    decalageBomb = new Vector3(0, -1, 0);
                    break;
            }

            var Bomb = Instantiate(_prefabBomb, transform.position + decalageBomb, Quaternion.identity);
            Bomb.monPlayer = gameObject.GetComponent<PlayerMovement>();
            Bomb.explosionLenght = bombPower;
            Bomb.myWalls = _myWalls;
            currentBomb += 1;
        }
    }

    //Mouvements
    public void GoDirection(InputAction.CallbackContext context) 
    {
        _movement = context.ReadValue<Vector2>();
    }
}
