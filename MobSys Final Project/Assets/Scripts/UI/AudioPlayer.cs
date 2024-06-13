using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip moduleOpen;
    [SerializeField] AudioClip buttonClick;

    private static AudioPlayer instance;
    private static float volume;

    void Awake()
    {
        instance = this;
        volume = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public static void SetVolume(float newVolume)
    {
        newVolume = Mathf.Clamp01(newVolume);
        volume = newVolume;
        PlayerPrefs.SetFloat("Volume", newVolume);
    }

    public static void PlayAudioClip(AudioClip audioClip)
    {
        instance?.audioSource.PlayOneShot(audioClip, volume);
    }

    public static void PlayModuleOpen()
    {
        PlayAudioClip(instance.moduleOpen);
    }

    public static void PlayButtonClick()
    {
        PlayAudioClip(instance.buttonClick);
    }
}
