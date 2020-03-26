using House4uClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace House4uClient
{
    class Program
    {
        static async Task GetsClubsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63083/api/Property/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/ Property / 
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedProps = await response.Content.ReadAsAsync<IEnumerable<Property>>();
                    Console.WriteLine("*** Complete Property List ****");
                    foreach (Property prop in returnedProps)
                    {
                        Console.WriteLine(prop);
                    }
                }

                //GET api/ Property /{ id}
                response = await client.GetAsync("1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedProp = await response.Content.ReadAsAsync<Property>(); 
                    Console.WriteLine("\nProperty with ID 1: " + returnedProp);
                }

                //GET api/ Property /emails
                response = await client.GetAsync("emails");
                if (response.IsSuccessStatusCode)
                {
                    var returnedProp = await response.Content.ReadAsAsync<IEnumerable<String>>();
                    Console.WriteLine("\nReturned Emails");
                    foreach (var item in returnedProp)
                    {
                        Console.WriteLine(item.ToString() + "\n");
                    }
                }


                //POST api/ Property / AddProperty
                Property g1 = new Property() { ID = 4, Address = "4 Main Sreet", Email = "Rick@Yahoo.com", ExpiryDate = new DateTime(2020, 03, 01), LType = LeaseType.FullyDelagated, NoBedrooms = 7 };
                response = client.PostAsJsonAsync("AddProperty", g1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Property: " + g1.Address);
                }

                //PUT api/ Property / UpdateProperty
                Property p2 = new Property() { ID = 4, Address = "4 Main Sreet", Email = "Rick@Yahoo.com", ExpiryDate = new DateTime(2020, 03, 01), LType = LeaseType.FullyDelagated, NoBedrooms = 25 };
                response = client.PutAsJsonAsync("UpdateProperty", p2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Property: " + p2.Address + " increasing bedrooms to  " + p2.NoBedrooms);
                }
            }
        }

        static void Main()
        {
            GetsClubsAsync().Wait();
            Console.ReadLine();
        }
    }
}
