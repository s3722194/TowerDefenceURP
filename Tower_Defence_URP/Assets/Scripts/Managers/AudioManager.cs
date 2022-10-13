using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio players
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    // Audio clips
    [SerializeField] private SoundAudioClip[] soundAudioClips;

    private Dictionary<Sound, float> soundTimerDictionary;

    public enum Sound
    {
        Plasma,
        Orb,
        Mist,
        Toxic,
        Blaze,
        Chain,
        BlackHole,
        DeathRay,
        PlaceTower,
        UpgradeTower,
        SellTower,
        WaveStart,
        WaveEnd,
        MenuTransition,
        GameOver,
        GameStart
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip[] audioClips;
        [Range(0f, 1f)] public float volume = 1f;

        public bool isLoop;
    }

    private SoundAudioClip GetSoundAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in soundAudioClips)
        {
            if (soundAudioClip.sound.Equals(sound))
            {
                if (soundAudioClip.audioClips.Length > 0)
                {
                    return soundAudioClip;
                }
                break;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }

    private AudioClip GetAudioClip(SoundAudioClip soundAudioClip)
    {
        if (soundAudioClip.audioClips.Length > 0)
        {
            return soundAudioClip.audioClips[Random.Range(0, soundAudioClip.audioClips.Length)];
        }
        Debug.LogError("Sound " + soundAudioClip + " not found!");
        return null;
    }

    private bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
        }
    }

    public void PlaySound(Sound sound)
    {
        SoundAudioClip audio = GetSoundAudioClip(sound);
        if (audio != null)
        {
            effectsSource.volume = audio.volume;
            effectsSource.PlayOneShot(GetAudioClip(audio));
        }
    }
}
