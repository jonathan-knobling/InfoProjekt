using UnityEngine;

namespace IO
{
    public class Initialization: MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            GameObject initialization = Instantiate(Resources.Load("Initialization")) as GameObject;
            DontDestroyOnLoad(initialization);
        }
    }
}