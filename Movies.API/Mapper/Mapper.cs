using Movies.API.Models;
using Movies.API.Models.DTO;

public static class Mapper
{
    public static Movie ToModel(this MovieRequest request)
    {
        return new Movie()
        {
            Genre= request.Genre,
            Owner= request.Owner,
            ReleaseDate= request.ReleaseDate,
            Title= request.Title,
        };
    }
}