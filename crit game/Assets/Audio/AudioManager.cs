using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [SerializeField] public AudioClip music;
    [SerializeField] public AudioClip playerAttackSFX;
    [SerializeField] public AudioClip healthPickupSFX;


    private void Start()
    {
        //Volume change with slider
        musicSource.volume = 0.4f;

        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
