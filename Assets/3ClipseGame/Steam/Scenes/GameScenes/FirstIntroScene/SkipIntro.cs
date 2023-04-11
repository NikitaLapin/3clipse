using System.Collections;
using _3ClipseGame.Steam.Scenes.GameScenes.FirstIntroScene;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkipIntro : MonoBehaviour
{
    [SerializeField] private InputAction _skipIntroButton;
    [SerializeField] private float _holdButtonTimeToSkip = 2f;
    [SerializeField] private RectTransform _skipHint;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private WaitAndSave _waitAndSave;

    private float _currentSkipProgress;
    
    private void OnEnable()
    {
        _skipIntroButton.Enable();
        _skipIntroButton.started += OnSkipIntroButtonPressed;
        _skipIntroButton.canceled += OnSkipIntroButtonCanceled;
    }
    
    private void OnDisable()
    {
        _skipIntroButton.Disable();
        _skipIntroButton.started -= OnSkipIntroButtonPressed;
        _skipIntroButton.canceled -= OnSkipIntroButtonCanceled;
    }

    private void OnSkipIntroButtonPressed(InputAction.CallbackContext context)
    {
        _skipHint.gameObject.SetActive(true);
        StopCoroutine(UnskipTimer());
        StartCoroutine(SkipTimer());
    }

    private void OnSkipIntroButtonCanceled(InputAction.CallbackContext context)
    {
        StopCoroutine(SkipTimer());
        StartCoroutine(UnskipTimer());
    }

    private IEnumerator SkipTimer()
    {
        while (_currentSkipProgress < _holdButtonTimeToSkip)
        {
            _currentSkipProgress += Time.deltaTime;
            _progressBar.value = _currentSkipProgress / _holdButtonTimeToSkip;
            yield return null;
        }
        
        _waitAndSave.Skip();
    }

    private IEnumerator UnskipTimer()
    {
        while (_currentSkipProgress > 0f)
        {
            _currentSkipProgress -= Time.deltaTime;
            _progressBar.value = _currentSkipProgress / _holdButtonTimeToSkip;
            yield return null;
        }

        _currentSkipProgress = 0f;
        _skipHint.gameObject.SetActive(false);
    }
}
