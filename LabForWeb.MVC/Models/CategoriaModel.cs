namespace LabForWeb.MVC.Models;

// Classi POCO => Plain Old C# Object cioè non hanno metodi ma solo proprietà, descrivono un oggetto un modello
public class CategoriaModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Slug { get; set; }
}
