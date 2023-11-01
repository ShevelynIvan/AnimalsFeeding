namespace AnimalsFeeding
{
    public class AnimalPlace
    {
        public event EventHandler<FoodFinishedEventArgs> FoodFinished;

        private int _volumeOfFood;

        /// <summary>
        /// Max possible volume of food in animal place. Sets in constructor.
        /// </summary>
        public readonly int MaxVolumeOfFood;

        /// <summary>
        /// Min possible volume of food in animal place. (Always equals to 0)
        /// </summary>
        public readonly int MinVolumeOfFood = 0;

        public string NameOfAnimal { get; set; }
        public string NameOfAnimalFood { get; set; }

        /// <summary>
        /// Curent volume of food in animal place.
        /// </summary>
        public int VolumeOfFood 
        { 
            get => _volumeOfFood;
            set
            {
                if (value > MaxVolumeOfFood)
                    _volumeOfFood = MaxVolumeOfFood;
                else if (value < MinVolumeOfFood)
                    _volumeOfFood = MinVolumeOfFood;
                else
                    _volumeOfFood = value;
            } 
        }

        public AnimalPlace(string name, string nameOfFood, int maxVolumeOfFood)
        {
            NameOfAnimal = name;
            NameOfAnimalFood = nameOfFood;
            MaxVolumeOfFood = maxVolumeOfFood;
            
        }

        /// <summary>
        /// Orders the animal to eat. Twice checks absent of food: before eating and after.
        /// If it is empty, invokes event FoodFinished.
        /// </summary>
        public void Eat()
        {
            CheckingForFoodAvailable();

            Console.WriteLine($"{NameOfAnimal} is eating...");
            VolumeOfFood -= new Random().Next(1,MaxVolumeOfFood);
            Console.WriteLine($"Done! {VolumeOfFood} food rest.");
            Console.WriteLine();

            CheckingForFoodAvailable();
        }

        /// <summary>
        /// Adds some food to animal
        /// </summary>
        /// <param name="amount">Amount of feed</param>
        public void Feed(int amount)
        {
            if(amount < 1)
            {
                Console.WriteLine("Error data!");
                return;
            }
            Console.WriteLine($"Volume of food before feeding = {VolumeOfFood}");
            Console.WriteLine("Pouring food..");
            VolumeOfFood += amount;
            Console.WriteLine($"Feeded! Volume of food = {VolumeOfFood}");
        }

        /// <summary>
        /// Invokes handler to FoodFinished event.
        /// </summary>
        /// <param name="e"></param>
        protected void OnFoodFinished(FoodFinishedEventArgs e)
        {
            EventHandler<FoodFinishedEventArgs> handler = FoodFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Helper method to check food for available. If volume of food equals to 0 invokes handler to FoodFinished.
        /// </summary>
        private void CheckingForFoodAvailable()
        {
            if (VolumeOfFood == 0)
            {
                FoodFinishedEventArgs e = new FoodFinishedEventArgs()
                {
                    NameOfAnimal = NameOfAnimal,
                    NameOfAnimalFood = NameOfAnimalFood,
                    AmountOfNeededFood = MaxVolumeOfFood - VolumeOfFood
                };
                OnFoodFinished(e);
            }
        }
    }
}
