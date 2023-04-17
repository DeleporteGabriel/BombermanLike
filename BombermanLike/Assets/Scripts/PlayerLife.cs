using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public int currentLife;
    [SerializeField]
    private int _maxLife;
    [SerializeField]
    private TextMeshProUGUI myText;

    public bool invincibility;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = _maxLife;
    }

    public void playerHit()
    {
        if (invincibility == false)
        { 
            currentLife -= 1;
            myText.text = "Vie : " + currentLife.ToString();
            Invoke("stopBeingHit", 2);
            invincibility = true;
        }
    }

    public void stopBeingHit()
    {
        invincibility = false;
    }
}
