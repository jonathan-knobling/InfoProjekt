using System;
using UnityEngine;
using Util.EventArgs;

namespace Sound
{
    public class AudioManager: MonoBehaviour
    {
        [SerializeField] public AudioRequestChannelSO audioRequestChannel;

        private AudioSource musicSource;

        private void Start()
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            audioRequestChannel.AudioRequestHandler += PlaySound;
        }

        public void PlaySound(object sender, AudioRequestArgs args)
        {
            if (args.isMusic)
            {
                ChangeMusic(args);
            }
            //Instantiate new GameObject with AudioManager transform as parent
            GameObject sourceObject = Instantiate(new GameObject(), transform, true);
            //Attach audio source to the object
            AudioSource source = sourceObject.AddComponent<AudioSource>();
            
            //Apply eventargs data
            sourceObject.transform.position = args.position;
            source.clip = args.clip;
            source.volume = args.volume;
            source.loop = args.loop;

        }

        private void ChangeMusic(AudioRequestArgs args)
        {
            musicSource.clip = args.clip;
            musicSource.volume = args.volume;
            musicSource.loop = true;
            musicSource.priority = Int32.MinValue;
            musicSource.Play();
        }
    }
}