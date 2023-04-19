using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> _myTexts;
    private int _menuState;

    private void Start()
    {
        for (int i = 0; i < _myTexts.Count; i++)
        {
            if (i == _menuState)
            {
                _myTexts[i].color = Color.yellow;
            }
            else
            {
                _myTexts[i].color = Color.white;
            }
        }
    }

    private void Update()
    {
        //choix dans le mnu
        if (Input.GetKeyDown(KeyCode.S))
        {
            _menuState++;
            if (_menuState >= _myTexts.Count)
            {
                _menuState = 0;
            }
            for (int i = 0; i < _myTexts.Count; i++)
            {
                if (i == _menuState)
                {
                    _myTexts[i].color = Color.yellow;
                }
                else
                {
                    _myTexts[i].color = Color.white;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _menuState--;
            if (_menuState < 0)
            {
                _menuState = _myTexts.Count - 1;
            }
            for (int i = 0; i < _myTexts.Count; i++)
            {
                if (i == _menuState)
                {
                    _myTexts[i].color = Color.yellow;
                }
                else
                {
                    _myTexts[i].color = Color.white;
                }
            }
        }

        //confirmer choix
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_menuState)
            {
                case 0: SceneManager.LoadScene("SceneSolo");
                    break;
                case 1: SceneManager.LoadScene("SceneMulti");
                    break;
                case 2: SceneManager.LoadScene("SceneRebind");
                    break;
            }
        }
    }

    public void GoDown(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            _menuState++;
            if (_menuState >= _myTexts.Count)
            {
                _menuState = 0;
            }
            for (int i = 0; i < _myTexts.Count; i++)
            {
                if (i == _menuState)
                {
                    _myTexts[i].color = Color.yellow;
                }
                else
                {
                    _myTexts[i].color = Color.white;
                }
            }
        }
    }
    public void GoUp(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            _menuState--;
            if (_menuState < 0)
            {
                _menuState = _myTexts.Count - 1;
            }
            for (int i = 0; i < _myTexts.Count; i++)
            {
                if (i == _menuState)
                {
                    _myTexts[i].color = Color.yellow;
                }
                else
                {
                    _myTexts[i].color = Color.white;
                }
            }
        }
    }

    public void ValidChoice(InputAction.CallbackContext context)
    {
        switch (_menuState)
        {
            case 0:
                SceneManager.LoadScene("SceneSolo");
                break;
            case 1:
                SceneManager.LoadScene("SceneMulti");
                break;
            case 2:
                SceneManager.LoadScene("SceneRebind");
                break;
        }
    }
}
