namespace AnimalsFeeding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalsFeedProcessor animalsFeedProcessor = new AnimalsFeedProcessor();

            AnimalPlace dog = new AnimalPlace("Dog","Dog food");
            AnimalPlace cat = new AnimalPlace("Cat","Cat food");
            AnimalPlace horse = new AnimalPlace("Horse","Hay");
            AnimalPlace pig = new AnimalPlace("Pig","Carrot");

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