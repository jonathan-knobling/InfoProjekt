namespace Player
{
    public class StatsXPManager
    {
        private readonly Stats stats;
        
        //Multiplier
        //durch level teilen damit es mit jedem level schwerer wird
        private float WalkTimeMultiplier => 0.2f / stats.Level;
        private float ReceivedDamageMultiplier => 0.3f / stats.Level;
        private float DealtDamageMultiplier => 0.02f / stats.Level;
        private float MagicDamageMultiplier => 0.3f / stats.Level;
        private float BlockedDamageMultiplier => 0.2f / stats.Level;

        public StatsXPManager(Stats stats)
        {
            this.stats = stats;
        }

        public void AddWalkTime(float deltaTime)
        {
            var xp = WalkTimeMultiplier * deltaTime;
            stats.AddAgilityXP(xp);
        }

        public void AddReceivedDamage(float receivedDamage)
        {
            var xp = ReceivedDamageMultiplier * receivedDamage;
            stats.AddEnduranceXP(xp);
        }

        public void AddDealtDamage(float dealtDamage)
        {
            var xp = DealtDamageMultiplier * dealtDamage;
            stats.AddStrengthXP(xp);
        }

        public void AddMagicDealtDamage(float magicDamage)
        {
            var xp = MagicDamageMultiplier * magicDamage;
            stats.AddMagicXP(xp);
        }

        public void AddDamageBlocked(float blockedDamage)
        {
            var xp = BlockedDamageMultiplier * blockedDamage;
            stats.AddDexterityXP(xp);
        }
    }
}