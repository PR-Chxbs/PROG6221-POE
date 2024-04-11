namespace Recipe_App
{
    internal class Step
    {
        private static int stepNumberClass = 1;
        private int stepNumber;
        private string stepName;
        private string description;


        public Step()
        {
            stepNumber = stepNumberClass;
            stepName = $"Step {stepNumber}";
            stepNumberClass++;
        }

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
