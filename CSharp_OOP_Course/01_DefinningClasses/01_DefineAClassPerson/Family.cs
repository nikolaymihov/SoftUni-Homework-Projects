namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Family
    {
        private List<Person> people;
        
        public Family()
        {
            this.people = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }
}
