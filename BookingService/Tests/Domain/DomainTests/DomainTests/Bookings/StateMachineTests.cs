
using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;

namespace DomainTests
{
    public class StateMachineTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        //Iniciar status como criado
        [Test]
        public void ShouldAwaysStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.AreEqual(booking.Status, Status.Created);
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking()
        {
            var booking = new Booking();
            booking.ChangeState(Action.Pay);
            Assert.AreEqual(booking.Status, Status.Paid);
        }

        //Definir status como cancelado...
        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Action.Cancel);
            Assert.AreEqual(booking.Status, Status.Canceled);
        }

        //Definir status como concluido ao finalizar uma reserva paga
        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingAPaidBooking()
        {
            var booking = new Booking();

            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(booking.Status, Status.Refounded);
        }

        //Definir o status como criado ao reabrir uma reserva
        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
        {
            var booking = new Booking();

            booking.ChangeState(Action.Reopen);
            Assert.AreEqual(booking.Status, Status.Created);
        }

        //Não alterar status ao reabrir uma reserva com status criado
        [Test]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
        {
            var booking = new Booking();

            booking.ChangeState(Action.Refound);
            Assert.AreEqual(booking.Status, Status.Created);
        }

        //Não alterar status ao abrir uma reserva concluída
        [Test]
        public void ShouldNotChangeStatusWhenRefoundingAFinishedBooking()
        {
            var booking = new Booking();

            booking.ChangeState(Action.Pay);
            booking.ChangeState(Action.Finish);
            booking.ChangeState(Action.Refound);
            Assert.AreEqual(booking.Status, Status.Finished);
        }

    }
}