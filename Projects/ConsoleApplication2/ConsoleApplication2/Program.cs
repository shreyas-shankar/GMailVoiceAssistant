using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Feed<Contact> f = cr.GetContacts();
            foreach (Contact entry in f.Entries)
            {
                if (entry.Name != null)
                {
                    Name name = entry.Name;
                    if (!string.IsNullOrEmpty(name.FullName))
                        Console.WriteLine("\t\t" + name.FullName);
                    else
                        Console.WriteLine("\t\t (no full name found)");
                    if (!string.IsNullOrEmpty(name.NamePrefix))
                        Console.WriteLine("\t\t" + name.NamePrefix);
                    else
                        Console.WriteLine("\t\t (no name prefix found)");
                    if (!string.IsNullOrEmpty(name.GivenName))
                    {
                        string givenNameToDisplay = name.GivenName;
                        if (!string.IsNullOrEmpty(name.GivenNamePhonetics))
                            givenNameToDisplay += " (" + name.GivenNamePhonetics + ")";
                        Console.WriteLine("\t\t" + givenNameToDisplay);
                    }
                    else
                        Console.WriteLine("\t\t (no given name found)");
                    if (!string.IsNullOrEmpty(name.AdditionalName))
                    {
                        string additionalNameToDisplay = name.AdditionalName;
                        if (string.IsNullOrEmpty(name.AdditionalNamePhonetics))
                            additionalNameToDisplay += " (" + name.AdditionalNamePhonetics + ")";
                        Console.WriteLine("\t\t" + additionalNameToDisplay);
                    }
                    else
                        Console.WriteLine("\t\t (no additional name found)");
                    if (!string.IsNullOrEmpty(name.FamilyName))
                    {
                        string familyNameToDisplay = name.FamilyName;
                        if (!string.IsNullOrEmpty(name.FamilyNamePhonetics))
                            familyNameToDisplay += " (" + name.FamilyNamePhonetics + ")";
                        Console.WriteLine("\t\t" + familyNameToDisplay);
                    }
                    else
                        Console.WriteLine("\t\t (no family name found)");
                    if (!string.IsNullOrEmpty(name.NameSuffix))
                        Console.WriteLine("\t\t" + name.NameSuffix);
                    else
                        Console.WriteLine("\t\t (no name suffix found)");
                }
                else
                    Console.WriteLine("\t (no name found)");
                foreach (EMail email in entry.Emails)
                {
                    Console.WriteLine("\t" + email.Address);
                }
            }

        }
    }
}
