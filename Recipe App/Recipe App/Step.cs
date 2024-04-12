namespace Recipe_App
{
    internal class Step
    {
        private int stepNumber;
        private string stepName;
        private string description;

        // Method that runs upon instance creation
        public Step(int number)
        {
            stepNumber = number;
            stepName = $"Step {stepNumber}";
        }

        // Setter and getter methods for private attributes
        public int StepNumber
        {
            get { return stepNumber; }
            set { stepNumber = value; }
        }

        public string StepName
        {
            get { return stepName; }
            set { stepName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
