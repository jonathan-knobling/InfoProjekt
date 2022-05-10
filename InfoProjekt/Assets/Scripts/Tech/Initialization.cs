using System.IO;
using UnityEngine;

namespace Tech
{
    public class Initialization: MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            //Initialize Services and GameObjects
            //GameObject initialization = Instantiate(Resources.Load("Initialization")) as GameObject;
            //DontDestroyOnLoad(initialization);
            
            //player und enemy layers ignoren collision
            Physics2D.IgnoreLayerCollision(7,8);
            //enemies untereinander ignoren collision
            Physics2D.IgnoreLayerCollision(7,7);
            
            //Create Save Directory if it doesnt exist
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
    }
}