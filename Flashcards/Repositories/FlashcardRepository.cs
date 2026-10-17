using Flashcards.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly string _connectionString;

        public FlashcardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MSSql")
                ?? throw new InvalidOperationException("Connection string 'MSSql' was not found");
        }

        public void PrintConnectionString()
        {
            Console.WriteLine(_connectionString);
            Console.ReadKey();
        }

        public async Task<List<Flashcard>> GetAllFlashcardsAsync(CancellationToken cancellationToken = default)
        {
            var flashcards = new List<Flashcard>();

            await using var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            const string query = """SELECT Id, Front, Back, StackID FROM Flashcards""";

            await using var command = new SqlCommand(query, connection);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                var flashcard = new Flashcard
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Front = reader.GetString(reader.GetOrdinal("Front")),
                    Back = reader.GetString(reader.GetOrdinal("Back")),
                    StackID = reader.GetInt32(reader.GetOrdinal("StackID"))
                };

                flashcards.Add(flashcard);
            }

            return flashcards;
        }
    }
}
