using System.Text.Json;
using Domain.Entities.Quote;

namespace Infrastructure.Repositories;

public class QuotesByProgrammersUsingJson : IObtainQuotesPort
{
    private readonly Quote[] _quotes;
    private const string FILE_NAME = @"C:\Users\Sander\source\repos\QuotesReaderWithHexagonalArchitecture\Infrastructure\Quotes.json";

    public QuotesByProgrammersUsingJson()
    {
        string jsonString = File.ReadAllText(FILE_NAME);
        _quotes = JsonSerializer.Deserialize<Quote[]>(jsonString);
    }

    public Quote GetRandomQuote()
    {
        var random = Random.Shared.Next(0, _quotes.Length);
        return _quotes[random];
    }
}