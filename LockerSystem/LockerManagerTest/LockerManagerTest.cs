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
    }
}
