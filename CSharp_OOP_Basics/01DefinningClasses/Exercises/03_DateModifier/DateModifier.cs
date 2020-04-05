namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DateModifier
    {
        private string firstDate;
        private string secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }

        public string FirstDate
        {
            get
            {
                return this.firstDate;
            }
            set
            {
                this.firstDate = value;
            }
                
        }

        public string SecondDate
        {
            get
            {
                return this.secondDate;
            }
            set
            {
                this.secondDate = value;
            }
        }

        public double getDifferenceInDays (string firstDate, string secondDate)
        {
            DateTime dateOne = Convert.ToDateTime(firstDate);
            DateTime dateTwo = Convert.ToDateTime(secondDate);

            double diffInDays = (dateOne - dateTwo).TotalDays;

            return diffInDays;
        }
    }
}
