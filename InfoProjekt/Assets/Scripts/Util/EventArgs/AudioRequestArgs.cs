using System;
using System.ComponentModel;
using UnityEngine;

namespace Util.EventArgs
{
    [Serializable]
    public class AudioRequestArgs
    {
        [Header("Clip Data")]
        public AudioClip clip;
        public bool isMusic;
        public bool loop;

        [Range(0f, 1f)]
        public float volume;

        [Header("Optional")]
        public Transform parent;
        public Int32 priority = Int32.MaxValue / 2;
        
        [Description("Enable 3D")]
        public bool spatialize;
        
        [Description("Distance where the sound stops getting louder")]
        public float minDistance = 7f;
        
        [Description("Max Distance where the sound is still audible")]
        public float maxDistance = 2.5f;

        [Range(0f, 1f)][Description("Blend between 2D and 3D")]
        public float spatialBlend;
        

        public AudioRequestArgs(AudioClip clip, bool isMusic, bool loop, float volume, Transform parent, Int32 priority, bool spatialize, float minDistance, float maxDistance, float spatialBlend)
        {
            this.parent = parent;
            this.clip = clip;
            this.isMusic = isMusic;
            this.volume = volume;
            this.loop = loop;
            this.priority = priority;
            this.spatialize = spatialize;
            this.minDistance = minDistance;
            this.maxDistance = maxDistance;
            this.spatialBlend = spatialBlend;
        }

        public AudioRequestArgs(AudioClip clip, float volume)
        {
            this.clip = clip;
            isMusic = false;
            this.volume = volume;
            loop = false;
        }
    }
}