using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerUpB : MonoBehaviour
{

    public PlayerMovement myMovement;
    [SerializeField]
    private bool _havePowerUp;
    [SerializeField]
    private KeyCode _usePowerUp;

    [SerializeField]
    private SplashZone _mySplashZone;

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
            _havePowerUp = false;
            var mySplash = Instantiate(_mySplashZone, new Vector3(0.5f, 0.5f, -5), Quaternion.identity);
            mySplash.myPlayer = gameObject.GetComponent<PlayerPowerUpB>();

            //mettre controles sur le splash
            mySplash.left = myMovement.left;
            mySplash.right = myMovement.right;
            mySplash.up = myMovement.up;
            mySplash.down = myMovement.down;
            mySplash.use = myMovement.spawnBomb;

            myMovement.speed = 0;
            myMovement.canSpawnBomb = false;

            var newColor = _myPowerUpImage.color;
            newColor.a = 0.5f;
            _myPowerUpImage.color = newColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUpGiver>() != null)
        {
            if (collision.GetComponent<PowerUpGiver>().powerUpGiven == 1)
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
