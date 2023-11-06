using PackIt.Domain.Entities;
using PackIt.Domain.Events;
using PackIt.Domain.Exceptions;
using PackIt.Domain.Factories;
using PackIt.Domain.Policies;
using PackIt.Domain.ValueObject;
using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PackIt.UnitTests.Domain
{
    public class PackingListTests
    {
        [Fact]
        public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
        {
            //Arrange
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item1", 1));

            //Act
            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item1", 1)));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
        }
        [Fact]
        public void AddItem_Adds_PackingItemAdded_DomainEvent_OnSuccess()
        {
            //Arrange
            var packingList = GetPackingList();

            //Act
            packingList.AddItem(new PackingItem("Item1", 1));
            var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

            //Assert
            @event.ShouldNotBeNull();
            @event.ShouldBeOfType<PackingItemAdded>();
            @event.PackingItem.Name.ShouldBe("Item1");
        }
        [Fact]
        public void PackItem_DoesNotAdd_PackingItemPacked_DomainEvent_OnSuccess()
        {
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item1", 1));

            packingList.PackItem("Item1");
            var @event = packingList.Events.FirstOrDefault() as PackingItemPacked;

            @event.ShouldBeNull();
        }

        #region Arrange
        private readonly IPackingListFactory _packingListFactory;
        public PackingListTests()
        {
            _packingListFactory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
        }
        private PackingList GetPackingList()
        {
            var packingList = _packingListFactory.Create(Guid.NewGuid(), "MyList", Localization.Create("Warsaw, Poland"));
            packingList.ClearEvents();
            return packingList;
        }
        #endregion
    }
}
