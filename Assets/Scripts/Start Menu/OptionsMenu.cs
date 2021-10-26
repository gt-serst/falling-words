using UnityEngine;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetSoundVolume (float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }
     
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
