namespace Player.Stats
{
    public class StatsXPManager
    {
        private readonly PlayerStats stats;

        public StatsXPManager(PlayerStats stats)
        {
            this.stats = stats;
            UniversalXPMultiplier = 1f;
        }

        public float UniversalXPMultiplier { get; set; }

        //Multiplier
        //durch level teilen damit es mit jedem level schwerer wird
        private float WalkTimeMultiplier => UniversalXPMultiplier * 0.2f / stats.Level;
        private float ReceivedDamageMultiplier => UniversalXPMultiplier * 0.3f / stats.Level;
        private float DealtDamageMultiplier => UniversalXPMultiplier * 0.02f / stats.Level;
        private float MagicDamageMultiplier => UniversalXPMultiplier * 0.3f / stats.Level;
        private float BlockedDamageMultiplier => UniversalXPMultiplier * 0.2f / stats.Level;

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