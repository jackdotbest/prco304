using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Object
{
    public class Location
    {
        private Organisation org;
        private String name, line1, line2, line3, city, postcode;
        private Boolean isHQ;

        public Location()
        {

        }

        public Location(Organisation org, string name, string line1, string line2, string line3, string city, string postcode, bool isHQ)
        {
            this.org = org ?? throw new ArgumentNullException(nameof(org));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.line1 = line1 ?? throw new ArgumentNullException(nameof(line1));
            this.line2 = line2 ?? throw new ArgumentNullException(nameof(line2));
            this.line3 = line3;
            this.city = city ?? throw new ArgumentNullException(nameof(city));
            this.postcode = postcode ?? throw new ArgumentNullException(nameof(postcode));
            this.isHQ = isHQ;
        }

        public Organisation getOrg()
        {
            return org;
        }

        public void setOrg(Organisation o)
        {
            this.org = o ?? throw new ArgumentNullException(nameof(o));
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(String n)
        {
            this.name = n ?? throw new ArgumentNullException(nameof(n));
        }

        public string getLine1()
        {
            return this.line1;
        }

        public void setLine1(String l)
        {
            this.name = l ?? throw new ArgumentNullException(nameof(l));
        }

        public string getLine2()
        {
            return this.line2;
        }

        public void setLine2(String m)
        {
            this.line2 = m ?? throw new ArgumentNullException(nameof(m));
        }

        public string getLine3()
        {
            return this.line3;
        }

        public void setLine3(String n)
        {
            this.line3 = n ?? throw new ArgumentNullException(nameof(n));
        }

        public string getCity()
        {
            return this.city;
        }

        public void setCity(String c)
        {
            this.city = c ?? throw new ArgumentNullException(nameof(c));
        }

        public string getPostcode()
        {
            return this.postcode;
        }

        public void setPostcode(String pc)
        {
            this.postcode = pc ?? throw new ArgumentNullException(nameof(pc));
        }

        public bool getIsHQ()
        {
            return this.isHQ;
        }

        public void setIsHQ(Boolean hq)
        {
            this.isHQ = hq;
        }
    }
}
