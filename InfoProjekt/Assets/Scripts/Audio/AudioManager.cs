using System;
using Audio;
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
                return;
            }

            if (args.parent != null)
            {
                AddAudioSource(args, args.parent);
            }
            else
            {
                AddAudioSource(args, transform);
            }
        }

        private void AddAudioSource(AudioRequestArgs args, Transform parent)
        {
            //Instantiate new GameObject and add parent
            GameObject sourceObject = Instantiate(new GameObject(), parent);
            //Attach audio source to the object
            AudioSource source = sourceObject.AddComponent<AudioSource>();
            
            //Apply eventargs data
            source.clip = args.clip;
            source.volume = args.volume;
            source.loop = args.loop;
            source.priority = args.priority;
            source.spatialize = args.spatialize;
            source.spatialBlend = args.spatialBlend;
            source.minDistance = args.minDistance;
            source.maxDistance = args.maxDistance;
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