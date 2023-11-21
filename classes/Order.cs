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
        public IPaymentStrategy PaymentMethod { get; private set; }
        public List<string> Food { get; private set; }
        public List<IOrderObserver> Observers { get; private set; }
        public IOrderState CurrentState { get; set; }

        public Order()
        {
            Price = 0;
            Food = new List<string>();
            Observers = new List<IOrderObserver>();
            CurrentState = new OrderIntroductionState();
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
        public void PizzeriaIntro(Pizzeria pizzeria)
        {
            CurrentState.PizzeriaIntro(this, pizzeria);
        }

        public void OrderDetails(Pizzeria pizzeria) 
        {
            CurrentState.OrderDetails(this, pizzeria);
        }

        public void OrderPaymentDetails(Pizzeria pizzeria)
        {
            CurrentState.OrderPaymentDetails(this, pizzeria);
        }

        public void PrepareOrder(Pizzeria pizzeria)
        {
            CurrentState.PrepareOrder(this, pizzeria);
        }

        public void OrderReady()
        {
            CurrentState.OrderReady(this);
        }

        public void SetPaymentStrategy(IPaymentStrategy strategy) 
        {
            PaymentMethod = strategy;
        }
    }
}
