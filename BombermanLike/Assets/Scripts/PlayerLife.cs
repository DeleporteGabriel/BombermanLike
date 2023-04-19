using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int currentLife;
    [SerializeField]
    private int _maxLife;
    [SerializeField]
    private TextMeshProUGUI myText;

    private Animator _myAnimator;

    public bool invincibility;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = _maxLife;
        _myAnimator = GetComponent<Animator>();
    }

    public void playerHit()
    {
        if (invincibility == false)
        { 
            currentLife =  Mathf.Clamp(currentLife - 1, 0, 99);
            myText.text = "Vie : " + currentLife.ToString();
            Invoke("stopBeingHit", 2);
            invincibility = true;

            if (currentLife <= 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 1);
            }

            _myAnimator.ResetTrigger("HurtTrigger");
            _myAnimator.SetTrigger("HurtTrigger");
        }
    }

    public void stopBeingHit()
    {
        invincibility = false;
        if (currentLife <= 0)
        {
            SceneManager.LoadScene("SceneVictoire");
        }
    }

}
