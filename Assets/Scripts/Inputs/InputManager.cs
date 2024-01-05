using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public static PlayerControls _input { private set; get; }
    [Header("Vectors")]
    [SerializeField] private InputVectorScriptableObject _vector1;
    [SerializeField] private InputVectorScriptableObject _vector2;
    [Header("Buttons")]
    [SerializeField] private InputButtonScriptableObject _action1;
    [SerializeField] private InputButtonScriptableObject _action2;
    [SerializeField] private InputButtonScriptableObject _action3;
    [SerializeField] private InputButtonScriptableObject _action4;
    [SerializeField] private InputButtonScriptableObject _pause;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this);
        _input = new PlayerControls();

    }
    private void OnEnable()
    {
        EnableGameInput();
    }
    private void OnDisable()
    {
        DisableGameInput();
    }
    public void EnableGameInput()
    {
        _input.Game.Enable();

        //Vectors
        _input.Game.Vector1.performed += ctx => _vector1.ChangeValue(_input.Game.Vector1.ReadValue<Vector2>());
        _input.Game.Vector1.canceled  += ctx => _vector1.ChangeValue(Vector2.zero);
        
        _input.Game.Vector2.performed += ctx => _vector2.ChangeValue(_input.Game.Vector2.ReadValue<Vector2>());
        _input.Game.Vector2.canceled  += ctx => _vector2.ChangeValue(Vector2.zero);

        //Buttons
        _input.Game.Pause.performed   += ctx => _pause.ChangeValue(true);
        _input.Game.Pause.canceled    += ctx => _pause.ChangeValue(false);

        _input.Game.Action1.performed += ctx => _action1.ChangeValue(true);
        _input.Game.Action1.canceled  += ctx => _action1.ChangeValue(false);

        _input.Game.Action2.performed += ctx => _action2.ChangeValue(true);
        _input.Game.Action2.canceled  += ctx => _action2.ChangeValue(false);

        _input.Game.Action3.performed += ctx => _action3.ChangeValue(true);
        _input.Game.Action3.canceled  += ctx => _action3.ChangeValue(false);

        _input.Game.Action4.performed += ctx => _action4.ChangeValue(true);
        _input.Game.Action4.canceled  += ctx => _action4.ChangeValue(false);

    }
    void DisableGameInput()
    {
        //Vectors
        _input.Game.Vector1.performed -= ctx => _vector1.ChangeValue(_input.Game.Vector1.ReadValue<Vector2>());
        _input.Game.Vector1.canceled  -= ctx => _vector1.ChangeValue(Vector2.zero);

        _input.Game.Vector2.performed -= ctx => _vector2.ChangeValue(_input.Game.Vector2.ReadValue<Vector2>());
        _input.Game.Vector2.canceled  -= ctx => _vector2.ChangeValue(Vector2.zero);

        //Buttons
        _input.Game.Pause.performed   -= ctx => _pause.ChangeValue(true);
        _input.Game.Pause.canceled    -= ctx => _pause.ChangeValue(false);

        _input.Game.Action1.performed -= ctx => _action1.ChangeValue(true);
        _input.Game.Action1.canceled  -= ctx => _action1.ChangeValue(false);

        _input.Game.Action2.performed -= ctx => _action2.ChangeValue(true);
        _input.Game.Action2.canceled  -= ctx => _action2.ChangeValue(false);

        _input.Game.Action3.performed -= ctx => _action3.ChangeValue(true);
        _input.Game.Action3.canceled  -= ctx => _action3.ChangeValue(false);

        _input.Game.Action4.performed -= ctx => _action4.ChangeValue(true);
        _input.Game.Action4.canceled  -= ctx => _action4.ChangeValue(false);


        _input.Game.Disable();
    }

    public static bool IsInputGamepad()
    {
        InputDevice lastUsedDevice = null;
        float lastEventTime = 0;
        foreach (var device in InputSystem.devices)
        {
            if (device.lastUpdateTime > lastEventTime)
            {
                lastUsedDevice = device;
                lastEventTime = (float)device.lastUpdateTime;
            }
        }

        return lastUsedDevice is Gamepad;
    }
}

