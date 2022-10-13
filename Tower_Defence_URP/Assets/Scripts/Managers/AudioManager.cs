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
    [SerializeField] private MusicAudioClip[] musicAudioClips;

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
        GameStart,
        EnemySpawn,
        EnemyDeath,
        EnemyExit
    }

    public enum Music
    {
        AttackPhase,
        BuildingPhase,
        Menu,
        GameOver
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip[] audioClips;
        [Range(0f, 1f)] public float volume = 1f;

        public bool isLoop;
    }

    [System.Serializable]
    public class MusicAudioClip
    {
        public Music music;
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
        Debug.LogWarning("Sound " + sound + " not found!");
        return null;
    }

    private MusicAudioClip GetMusicAudioClip(Music music)
    {
        foreach (MusicAudioClip musicAudioClip in musicAudioClips)
        {
            if (musicAudioClip.music.Equals(music))
            {
                if (musicAudioClip.audioClips.Length > 0)
                {
                    return musicAudioClip;
                }
                break;
            }
        }
        Debug.LogWarning("Music " + music + " not found!");
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

    private AudioClip GetAudioClip(MusicAudioClip musicAudioClip)
    {
        if (musicAudioClip.audioClips.Length > 0)
        {
            return musicAudioClip.audioClips[Random.Range(0, musicAudioClip.audioClips.Length)];
        }
        Debug.LogError("Music " + musicAudioClip + " not found!");
        return null;
    }

    private bool CanPlaySound(SoundAudioClip soundAudioClip)
    {
        if (soundAudioClip == null || GetAudioClip(soundAudioClip) == null)
        {
            return false;
        }
        Sound sound = soundAudioClip.sound;
        switch (sound)
        {
            default:
                return true;
        }
    }

    private bool CanPlayMusic(MusicAudioClip musicAudioClip)
    {
        if (musicAudioClip == null || GetAudioClip(musicAudioClip) == null)
        {
            return false;
        }
        Music music = musicAudioClip.music;
        switch (music)
        {
            default:
                return true;
        }
    }

    public void PlaySound(Sound sound)
    {
        SoundAudioClip audio = GetSoundAudioClip(sound);
        if (CanPlaySound(audio))
        {
            effectsSource.PlayOneShot(GetAudioClip(audio), audio.volume);
        }
    }

    public void PlayMusic(Music music)
    {
        MusicAudioClip audio = GetMusicAudioClip(music);
        if (CanPlayMusic(audio))
        {
            musicSource.volume = audio.volume;
            musicSource.loop = true;
            musicSource.clip = GetAudioClip(audio);
            musicSource.Play();
        }
    }
}
