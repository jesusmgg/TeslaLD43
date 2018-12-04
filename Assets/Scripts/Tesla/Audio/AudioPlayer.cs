using UnityEngine;

namespace Tesla.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [Header("Music and ambiance")]
        public AudioClip sailingMusic;
        public AudioClip sailingAmbiance;
        public AudioClip enemyMusic;

        [Header("UI Effects")]
        public AudioClip click;
        public AudioClip endOfTheDay;
        public AudioClip fished;
        public AudioClip splash;

        AudioSource audioSource;
        
        AudioSource musicPlayer;
        AudioSource ambiancePlayer;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            musicPlayer = gameObject.AddComponent<AudioSource>();
            ambiancePlayer = gameObject.AddComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void StartMusic(AudioClip clip)
        {
            musicPlayer.clip = clip;
            musicPlayer.loop = true;
            musicPlayer.Play();
        }
        
        public void StopMusic()
        {
            musicPlayer.Stop();
        }

        public void StartAmbiance()
        {
            ambiancePlayer.clip = sailingAmbiance;
            ambiancePlayer.loop = true;
            ambiancePlayer.Play();
        }

        public void StopAmbiance()
        {
            ambiancePlayer.Stop();
        }
    }
}