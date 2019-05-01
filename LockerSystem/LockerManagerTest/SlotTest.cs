using Locker;
using System;
using Xunit;

namespace LockerTest
{
    public class SlotTest
    {
        [Fact]
        public void Slot_When_DefaultContructorCalled_Should_Create_UniquID()
        {
            Assert.True(!String.IsNullOrWhiteSpace(new Slot().ID));
        }

        [Fact]
        public void Slot_When_DefaultConstructorCalled_Should_SizeBeSmall()
        {
            Assert.Equal(Size.Small, new Slot().Size);
        }

        [Fact]
        public void Slot_When_SizeProvided_Should_CreateUniqueID()
        {
            Assert.True(!String.IsNullOrWhiteSpace(new Slot(Size.Medium).ID));
        }

        [Fact]
        public void Slot_WhenSizeProvided_Should_ContainTheGivenSize()
        {
            Assert.Equal(Size.Medium, new Slot(Size.Medium).Size);
        }

        [Fact]
        public void IsEmpty_When_SlotIsEmpty_Should_BeTrue()
        {
            Assert.True(new Slot().IsEmpty);
        }

        [Fact]
        public void IsEmpty_When_SlotHasBox_Should_BeFalse()
        {
            Slot slot = new Slot();
            slot.PlaceBox(new Box());

            Assert.False(slot.IsEmpty);
        }

        [Fact]
        public void EmptyTheSlot_When_NoBox_Should_ThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => new Slot().EmptyTheSlot());
            Assert.Equal("Slot Is Empty", ex.Message);
        }

        [Fact]
        public void EmptyTheSlot_When_HasBox_Should_ReturnTheBox()
        {
            Slot slot = new Slot();
            slot.PlaceBox(new Box(Size.Medium));

            Assert.True(slot.EmptyTheSlot()?.Size == Size.Medium);
        }

        [Fact]
        public void PlaceBox_When_SlotIsNotEmpty_Should_Throw_Excpetion()
        {
            Slot slot = new Slot();
            slot.PlaceBox(new Box());

            Exception ex = Assert.Throws<Exception>(() => slot.PlaceBox(new Box()));
            Assert.Equal("Slot is occupied", ex.Message);
        }

        [Fact]
        public void PlaceBox_When_BoxIsNull_Should_ThrowException()
        {
            Slot slot = new Slot();
            Exception ex = Assert.Throws<Exception>(() => slot.PlaceBox(null));
            Assert.Equal("Box is not valid", ex.Message);
        }

        [Fact]
        public void PlaceBox_When_BoxIsValidAndSlotIsEmpty_Should_BeAbleToPlaceBox()
        {
            Slot slot = new Slot();
            slot.PlaceBox(new Box(Size.Medium));
            Assert.False(slot.IsEmpty);
        }
    }
}
