using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private bool _isMenuActive;
    [SerializeField] private GameObject _settingsMenu;

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Image _overlayIMage;
    [SerializeField] private Slider _sliderBrightness;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivatePauseBehavior();
        }
    }
    public void PauseMenuBehavior()
    {
        switch (_isMenuActive)
        {
            case true:
                _settingsMenu.SetActive(true);
                Time.timeScale = 0;
                break;
            case false:
                _settingsMenu.SetActive(false);
                Time.timeScale = 1;
                break;
        }
    }

    public void ActivatePauseBehavior()
    {
        _isMenuActive = !_isMenuActive;
        PauseMenuBehavior();
    }

    public void AdjustVolume()
    {
        _mixer.SetFloat("BG_Exposed_Volume", _sliderMusic.value);
    }

    public void AdjustBrightness()
    {
        Color overlayColor = _overlayIMage.color;
        overlayColor.a = _sliderBrightness.value;
        _overlayIMage.color = overlayColor;
    }
}
