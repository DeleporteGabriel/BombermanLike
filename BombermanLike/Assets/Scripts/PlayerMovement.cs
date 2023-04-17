using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private KeyCode _left, _right, _up, _down, _spawnBomb;
    [SerializeField]
    private int _speed, _facing;
    public int currentBomb, maxBomb;
    [SerializeField]
    private BombExplosion _prefabBomb;
    [SerializeField]
    private PlayerLife _myLife;
    [SerializeField]
    private TextMeshProUGUI _bombsUI;

    void Update()
    {
        _bombsUI.text = "Munitions : " + (maxBomb - currentBomb).ToString();
        //déplacement du personnages
        if (Input.GetKey(_left))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
            _facing = 0;
        }
        if (Input.GetKey(_right))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
            _facing = 1;
        }
        if (Input.GetKey(_up))
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
            _facing = 2;
        }
        if (Input.GetKey(_down))
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
            _facing = 3;
        }

        //Utilisation des bombes
        if (Input.GetKeyDown(_spawnBomb) && currentBomb < maxBomb)
        {
            var decalageBomb = Vector3.zero;

            switch (_facing)
            {
                case 0: decalageBomb = new Vector3(-1, 0, 0);
                    break;
                case 1: decalageBomb = new Vector3(1, 0, 0);
                    break;
                case 2: decalageBomb = new Vector3(0, 1, 0);
                    break;
                case 3: decalageBomb = new Vector3(0, -1, 0);
                    break;
            }

            var Bomb = Instantiate(_prefabBomb, transform.position + decalageBomb, Quaternion.identity);
            Bomb.monPlayer = gameObject.GetComponent<PlayerMovement>();
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
}
