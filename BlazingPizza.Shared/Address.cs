namespace BlazingPizza;

public class Address
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Wie heißt du?"), MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Straßenname und Hausnummer werden benötigt."), MaxLength(100)]
    public string Straße { get; set; } = string.Empty;

    [Required(ErrorMessage = "Bitte nenne uns deine Stadt."), MaxLength(50)]
    public string Stadt { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string PLZ { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Anmerkung { get; set; } = string.Empty;
}
