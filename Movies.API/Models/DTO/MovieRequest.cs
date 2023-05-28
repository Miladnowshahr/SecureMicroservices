namespace Movies.API.Models.DTO;

public class MovieRequest
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Owner { get; set; }
}