namespace Recipe_App
{
    internal class Ingredient
    {
        private string name;
        private int quantity;
        private string unitOfMeasurement;

        public string Name 
        { 
            get { return name; } 
            set { name = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set { unitOfMeasurement = value; }
        }
    }
}
