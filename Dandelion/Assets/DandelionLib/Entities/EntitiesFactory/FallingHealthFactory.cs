using DandelionLib.Entities.FallingEntities;

namespace DandelionLib.Entities.EntitiesFactory
{
    class FallingHealthFactory: IEntityFactory
    {
        public ILargeEntity CreateLargeEntity(int val)
        {
            return new FallingLargeHealth(val);
        }

        public ILittleEntity CreateLittleEntity(int val)
        {
            return new FallingLittleHealth(val);
        }

        public IMiddleEntity CreateMiddleEntity(int val)
        {
            return new FallingMiddleHealth(val);
        }

        public IUltimateEntity CreateUltimateEntity(int val)
        {
            return new FallingUltimateHeath(val);
        }
    }
}
