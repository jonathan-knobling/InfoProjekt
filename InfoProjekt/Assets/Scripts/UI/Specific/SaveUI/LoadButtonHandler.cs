using Tech;
using Tech.IO.Saves;

namespace UI.Specific.SaveUI
{
    public class LoadButtonHandler
    {
        private readonly string path;
        private readonly EventChannelSO eventChannel;

        public LoadButtonHandler(string path, EventChannelSO eventChannel)
        {
            this.path = path;
            this.eventChannel = eventChannel;
        }

        public void ButtonPressed()
        {
            eventChannel.IOChannel.LoadSaveFile(path);
        }
    }
}