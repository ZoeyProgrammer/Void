using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    /*
    public Slider musicSlider;
    public Slider soundSlider;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI soundText;

    GameManager gm;
    public AudioMixer masterMixer;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();

        musicSlider.value = gm.musicVolume;
        float musicPercent = (gm.musicVolume + 80) * 100 / 80;
        musicText.text = Mathf.RoundToInt(musicPercent) + "%";

        soundSlider.value = gm.soundVolume;
        float soundPercent = (gm.soundVolume + 80) * 100 / 80;
        soundText.text = Mathf.RoundToInt(soundPercent) + "%";

    }

    public void MusicSlider(float newValue)
    {
        gm.musicVolume = newValue;
        masterMixer.SetFloat("musicVolume", newValue);
        float decibelToPercent = (newValue + 80) * 100 / 80;
        musicText.text = Mathf.RoundToInt(decibelToPercent) + "%";
    }

    public void SoundSlider(float newValue)
    {
        gm.soundVolume = newValue;
        masterMixer.SetFloat("soundVolume", newValue);
        float decibelToPercent = (newValue + 80) * 100 / 80;
        soundText.text = Mathf.RoundToInt(decibelToPercent) + "%";
    }

    public void CloseOptions()
    {
        Destroy(this.gameObject);
    }
    */
}
