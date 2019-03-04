using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEvents
{
    class Button
    {
        #region Variante lang
        //private EventHandler buttonClickEvent;
        //public event EventHandler ButtonClickEvent
        //{
        //    add
        //    {
        //        buttonClickEvent += value;
        //    }
        //    remove
        //    {
        //        buttonClickEvent -= value;
        //    }
        //} 
        #endregion

        public event EventHandler ButtonClickEvent;
        public void Klick()
        {
            try
            {
                ButtonClickEvent?.Invoke(this,EventArgs.Empty);
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
    }
}
