using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuReturn : MonoBehaviour
{
    private TextMeshProUGUI _myText;
    private bool _goUp = false;
    private float _myAlpha = 1;
    private void Start()
    {
        _myText = GetComponent<TextMeshProUGUI>();   
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("SceneMenu");
        }

        //Oscillement du texte
        if (_goUp == false)
        {
            _myAlpha -= 0.01f;
        }
        else
        {
            _myAlpha += 0.01f;
        }

        if (_myAlpha >= 1)
        {
            _goUp = false;
        }
        if (_myAlpha <= 0.5f)
        {
            _goUp = true;
        }
        var newColor = _myText.color;
        newColor.a = _myAlpha;
        _myText.color = newColor;
    }
}
