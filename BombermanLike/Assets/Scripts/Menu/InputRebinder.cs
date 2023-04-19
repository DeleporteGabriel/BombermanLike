using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class InputRebinder : MonoBehaviour
{
    [SerializeField]
    private List<InputActionReference> _myInputs;
    [SerializeField]
    private List<string> _myButtonsNames;
    private int _currentInput;
    [SerializeField]
    private TextMeshProUGUI _myText;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    private InputActionReference ActionToRemap;

    private void Update()
    {
        if (_currentInput >= _myButtonsNames.Count)
        {
            SceneManager.LoadScene("SceneMenu");
            return;
        }

        _myText.text = _myButtonsNames[_currentInput];
            ActionToRemap = _myInputs[_currentInput];

        if (Input.anyKeyDown)
        {
            ActionToRemap.action.Disable();
            rebindingOperation = ActionToRemap.action.PerformInteractiveRebinding().OnMatchWaitForAnother(0.1f).OnComplete(operation =>
            {
                ActionToRemap.action.Enable();
            }).Start();

            _currentInput++;
        }

    }

}
