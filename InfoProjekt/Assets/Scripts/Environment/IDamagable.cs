using System.ComponentModel;

namespace Environment
{
    public interface IDamagable
    {
        [Description("Damages the Object and returns the actual amount of damage taken")]
        float DealDamage(float damage);
    }
}