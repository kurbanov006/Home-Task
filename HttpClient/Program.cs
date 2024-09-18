using System.Runtime.InteropServices;
using System.Text.Json;


HttpClient client = new HttpClient();
ClientMetod metod = new ClientMetod(client);


Person person = new Person()
{
    Id = 1,
    FirstName = "Abu",
    LastName = "Kurbanov",
    Age = 25
};


// Create Person
// await metod.PostMetod(person);



// Get All Person
// await metod.GetAll();



// Update Person
// await metod.Update(person);



// Delete Person
// await metod.Delete(2);



// Get By Id
// await metod.GetPerson(2);



// Patch Person
await metod.Patch(person);