namespace AnimalsFeeding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalsFeedProcessor animalsFeedProcessor = new AnimalsFeedProcessor();

            AnimalPlace dog = new AnimalPlace("Dog","Dog food", 30);
            AnimalPlace cat = new AnimalPlace("Cat","Cat food", 20);
            AnimalPlace horse = new AnimalPlace("Horse","Hay", 200);
            AnimalPlace pig = new AnimalPlace("Pig","Carrot", 100);

            animalsFeedProcessor.AddNewAnimalPlace(dog);
            animalsFeedProcessor.AddNewAnimalPlace(cat);
            animalsFeedProcessor.AddNewAnimalPlace(horse);
            animalsFeedProcessor.AddNewAnimalPlace(pig);

            while (true)
            {
                animalsFeedProcessor.FeedAll();
                Thread.Sleep(13000);
            }
        }
    }
}