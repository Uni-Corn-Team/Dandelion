namespace DandelionLib.Entities.FallingEntities
{
    abstract class FallingHealth : IFallingEntity
    {
        public int ColideValue { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="healthValue">positive num</param>
        public FallingHealth(int healthValue)
        {
            ColideValue = healthValue;
        }

        public void Colide(ICanColideWithEntity colideble)
        {
            colideble.ChangeHealth(ColideValue);
        }
    }
}
