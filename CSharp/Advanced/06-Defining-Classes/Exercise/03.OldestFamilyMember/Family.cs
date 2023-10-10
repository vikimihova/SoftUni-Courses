using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
		private Person member;

		public Person Member
		{
			get { return member; }
			set { member = value; }
		}


		private List<Person> members;

		public List<Person> Members
		{
			get { return members; }
			set { members = value; }
		}

		public void AddMember(Person member)
		{
			Members.Add(member);
		}

		public Person GetOldestMember()
		{
			Person oldestMember = Members.OrderByDescending(x => x.Age).First();

			return oldestMember;
		}
	}
}
