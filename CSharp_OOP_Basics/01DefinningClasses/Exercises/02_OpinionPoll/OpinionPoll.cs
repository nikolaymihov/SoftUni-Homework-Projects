namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OpinionPoll
    {
        private List<Person> people;

        public OpinionPoll()
        {
            this.people = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public List<Person> GetAdultMembers()
        {
            List<Person> addultMembers = new List<Person>();

            foreach (Person member in people)
            {
                if (member.Age > 30)
                {
                    addultMembers.Add(member);
                }
            }
            
            return addultMembers;
            
        }
    }
}
