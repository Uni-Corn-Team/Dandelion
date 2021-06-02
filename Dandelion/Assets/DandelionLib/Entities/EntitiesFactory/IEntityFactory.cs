namespace DandelionLib.Entities.EntitiesFactory
{
    interface IEntityFactory
    {
        ILittleEntity CreateLittleEntity(int val);
        IMiddleEntity CreateMiddleEntity(int val);
        ILargeEntity CreateLargeEntity(int val);
        IUltimateEntity CreateUltimateEntity(int val);
    }
}
