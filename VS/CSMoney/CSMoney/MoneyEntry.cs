using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSMoney
{
    public class MoneyEntry
    {
        private double _ammount;

        /// <summary>
        /// Standartnij konstruktor
        /// </summary>
        public MoneyEntry()
        {
            _ammount = 0;
            EntryDate = DateTime.Now;
        }
        /// <summary>
        /// Konstructor
        /// </summary>
        /// <param name="ammount"> Summa zapisi</param>
        /// <param name="date">Data zapisi </param>
        public MoneyEntry(double ammount, DateTime date)
        {
            _ammount = ammount;
            EntryDate = date;
        }
        /// <summary>
        /// Inicaliziruet Objekt s pomosju strok
        /// </summary>
        /// <param name="ammount"> Summa zapisi</param>
        /// <param name="date">Data zapisi </param>
        public void InitWithString(string ammount, string date)
        {
            Double.TryParse(ammount, out _ammount);

            DateTime dt;
            DateTime.TryParse(date, out dt);
            EntryDate = dt;
        }

        public override string ToString()
        {
            return string.Format("{0} to {1}", _ammount, EntryDate.Date);
        }
        /// <summary>
        /// Opredeliaetsia zapis dohoda
        /// </summary>
        public bool IsDebit
        {
            get
            {
                return (_ammount >= 0);
            }
            set
            {
                if (value && _ammount < 0)
                    _ammount = -_ammount;
            }
        }
        /// <summary>
        /// Summa zapisi
        /// </summary>
        public double Ammount
        {
            get { return _ammount; }
            set { _ammount = value; }
        }
        /// <summary>
        /// Data zapisi
        /// </summary>
        public DateTime EntryDate { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
