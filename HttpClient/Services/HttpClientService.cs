
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Xml;


public class ClientMetod
{
    private HttpClient client;
    public ClientMetod(HttpClient client)
    {
        this.client = client;
    }


    public async Task PostMetod(Person person)
    {
        try
        {
            JsonContent content = JsonContent.Create(person);

            HttpResponseMessage response = await client.PostAsync("http://localhost:5160/Person", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Успешно!");
                string con = await response.Content.ReadAsStringAsync();
                Console.WriteLine(con);
            }
            else
                Console.WriteLine("Error");
        }

        catch (HttpRequestException ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }

        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task GetAll()
    {
        try
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5160/Person");
            HttpResponseMessage response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Person>? persons = JsonSerializer.Deserialize<IEnumerable<Person>>(content);

                foreach (var r in persons!)
                {
                    System.Console.WriteLine($"ID: {r.Id}");
                    System.Console.WriteLine($"FirstName: {r.FirstName}");
                    System.Console.WriteLine($"LastName: {r.LastName}");
                    System.Console.WriteLine($"Age: {r.Age}");
                    System.Console.WriteLine();
                }
            }

        }

        catch (HttpRequestException ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }

        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            throw;
        }
    }



    public async Task Update(Person person)
    {
        JsonContent content = JsonContent.Create(person);

        HttpResponseMessage response = await client.PutAsync("http://localhost:5160/Person", content);

        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("Успешно!");
            string con = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(con);
        }
        else
            System.Console.WriteLine("Error");
    }


    public async Task Delete(int id)
    {
        string url = $"http://localhost:5160/Person/{id}";

        HttpResponseMessage response = await client.DeleteAsync(url);
        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine($"Person Удалён");
            string con = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(con);
        }
        else
            System.Console.WriteLine("Не получилось удалить");
    }


    public async Task GetPerson(int id)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5160/Person/{id}");
        HttpResponseMessage response = client.Send(request);

        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("Person успешно получен! ");

            string con = await response.Content.ReadAsStringAsync();

            Person? person = JsonSerializer.Deserialize<Person>(con);

            System.Console.WriteLine($"Id: {person?.Id}, Firstname: {person?.FirstName}, LastName: {person?.LastName}, Age: {person?.Age}");
        }
        else
            System.Console.WriteLine($"Не получилочь получить Person по ID = {id}");
    }


    public async Task Patch(Person person)
    {
        JsonContent content = JsonContent.Create(person);

        HttpResponseMessage response = await client.PatchAsync("http://localhost:5160/Person", content);
        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("Успешно обновлён!");
            string con = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(con);
        }
        else System.Console.WriteLine("Error");
    }




}