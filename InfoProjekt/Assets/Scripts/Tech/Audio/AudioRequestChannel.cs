using System;
using Util.EventArgs;

namespace Tech.Audio
{
    public class AudioRequestChannel
    {
        public event EventHandler<AudioRequestArgs> AudioRequestHandler;

        public void RequestAudio(AudioRequestArgs args)
        {
            AudioRequestHandler?.Invoke(this, args);
        }
    }
}