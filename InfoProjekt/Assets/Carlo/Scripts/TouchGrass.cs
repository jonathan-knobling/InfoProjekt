using Tech;
using UnityEngine;

namespace Carlo.Scripts
{
    public class TouchGrass : MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] private Animator grassAnimator;
        private AudioSource grassSound;
        private bool isTouching;
        private static readonly int GrassAnimation = Animator.StringToHash("GrassAnimation");

        private void Start()
        {
            grassSound = GetComponent<AudioSource>();
        }
    
        private void Update()
        {
            if (isTouching && eventChannel.PlayerChannel.Velocity > 0.0001f)
            {
                grassAnimator.SetBool(GrassAnimation, true);
                grassSound.Play();
            }

            if (!isTouching || eventChannel.PlayerChannel.Velocity < 0.0001f)
            {
                grassAnimator.SetBool(GrassAnimation , false);
            }
        }
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            isTouching = true;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            isTouching = false;
        }
    }
}
