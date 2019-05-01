using Locker;
using System;
using Xunit;

namespace LockerTest
{
    public class LockerManagerTest
    {
        [Fact]
        public void LockerManager_When_DefaultConstructor_Should_NumberOfLockersBeFour()
        {
            LockerManager lockerMgr = new LockerManager();
            Assert.Equal(4, lockerMgr.NumberOfLockers);
        }

        [Fact]
        public void LockerManager_When_NoOfLockersIsZero_Should_ThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => new LockerManager(0));
            Assert.Equal("Invalid number of lockers 0", ex.Message);
        }

        [Fact]
        public void LockerManager_When_NoOfLockersIsNegative_Should_ThorwException()
        {
            Exception ex = Assert.Throws<Exception>(() => new LockerManager(-1));
            Assert.Equal("Invalid number of lockers -1", ex.Message);
        }

        [Fact]
        public void LockerManager_When_NoOfLockersIsNotDivisibleByFour_Should_ThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => new LockerManager(6));
            Assert.Equal("Number of Lockers Should be multiples of 4", ex.Message);
        }

        [Fact]
        public void LockerManager_When_NoOfLockersProvided_Should_CreateLockerInstances()
        {
            Assert.Equal(40, new LockerManager(40).NumberOfLockers);
        }

        [Fact]
        public void PlaceBox_When_BoxIsNull_Should_ThrowExpeption()
        {
            Exception ex = Assert.Throws<Exception>(() => new LockerManager().PlaceBox(null));
            Assert.Equal("Box is not valid", ex.Message);
        }

        [Fact]
        public void PlaceBox_When_NoAvailableSlots_Should_ThrowException()
        {
            LockerManager lockerMgr = new LockerManager();
            Assert.Equal(4, lockerMgr.SlotsAvailable);
            lockerMgr.PlaceBox(new Box(Size.Small));
            lockerMgr.PlaceBox(new Box(Size.Medium));
            lockerMgr.PlaceBox(new Box(Size.Large));
            lockerMgr.PlaceBox(new Box(Size.ExtraLarge));
            Assert.Equal(0, lockerMgr.SlotsAvailable);
            Assert.Equal(4, lockerMgr.SlotsOccupied);
            Exception ex = Assert.Throws<Exception>(() => lockerMgr.PlaceBox(new Box(Size.Small)));
            Assert.Equal("No slots available", ex.Message);
        }

        [Fact]
        public void PlaceBox_When_SlotOfBoxSizeNotAvailable_Should_PlaceBoxAtHigherSizeSlotAvailable()
        {
            LockerManager lockerMgr = new LockerManager();
            Assert.Equal(4, lockerMgr.SlotsAvailable);
            lockerMgr.PlaceBox(new Box(Size.Small));
            lockerMgr.PlaceBox(new Box(Size.Medium));
            lockerMgr.PlaceBox(new Box(Size.Large));
            Assert.Equal(1, lockerMgr.SlotsAvailable);
            Assert.Equal(3, lockerMgr.SlotsOccupied);
            lockerMgr.PlaceBox(new Box(Size.Small));
            Assert.Equal(4, lockerMgr.SlotsOccupied);
        }

        [Fact]
        public void PickUpBox_When_NoSlotsOccupied_Should_ThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => new LockerManager().PickUpBox(Guid.NewGuid().ToString()));
            Assert.Equal("Box is not available", ex.Message);
        }

        [Fact]
        public void PickUpBox_When_BoxNumberIsNotValid_Should_ThrowException()
        {
            LockerManager lockerMgr = new LockerManager();
            lockerMgr.PlaceBox(new Box());
            Exception ex = Assert.Throws<Exception>(() => lockerMgr.PickUpBox(String.Empty));
            Assert.Equal("Box number is not valid", ex.Message);
        }

        [Fact]
        public void PickUpBox_When_BoxNotAvailable_Should_ThrowException()
        {
            LockerManager lockerMgr = new LockerManager();
            lockerMgr.PlaceBox(new Box());
            Exception ex = Assert.Throws<Exception>(() => lockerMgr.PickUpBox(Guid.NewGuid().ToString()));
            Assert.Equal("Box is not available", ex.Message);
        }

        [Fact]
        public void PickUpBox_When_BoxNumberIsValid_Should_ReturnBoxAndAddEmptySlotBackToAvailableSlotsBucket()
        {
            LockerManager lockerMgr = new LockerManager();
            Box box = new Box();
            string boxNumber = box.ID;
            lockerMgr.PlaceBox(box);
            Assert.Equal(3, lockerMgr.SlotsAvailable);
            Assert.Equal(1, lockerMgr.SlotsOccupied);
            Assert.Equal(boxNumber, lockerMgr.PickUpBox(boxNumber).ID);
            Assert.Equal(4, lockerMgr.SlotsAvailable);
            Assert.Equal(0, lockerMgr.SlotsOccupied);
        }
    }
}
