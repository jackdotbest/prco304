using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Object
{
    public class Organisation
    {
        private String name, sector, webAddress;
        private Boolean includeRegister, includeMarketing;
        private Single employees;
        private Person pointOfContact, invoiceContact;

        public Organisation()
        {

        }

        public Organisation(String name, String sector, String webAddress, Boolean includeRegister, Boolean includeMarketing, float employees, Person pointOfContact, Person invoiceContact)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.sector = sector ?? throw new ArgumentNullException(nameof(sector));
            this.webAddress = webAddress ?? throw new ArgumentNullException(nameof(webAddress));
            this.includeRegister = includeRegister;
            this.includeMarketing = includeMarketing;
            this.employees = employees;
            this.pointOfContact = pointOfContact ?? throw new ArgumentNullException(nameof(pointOfContact));
            this.invoiceContact = invoiceContact;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(String n)
        {
            this.name = n ?? throw new ArgumentNullException(nameof(n));
        }

        public string getSector()
        {
            return this.sector;
        }

        public void setSector(String sec)
        {
            this.sector = sec ?? throw new ArgumentNullException(nameof(sec));
        }

        public string getWebAddress()
        {
            return this.webAddress;
        }

        public void setWebAddress(String wa)
        {
            this.webAddress = wa ?? throw new ArgumentNullException(nameof(wa));
        }

        public bool getIncludeRegister()
        {
            return this.includeRegister;
        }

        public void setIncludeRegister(Boolean ir)
        {
            this.includeRegister = ir;
        }

        public bool getIncludeMarketing()
        {
            return this.includeMarketing;
        }

        public void setIncludeMarketing(Boolean im)
        {
            this.includeMarketing = im;
        }

        public Single getEmployees()
        {
            return this.employees;
        }

        public void setEmployees(Single emp)
        {
            this.employees = emp;
        }

        public Person getPointOfContact()
        {
            return this.pointOfContact;
        }

        public void setPointofContact(Person poc)
        {
            this.pointOfContact = poc ?? throw new ArgumentNullException(nameof(poc));
        }

        public Person getInvoiceContact()
        {
            return this.invoiceContact;
        }

        public void setInvoiceContact(Person ic)
        {
            this.invoiceContact = ic ?? this.pointOfContact;
        }
    }

}
