using Tech;

namespace UI.Specific.SaveUI
{
    public class SaveButtonHandler
    {
        private readonly string fileName;
        private readonly EventChannelSO eventChannel;

        public SaveButtonHandler(string fileName, EventChannelSO eventChannel)
        {
            this.fileName = fileName;
            this.eventChannel = eventChannel;
        }

        public void ButtonPressed()
        {
            eventChannel.IOChannel.SaveToFile(fileName);
        }
    }
}