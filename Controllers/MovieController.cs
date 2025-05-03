using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300041.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static readonly List<Movie> movies = new() { 
            new Movie ("The Shawshank Redemption","Frank Darabont",new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton" },"A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie ("The Godfather","Francis Ford Coppola",new List<string>{"Marlon Brando", "Al Pacino", "James Caan" },"The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie ("The Dark Knight","Christopher Nolan",new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart" },"When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovie() 
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id) {
            if (id < 0 || id >= movies.Count) { 
                return NotFound(new { message = "Movie tidak ditemukan"});
            }
            return Ok(movies[id]);
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie newMovie) {
            if (string.IsNullOrWhiteSpace(newMovie.Title) || string.IsNullOrWhiteSpace(newMovie.Director) || string.IsNullOrWhiteSpace(newMovie.Description)) { 
                return BadRequest(new { message = "Title, director, dan description harus diisi"});
            }

            movies.Add(newMovie);
            return Ok(new { message = "Data movie telah berhasil ditambahkan"});
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id) {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan" });
            }
            movies.RemoveAt(id);
            return Ok(new { message = "Movie berhasil dihapus"});
        }
    }
}
