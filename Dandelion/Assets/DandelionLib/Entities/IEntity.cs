namespace DandelionLib.Entities
{
    public interface IEntity
    {
        int ColideValue { get; }

        void Colide(ICanColideWithEntity colideble);
    }
}
