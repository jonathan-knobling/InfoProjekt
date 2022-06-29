namespace Tech.IO.Saves
{
    public interface ISaveable
    {
        object SerializeComponent();
        void ApplySerializedData(object serializedData);
    }
}