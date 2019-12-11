namespace DotNetCore.EntityFrameworkCore.Tests
{
    public sealed class FakeRepository : EntityFrameworkCoreRelationalRepository<FakeEntity>, IFakeRepository
    {
        public FakeRepository(FakeContext context) : base(context)
        {
        }
    }
}
