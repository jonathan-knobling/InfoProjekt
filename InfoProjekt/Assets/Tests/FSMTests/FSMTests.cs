using NUnit.Framework;

namespace Tests.FSMTests
{
    public class FSMTests
    {
        [TestCase("gas", "frozen", 120, -10)]
        [TestCase("frozen", "liquid", -10, 69)]
        [TestCase("liquid", "gas", 10, 400)]
        public void TestFSM(string a, string b, float c, float d)
        {
            var temp = new TestTemperature();
            WaterTestStateHandler waterStateHandler = new WaterTestStateHandler(temp);

            temp.Temp = c;
            waterStateHandler.Update();

            temp.Temp = d;
            waterStateHandler.Update();
            
            Assert.That(waterStateHandler.LastState.Equals(a) && waterStateHandler.CurState.Equals(b));
        }
    }
}