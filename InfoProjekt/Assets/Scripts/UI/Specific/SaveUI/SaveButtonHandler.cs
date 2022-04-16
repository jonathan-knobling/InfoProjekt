using Tech.IO.Saves;

namespace UI.Specific.SaveUI
{
    public class SaveButtonHandler
    {
        private readonly string fileName;
        private readonly IOChannelSO ioChannel;

        public SaveButtonHandler(string fileName, IOChannelSO ioChannel)
        {
            this.fileName = fileName;
            this.ioChannel = ioChannel;
        }

        public void ButtonPressed()
        {
            ioChannel.SaveToFile(fileName);
        }
    }
}