using Actors.Player.Stats;
using Tech;
using UnityEngine;

namespace Gameplay.Abilities.Active.Magic
{
    [CreateAssetMenu(menuName = "Abilities/Active/Magic/Firebolt", fileName = "Firebolt")]
    public class FireboltMagic: MagicAbility
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float mpUsage = 3f;
        [SerializeField] private float fireboltSpeed = 15f;
        private Camera cam;
        
        public override void Init(EventChannelSO eventChannel, GameObject parentObject, AbilityManager abilityManager)
        {
            Parent = parentObject;
            eventChannel.InputChannel.OnSkill2ButtonPressed += OnSkillButtonPressed;
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            id = "firebolt";
        }

        public override void Update()
        {
            State.Update();
        }

        private void OnSkillButtonPressed()
        {
            Debug.Log("made it here ");
            
            var position = Parent.transform.position;
            //position der maus in der scene
            Vector2 mousePosInWorld = cam.ScreenToWorldPoint(Input.mousePosition);
            //richtung von parent zu maus
            Vector2 direction = (mousePosInWorld - (Vector2) position).normalized;

            var parentCollider = Parent.GetComponent<Collider2D>().bounds;
            //calculate posistion to instantiate projectile
            //center of collider + ( extentsCollider + extentsColliderProjectil) * direction
            Vector2 spawnPos = (Vector2) parentCollider.center +
                               (parentCollider.extents.y +
                                projectilePrefab.GetComponent<CircleCollider2D>().radius) * 1.1f * direction;
            
            var projectile = Instantiate(
                projectilePrefab,
                spawnPos,
                //rotation in richtung der maus position
                //new Quaternion(0f, 0f, math.atan2(direction.y, direction.x), 0f)
                Parent.transform.rotation
            );
            var rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * fireboltSpeed;
            rb.gravityScale = 0f;

            Parent.GetComponent<PlayerStats>().UseMP(mpUsage);
            
            //sound?
            //animation?
        }
    }
}