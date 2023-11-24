using OONV.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV.classes
{
    class Order : IOrderObservable
    {
        public double Price { get; private set; }
        private IPaymentStrategy PaymentMethod { get; set; }
        public List<string> Food { get; private set; }
        public List<IOrderObserver> Observers { get; private set; }
        private IOrderState CurrentState { get; set; }

        public Order()
        {
            Price = 0;
            Food = new List<string>();
            Observers = new List<IOrderObserver>();
            CurrentState = new OrderIntroductionState(this);
            PaymentMethod = new CashMethod();
        }

        public void AddItemToOrder(MenuItem item)
        {
            Food.Add(item.Name);
            Price += item.Price;
        }

        //-ObserverLogic-----------------------------------------

        public void Attach(IOrderObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IOrderObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in Observers)
            {
                observer.Update(message);
            }
        }

        //-StateLogic---------------------------------------------
        public void SetState(IOrderState new_state)
        {
            CurrentState = new_state;
        }
        public void PizzeriaIntro(Pizzeria pizzeria)
        {
            CurrentState.PizzeriaIntro(pizzeria);
        }

        public void OrderDetails(Pizzeria pizzeria) 
        {
            CurrentState.OrderDetails(pizzeria);
        }

        public void OrderPaymentDetails(Pizzeria pizzeria)
        {
            CurrentState.OrderPaymentDetails(pizzeria);
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            CurrentState.PrepareOrder(pizzeria);
        }

        public void OrderReady()
        {
            CurrentState.OrderReady();
        }
        //-StrategyLogic---------------------------------------------
        public void SetPaymentStrategy(IPaymentStrategy strategy) 
        {
            PaymentMethod = strategy;
        }

        public bool DoPaymentStrategy(double price) 
        {
            return PaymentMethod.ProcessPayment(price);
        }
    }
}
