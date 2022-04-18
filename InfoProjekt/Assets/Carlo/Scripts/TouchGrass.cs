using Actors.Player;
using UnityEngine;

namespace Assets.Carlo.Scripts
{
    public class TouchGrass : MonoBehaviour
    {
        [SerializeField] private PlayerMovementChannelSO movementChannel;
        [SerializeField] private Animator grassAnimator;
        private AudioSource grassSound;
        private bool isTouching;
    
        private void Start()
        {
            grassSound = GetComponent<AudioSource>();
        }
    
        private void Update()
        {
            if (isTouching && movementChannel.Velocity > 0.0001f)
            {
                grassAnimator.SetBool("GrassAnimation", true);
                grassSound.Play();
            }

            if (!isTouching || movementChannel.Velocity < 0.0001f)
            {
                grassAnimator.SetBool("GrassAnimation" , false);
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
