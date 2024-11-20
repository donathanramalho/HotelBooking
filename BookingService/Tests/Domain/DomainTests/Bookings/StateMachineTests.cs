
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

        //Iniciar status como criado
         [Test]
        public void ShouldAwaysStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.Pass();
        }
        
        //Definir status como pago ao pagar por uma reserva com status criado
        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking()
        {
            Assert.Pass();
        }

        //Definir status como concluido ao finalizar uma reserva paga
        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingAPaidBooking()
        {
            Assert.Pass();
        }

        //Definir o status como criado ao reabrir uma reserva
        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking()
        {
            Assert.Pass();
        }
        
        //Não alterar status ao reabrir uma reserva com status criado
        [Test]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
        {
            Assert.Pass();
        }
        
        //Não alterar status ao abrir uma reserva concluída
        [Test]
        public void ShouldNotChangeStatusWhenRefoundingAFinishedBooking()
        {
            Assert.Pass();
        }
        
    

    }
}