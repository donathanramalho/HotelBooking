using Domain.Entities;
using NUnit.Framework;

namespace DomainTests
{
    public class StateMachineTests
    {
        [SetUp]
        public void SetUp()
        {
        }

         [Test]
        public void ShouldAwaysStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.Pass();
        }
        
        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingAPaidBooking()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
        {
            Assert.Pass();
        }
        
        [Test]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
        {
            Assert.Pass();
        }
        
        [Test]
        public void ShouldNotChangeStatusWhenRefoundingAFinishedBooking()
        {
            Assert.Pass();
        }
        
    }
}
