using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource AS; //soundeffects
    public AudioSource powerupSource; //playerturbo SFX
    public AudioSource BGM; //Background music
    public AudioClip GameMusic;
    public AudioClip DriveSFX, EnemyMoveSFX, CheckpointSFX, ScoreUpSFX, TimerSFX, GameStartSFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic(GameMusic);
    }

    public void PlaySound(AudioClip clip)
    {
        AS.PlayOneShot(clip);
        Debug.Log("Playing SFX: " + clip.name);
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (clip != null)
        {
            BGM.clip = clip;
            BGM.loop = true;
            BGM.Play();
            Debug.Log("Playing BGM: " + clip.name);
        }
        else
        {
            Debug.LogError("BMG AudioClip is not assigned");
        }
    }
}
