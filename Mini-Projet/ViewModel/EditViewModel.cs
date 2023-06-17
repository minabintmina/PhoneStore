namespace Mini_Projet.ViewModel
{
    public class EditViewModel : CreateViewModel
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public  int ProduitId { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ExistingImagePath { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
