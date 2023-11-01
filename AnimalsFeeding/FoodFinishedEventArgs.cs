namespace AnimalsFeeding
{
    public class FoodFinishedEventArgs : EventArgs
    {
        public string NameOfAnimal { get; set; }
        public string NameOfAnimalFood { get; set; }
        public int AmountOfNeededFood { get; set; }
    }
}