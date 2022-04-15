using Tech.IO.Saves;

namespace UI.Specific.SaveUI
{
    public class SaveButtonHandler
    {
        private readonly string path;
        private readonly IOChannelSO ioChannel;

        public SaveButtonHandler(string path, IOChannelSO ioChannel)
        {
            this.path = path;
            this.ioChannel = ioChannel;
        }

        public void ButtonPressed()
        {
            ioChannel.SaveToFile(path);
        }
    }
}