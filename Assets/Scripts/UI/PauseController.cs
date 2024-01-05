using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    private bool _isPaused = false;

    public UnityEvent OnPause;
    public UnityEvent OnResume;
    public void Pause()
    {
        if(_isPaused)
        {
            Time.timeScale = 1f;
            OnResume.Invoke();
        }
        else
        {
            Time.timeScale = 0f;
            OnPause.Invoke();
        }
        _isPaused = !_isPaused;
    }

}
