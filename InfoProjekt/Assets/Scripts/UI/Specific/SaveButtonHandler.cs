using Tech.IO.Saves;

namespace UI.Specific
{
    public class SaveButtonHandler
    {
        private readonly string path;
        private readonly SaveChannelSO saveChannel;

        public SaveButtonHandler(string path, SaveChannelSO saveChannel)
        {
            this.path = path;
            this.saveChannel = saveChannel;
        }

        public void ButtonPressed()
        {
            saveChannel.LoadSaveFile(path);
        }
    }
}