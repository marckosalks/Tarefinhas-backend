namespace Tarefinhas.Models;

public class TarefinhasModel
{
    public TarefinhasModel(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
    }

    //criador unico de id
    public Guid Id { get; init; }
    public string Title { get; private set; } = String.Empty;
    public string Description { get; private set; } = String.Empty;

    public void ChangeTitleorDescription(string newTitle, string newDescription)
    {
      Title = newTitle;
      Description = newDescription;
    }

}