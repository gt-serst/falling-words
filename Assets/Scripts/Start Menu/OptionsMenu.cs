using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{
	public AudioMixer	audioMixer;
	public Slider		musicSlider;
	public Slider		effectsSlider;

	public void Start()
	{
		musicSlider.value = PlayerPrefs.GetFloat("Music", 1f);
		effectsSlider.value = PlayerPrefs.GetFloat("Sound", 1f);
		//Set the volume at the start
		audioMixer.SetFloat("Music", musicSlider.value);
		audioMixer.SetFloat("Sound", effectsSlider.value);
	}
	public void SetVolume (float volume)
	{
		PlayerPrefs.SetFloat("Music", volume);
		audioMixer.SetFloat("Music", volume);
	}
	public void SetSoundVolume (float soundVolume)
	{
		PlayerPrefs.SetFloat("Sound", soundVolume);
		audioMixer.SetFloat("Sound", soundVolume);
	}
}
