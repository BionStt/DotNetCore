using System.Collections.Generic;

namespace DotNetCore.EntityFrameworkCore.Tests
{
    public class FakeEntity
    {
        public FakeEntity()
        {
        }

        public FakeEntity(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public FakeEntity(string name, string surname, FakeValueObject fakeValueObject)
        {
            Name = name;
            Surname = surname;
            FakeValueObject = fakeValueObject;
        }

        public FakeEntity(long id, string name, string surname, FakeValueObject fakeValueObject)
        {
            Id = id;
            Name = name;
            Surname = surname;
            FakeValueObject = fakeValueObject;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public FakeValueObject FakeValueObject { get; private set; }

        public virtual ICollection<FakeEntityChild> FakeEntityChild { get; private set; }
    }
}
