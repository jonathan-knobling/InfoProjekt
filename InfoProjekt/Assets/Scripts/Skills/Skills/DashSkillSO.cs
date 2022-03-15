using UnityEngine;

namespace Skills.Skills
{
    [CreateAssetMenu(fileName = "Dash", menuName = "Skills/Dash")]
    public class DashSkillSO : ActiveSkillSO
    {

        public float dashDistance;

        public override void Activate(GameObject parent)
        {
            Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
            Vector2 position = parent.transform.position;
            float direction = Mathf.Sign(rb.velocity.x); // x-direction in die sich der Rigidbody bewegt (-1/0/+1) damit die distanz nicht von der moment�ren geschwindigkeit abh�ngig ist
            direction *= dashDistance; // direction mit der distanz multiplizieren
            position.x += direction; // dash zur position addieren
            parent.transform.position = position; // position updaten
        }
    }
}
