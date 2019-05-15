using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Object
{
    public class Person
    {
        private string forename, surname, jobTitle, emailAddress, title;

        public Person()
        {

        }

        public Person(string forename, string surname, string jobTitle, string emailAddress, string title)
        {
            this.forename = forename ?? throw new ArgumentNullException(nameof(forename));
            this.surname = surname ?? throw new ArgumentNullException(nameof(surname));
            this.jobTitle = jobTitle ?? throw new ArgumentNullException(nameof(jobTitle));
            this.emailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            this.title = title;
        }

        public string getForename()
        {
            return this.forename;
        }

        public string getSurname()
        {
            return this.surname;
        }

        public string getJobTitle()
        {
            return this.jobTitle;
        }

        public string getTitle()
        {
            return this.title;
        }

        public string getEmailAddress()
        {
            return this.emailAddress;
        }

        public void setForename(string fname)
        {
            if (fname != null)
            {
                this.forename = fname;
            }
            else throw new ArgumentNullException(nameof(forename));
        }

        public void setSurname(string sname)
        {
            if (sname != null) { this.surname = sname; } else throw new ArgumentNullException(nameof(surname));
        }

        public void setJobTitle(string jTitle)
        {
            if (jTitle != null) { this.jobTitle = jTitle; } else throw new ArgumentNullException(nameof(jobTitle));
        }

        public void setTitle(string t)
        {
            this.title = t;
        }

        public void setEmailAddress(string email)
        {
            if (email != null) { this.emailAddress = email; } else throw new ArgumentNullException(nameof(emailAddress));
        }

    }
}
