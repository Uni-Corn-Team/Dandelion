using DandelionLib.Enums;

namespace DandelionLib
{
    interface IUnityEntityObject
    {
        EntityType Id { get; }
        void Colide(ICanColideWithEntity colideble);
    }
}
