using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagringsKlass
{
  
      public class lagring 
     {
        private string name, email, adress, phone;

        public lagring()
        {

            name = null;
            email = null;
            adress = null;
            phone = null;

        }

        public lagring(string input_name ,string input_adress,string input_email,string input_number)
        {
            name = input_name;
            adress = input_adress;
            email = input_email;
            phone = input_number;

        } 
        //sets
        public void SetName(string n)
        {
            name = n;
        } 
        public void SetAdress(string a)
        {
            adress = a;
        } 
        public void SetEmail(string e)
        {
            email = e;
        } 
        public void SetPhoneNR(string p)
        {
            phone = p;
        }
        //gets 
        public string GetName()
        {
            return name;
        } 
        public string GetAdress()
        {
            return adress;
        }
        public string GetEmail()
        {
            return email;
        }
        public string GetPhoneNR()
        {
            return phone;
        } 

        public void Print()
        {
            Console.WriteLine("lagrad data i leden " + "\n" + GetName() + "\n" + GetAdress() + "\n" + GetEmail() + "\n" + GetPhoneNR() + "\n");
        }


      }
}
