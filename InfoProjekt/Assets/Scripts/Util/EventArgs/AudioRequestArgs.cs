using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Util.EventArgs
{
    [Serializable]
    public class AudioRequestArgs
    {
        public AudioClip clip;
        public Vector3 position;
        public bool isMusic;
        public bool loop;

        [Range(0f, 1f)][UnityEngine.Min(0f)][Max(1f)]
        public float volume;

        public AudioRequestArgs(AudioClip clip, bool isMusic, Vector3 position, float volume, bool loop)
        {
            this.clip = clip;
            this.isMusic = isMusic;
            this.position = position;
            this.volume = volume;
            this.loop = loop;
        }
        
        public AudioRequestArgs(AudioClip clip, Vector3 position, float volume, bool loop)
        {
            this.clip = clip;
            this.position = position;
            this.volume = volume;
            this.loop = loop;
            isMusic = false;
        }

        public AudioRequestArgs(AudioClip clip)
        {
            this.clip = clip;
            isMusic = false;
            position = new Vector3(0, 0, 0);
            volume = 1f;
            loop = false;
        }
    }
}