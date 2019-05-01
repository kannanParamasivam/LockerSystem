using Locker;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LockerTest
{
    public class BoxTest
    {
        [Fact]
        public void Box_When_SizeNotProvided_Should_DefaultToSizeSmall()
        {
            Assert.Equal(Size.Small, (new Box()).Size);
        }

        [Fact]
        public void Box_When_CreatedWithDefaultConstructor_Should_CreateUniqueID()
        {
            Assert.True(!string.IsNullOrEmpty((new Box()).ID.ToString()));
        }

        [Fact]
        public void Box_When_SizeProvided_Should_AssignTheSize()
        {
            Assert.Equal(Size.Medium, (new Box(Size.Medium)).Size);
        }

        [Fact]
        public void Box_When_CreatedWithSizeContructor_Should_GenerateID()
        {
            Assert.True(!String.IsNullOrWhiteSpace((new Box(Size.Medium).ID.ToString())));
        }
    }
}
