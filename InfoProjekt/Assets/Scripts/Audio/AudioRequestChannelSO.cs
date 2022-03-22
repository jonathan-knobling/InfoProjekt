using System;
using UnityEngine;
using Util.EventArgs;

namespace Audio
{
    [CreateAssetMenu(menuName = "Channels/Audio Request Channel")]
    public class AudioRequestChannelSO: ScriptableObject
    {
        public event EventHandler<AudioRequestArgs> AudioRequestHandler;

        public void RequestAudio(AudioRequestArgs args)
        {
            AudioRequestHandler?.Invoke(this, args);
        }
    }
}