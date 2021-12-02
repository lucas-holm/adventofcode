// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;

HttpClient client = new();
var request = new HttpRequestMessage()
{
    RequestUri = new Uri("https://adventofcode.com/2021/day/1/input"),
    Method = HttpMethod.Get
};
request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
var cookie = "";
request.Headers.Add("cookie", "session=" + cookie);

var responseBody = await client.SendAsync(request);
var content = await responseBody.Content.ReadAsStringAsync();
var stringArr = content.Trim().Split();
var numbers = Array.ConvertAll<string, int>(stringArr, s => int.Parse(s));

var count = 0;
var index = 0;

while (index < numbers.Length - 1)
{
    if (numbers[index + 1] > numbers[index])
    {
        count++;
    }
    index++;
}

Console.WriteLine(count);



