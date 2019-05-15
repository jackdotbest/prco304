using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{


    public class Rootobject
    {
        public OrgModel[] Property1 { get; set; }
    }

    public class OrgModel
    {
        public int Id { get; set; }
        public string NAME { get; set; }
        public string SECTOR { get; set; }
        public int EMPLOYEES { get; set; }
        public int CONTACTID { get; set; }
        public int INVOICEID { get; set; }
        public string WEBADDRESS { get; set; }
        public bool INCLUDEREGISTER { get; set; }
        public bool INCLUDEMARKETING { get; set; }
        public string USERID { get; set; }
        public LocationModel[] Locations { get; set; }
        public PersonModel Person { get; set; }
        public InvoicePersonModel Person1 { get; set; }
    }

    public class PersonModel
    {
        public int Id { get; set; }
        public int TITLE { get; set; }
        public string FORENAME { get; set; }
        public string SURNAME { get; set; }
        public string JOBROLE { get; set; }
        public string EMAIL { get; set; }
        public object[] Organisations { get; set; }
        public object[] Organisations1 { get; set; }
    }

    public class InvoicePersonModel
    {
        public int Id { get; set; }
        public int TITLE { get; set; }
        public string FORENAME { get; set; }
        public string SURNAME { get; set; }
        public string JOBROLE { get; set; }
        public string EMAIL { get; set; }
        public object[] Organisations { get; set; }
        public object[] Organisations1 { get; set; }
    }

    public class LocationModel
    {
        public int Id { get; set; }
        public int ORGID { get; set; }
        public string NAME { get; set; }
        public string LINE1 { get; set; }
        public string LINE2 { get; set; }
        public string LINE3 { get; set; }
        public string CITY { get; set; }
        public string POSTCODE { get; set; }
        public bool MAINSITE { get; set; }
    }




}
