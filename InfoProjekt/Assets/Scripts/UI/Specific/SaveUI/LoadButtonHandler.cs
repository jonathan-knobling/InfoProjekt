using Tech.IO.Saves;

namespace UI.Specific.SaveUI
{
    public class LoadButtonHandler
    {
        private readonly string path;
        private readonly IOChannelSO ioChannel;

        public LoadButtonHandler(string path, IOChannelSO ioChannel)
        {
            this.path = path;
            this.ioChannel = ioChannel;
        }

        public void ButtonPressed()
        {
            ioChannel.LoadSaveFile(path);
        }
    }
}