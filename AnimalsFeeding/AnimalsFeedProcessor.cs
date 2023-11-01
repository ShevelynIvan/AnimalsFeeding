namespace AnimalsFeeding
{
    public class AnimalsFeedProcessor
    {
        /// <summary>
        /// List of animal places
        /// </summary>
        private List<AnimalPlace> _animalPlaces;

        public AnimalsFeedProcessor() => _animalPlaces = new List<AnimalPlace>();

        /// <summary>
        /// Adds new animal place to list and subscribes to the FoodFinished event from AnimalPlace
        /// </summary>
        /// <param name="place"></param>
        public void AddNewAnimalPlace(AnimalPlace place)
        {
            if (place is null)
                return;
            
            _animalPlaces.Add(place);
            place.FoodFinished += AnimalFoodFinishedEventHandler;
        }

        /// <summary>
        /// Forces every animal to eat!!!
        /// </summary>
        public void FeedAll()
        {
            foreach (var animal in _animalPlaces)
            {
                animal.Eat();
            }
        }

        /// <summary>
        /// FoodFinished event handler 
        /// </summary>
        /// <param name="sender">sender (suggest to be AnimalPlace)</param>
        /// <param name="e">Arguments</param>
        private void AnimalFoodFinishedEventHandler(object? sender, FoodFinishedEventArgs e)
        {
            if (sender is AnimalPlace animal)
            {
                Console.WriteLine($"Adding {e.NameOfAnimalFood} for {e.NameOfAnimal}");
                animal.Feed(e.AmountOfNeededFood);
                Console.WriteLine();
            }
        }
    }
}
