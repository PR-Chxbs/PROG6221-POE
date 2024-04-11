namespace Recipe_App
{
    internal class Ingredient
    {
        private string name;
        private int quantity;
        private int originalQuantity;
        private string unitOfMeasurement;

        public void ResetQuantity()
        {
            quantity = originalQuantity;
        }
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

        public int OriginalQuantity
        {
            get { return originalQuantity; }
            set { originalQuantity = value; }
        }

        public string UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set { unitOfMeasurement = value; }
        }
    }
}
