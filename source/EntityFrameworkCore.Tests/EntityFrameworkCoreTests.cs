using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.EntityFrameworkCore.Tests
{
    [TestClass]
    public class EntityFrameworkCoreTests
    {
        public EntityFrameworkCoreTests()
        {
            var services = new ServiceCollection();

            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Tests;Integrated Security=true;Connection Timeout=5;";

            services.AddDbContextPool<FakeContext>(options => options.UseSqlServer(connectionString));

            Context = services.BuildServiceProvider().GetService<FakeContext>();

            Context.Database.EnsureCreated();

            Context.Database.Migrate();

            Repository = new FakeRepository(Context);

            SeedDatabase();
        }

        private FakeContext Context { get; }

        private IFakeRepository Repository { get; }

        [TestMethod]
        public void Add()
        {
            var entity = CreateEntity();
            Repository.Add(entity);
            Context.SaveChanges();
            Assert.IsNotNull(Repository.Select(entity.Id));
        }

        [TestMethod]
        public void AddAsynchronous()
        {
            var entity = CreateEntity();
            Repository.AddAsync(entity);
            Context.SaveChanges();
            Assert.IsNotNull(Repository.Select(entity.Id));
        }

        [TestMethod]
        public void AddRange()
        {
            var count = Repository.Count();
            Repository.AddRange(new List<FakeEntity> { CreateEntity() });
            Context.SaveChanges();
            Assert.IsTrue(Repository.Count() > count);
        }

        [TestMethod]
        public void AddRangeAsynchronous()
        {
            var count = Repository.Count();
            Repository.AddRangeAsync(new List<FakeEntity> { CreateEntity() });
            Context.SaveChanges();
            Assert.IsTrue(Repository.Count() > count);
        }

        [TestMethod]
        public void Any()
        {
            Assert.IsTrue(Repository.Any());
        }

        [TestMethod]
        public void AnyAsynchronous()
        {
            Assert.IsTrue(Repository.AnyAsync().Result);
        }

        [TestMethod]
        public void AnyWhere()
        {
            Assert.IsTrue(Repository.Any(w => w.Id == 1L));
        }

        [TestMethod]
        public void AnyWhereAsynchronous()
        {
            Assert.IsTrue(Repository.AnyAsync(w => w.Id == 1L).Result);
        }

        [TestMethod]
        public void Count()
        {
            Assert.IsTrue(Repository.Count() > 0);
        }

        [TestMethod]
        public void CountAsynchronous()
        {
            Assert.IsTrue(Repository.CountAsync().Result > 0);
        }

        [TestMethod]
        public void CountWhere()
        {
            Assert.IsTrue(Repository.Count(w => w.Id == 1) == 1L);
        }

        [TestMethod]
        public void CountWhereAsynchronous()
        {
            Assert.IsTrue(Repository.CountAsync(w => w.Id == 1L).Result == 1L);
        }

        [TestMethod]
        public void Delete()
        {
            Repository.Delete(70L);
            Context.SaveChanges();

            Assert.IsNull(Repository.Select(70L));
        }

        [TestMethod]
        public void DeleteAsynchronous()
        {
            Repository.DeleteAsync(80L);
            Context.SaveChanges();

            Assert.IsNull(Repository.Select(80L));
        }

        [TestMethod]
        public void DeleteWhere()
        {
            Repository.Delete(w => w.Id == 90L);
            Context.SaveChanges();

            Assert.IsNull(Repository.Select(90L));
        }

        [TestMethod]
        public void DeleteWhereAsynchronous()
        {
            Repository.DeleteAsync(w => w.Id == 100L);
            Context.SaveChanges();

            Assert.IsNull(Repository.Select(100L));
        }

        [TestMethod]
        public void FirstOrDefault()
        {
            Assert.IsNotNull(Repository.FirstOrDefault(x => x.Id == 1));
        }

        [TestMethod]
        public void FirstOrDefaultAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultAsync(x => x.Id == 1).Result);
        }

        [TestMethod]
        public void FirstOrDefaultInclude()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultInclude(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void FirstOrDefaultIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultIncludeAsync(i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void FirstOrDefaultWhere()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultWhereInclude(w => w.Id == 1));
        }

        [TestMethod]
        public void FirstOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultWhereIncludeAsync(w => w.Id == 1).Result);
        }

        [TestMethod]
        public void FirstOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultWhereInclude(w => w.Id == 1, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void FirstOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultWhereIncludeAsync(w => w.Id == 1, i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void FirstOrDefaultWhereSelect()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultWhereSelect(w => w.Id == 1, s => s.FakeEntityChild));
        }

        [TestMethod]
        public void FirstOrDefaultWhereSelectAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultWhereSelectAsync(w => w.Id == 1, s => s.FakeEntityChild).Result);
        }

        [TestMethod]
        public void List()
        {
            Assert.IsTrue(Repository.List().Any());
        }

        [TestMethod]
        public void ListAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync().Result);
        }

        [TestMethod]
        public void ListInclude()
        {
            Assert.IsTrue(Repository.ListInclude().Any());
        }

        [TestMethod]
        public void ListIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.ListIncludeAsync(i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void ListIncludePagedList()
        {
            Assert.IsNotNull(Repository.ListInclude(CreatePagedListParameters(), i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListIncludePagedListResult()
        {
            Assert.IsNotNull(Repository.ListInclude<FakeEntityModel>(CreatePagedListParameters(), i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListIncludeResult()
        {
            Assert.IsNotNull(Repository.ListInclude<FakeEntityModel>(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListIncludeResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListIncludeAsync<FakeEntityModel>(i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void ListPagedList()
        {
            Assert.IsNotNull(Repository.List(CreatePagedListParameters()));
        }

        [TestMethod]
        public void ListPagedListAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync(CreatePagedListParameters()).Result);
        }

        [TestMethod]
        public void ListPagedListResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(CreatePagedListParameters()));
        }

        [TestMethod]
        public void ListPagedListResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync<FakeEntityModel>(CreatePagedListParameters()).Result);
        }

        [TestMethod]
        public void ListPagedListResultOrderByNavigationProperty()
        {
            var parameters = new PagedListParameters
            {
                Order = new Order
                {
                    Property = $"{nameof(FakeValueObject)}.{nameof(FakeValueObject.Property1)}",
                    Ascending = false
                }
            };

            var result = Repository.List<FakeEntityModel>(parameters);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListPagedListResultOrderByProperty()
        {
            var parameters = new PagedListParameters
            {
                Order = new Order
                {
                    Property = nameof(FakeEntityModel.Id),
                    Ascending = false
                }
            };

            var result = Repository.List<FakeEntityModel>(parameters);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>());
        }

        [TestMethod]
        public void ListResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync<FakeEntityModel>().Result);
        }

        [TestMethod]
        public void ListWhere()
        {
            Assert.IsNotNull(Repository.ListWhereInclude(w => w.Id == 1));
        }

        [TestMethod]
        public void ListWhereAsync()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync(w => w.Id == 1).Result);
        }

        [TestMethod]
        public void ListWhereAsynchronous()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync(w => w.Id == 1).Result);
        }

        [TestMethod]
        public void ListWhereInclude()
        {
            Assert.IsNotNull(Repository.ListWhereInclude(w => w.Id == 1, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereIncludeAsync()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync(w => w.Id == 1, i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void ListWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync(w => w.Id == 1, i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void ListWhereIncludePagedList()
        {
            Assert.IsNotNull(Repository.ListWhereInclude(CreatePagedListParameters(), w => w.Id == 1, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereIncludePagedListAsynchronous()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync(CreatePagedListParameters(), w => w.Id == 1, i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void ListWhereIncludePagedListResult()
        {
            Assert.IsNotNull(Repository.ListWhereInclude<FakeEntityModel>(CreatePagedListParameters(), w => w.Id == 1, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereIncludePagedListResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync<FakeEntityModel>(CreatePagedListParameters(), w => w.Id == 1, i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void ListWhereIncludeResult()
        {
            Assert.IsNotNull(Repository.ListWhereInclude<FakeEntityModel>(w => w.Id == 1, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWherePagedList()
        {
            Assert.IsNotNull(Repository.ListWhereInclude(CreatePagedListParameters(), w => w.Id == 1));
        }

        [TestMethod]
        public void ListWherePagedListAsynchronous()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync(CreatePagedListParameters(), w => w.Id == 1).Result);
        }

        [TestMethod]
        public void ListWherePagedListResult()
        {
            Assert.IsNotNull(Repository.ListWhereInclude<FakeEntityModel>(CreatePagedListParameters(), w => w.Id == 1));
        }

        [TestMethod]
        public void ListWherePagedListResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListWhereIncludeAsync<FakeEntityModel>(CreatePagedListParameters(), w => w.Id == 1).Result);
        }

        [TestMethod]
        public void ListWhereResult()
        {
            Assert.IsNotNull(Repository.ListWhereInclude<FakeEntityModel>(w => w.Id == 1));
        }

        [TestMethod]
        public void Select()
        {
            Assert.IsNotNull(Repository.Select(1L));
        }

        [TestMethod]
        public void SelectAsynchronous()
        {
            Assert.IsNotNull(Repository.SelectAsync(1L).Result);
        }

        [TestMethod]
        public void SelectResult()
        {
            var result = Repository.Select<FakeEntityModel>(1L);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public void SelectResultAsynchronous()
        {
            var result = Repository.SelectAsync<FakeEntityModel>(1L).Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public void SingleOrDefault()
        {
            Assert.IsNotNull(Repository.SingleOrDefault(w => w.Id == 1L));
        }

        [TestMethod]
        public void SingleOrDefaultAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultAsync(w => w.Id == 1L).Result);
        }

        [TestMethod]
        public void SingleOrDefaultWhere()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultWhereInclude(w => w.Id == 1L));
        }

        [TestMethod]
        public void SingleOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultWhereIncludeAsync(w => w.Id == 1L).Result);
        }

        [TestMethod]
        public void SingleOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultWhereInclude(w => w.Id == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void SingleOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultWhereIncludeAsync(w => w.Id == 1L, i => i.FakeEntityChild).Result);
        }

        [TestMethod]
        public void SingleOrDefaultWhereSelect()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultWhereSelect(w => w.Id == 1L, s => s));
        }

        [TestMethod]
        public void SingleOrDefaultWhereSelectAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultWhereSelectAsync(w => w.Id == 1L, s => s).Result);
        }

        [TestMethod]
        public void Update()
        {
            var entity = new FakeEntity(1L, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new FakeValueObject());

            Repository.Update(1L, entity);

            Context.SaveChanges();

            var entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.Name, entityDatabase.Name);
        }

        [TestMethod]
        public void UpdateSelect()
        {
            var entityDatabase = Repository.Select(1L);

            Assert.IsNotNull(entityDatabase);

            var entity = new FakeEntity(1L, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new FakeValueObject());

            Repository.Update(1L, entity);

            Context.SaveChanges();

            entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.Name, entityDatabase.Name);
        }

        [TestMethod]
        public void UpdateAsynchronous()
        {
            var entity = new FakeEntity(1L, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new FakeValueObject());

            Repository.UpdateAsync(1L, entity);

            Context.SaveChanges();

            var entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.Name, entityDatabase.Name);
        }

        [TestMethod]
        public void UpdatePartial()
        {
            var entity = new
            {
                Name = Guid.NewGuid().ToString()
            };

            Repository.UpdatePartial(1L, entity);

            Context.SaveChanges();

            var entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.Name, entityDatabase.Name);
            Assert.IsNotNull(entityDatabase.Surname);
        }

        [TestMethod]
        public void UpdateValueObject()
        {
            var entity = new FakeEntity(1L, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new FakeValueObject(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));

            Repository.Update(1L, entity);

            Context.SaveChanges();

            var entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.FakeValueObject.Property1, entityDatabase.FakeValueObject.Property1);
            Assert.AreEqual(entity.FakeValueObject.Property2, entityDatabase.FakeValueObject.Property2);
        }

        private static FakeEntity CreateEntity()
        {
            return new FakeEntity
            (
                $"Name {Guid.NewGuid().ToString()}",
                $"Surname {Guid.NewGuid().ToString()}",
                new FakeValueObject("Property", "Property")
            );
        }

        private static PagedListParameters CreatePagedListParameters()
        {
            return new PagedListParameters();
        }

        private void SeedDatabase()
        {
            if (Context.Set<FakeEntity>().Any()) { return; }

            for (var i = 1L; i <= 100; i++)
            {
                Repository.Add(CreateEntity());
            }

            Context.SaveChanges();
        }
    }
}
