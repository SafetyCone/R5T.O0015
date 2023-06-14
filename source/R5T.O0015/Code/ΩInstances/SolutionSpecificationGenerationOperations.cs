using System;


namespace R5T.O0015
{
    public class SolutionSpecificationGenerationOperations : ISolutionSpecificationGenerationOperations
    {
        #region Infrastructure

        public static ISolutionSpecificationGenerationOperations Instance { get; } = new SolutionSpecificationGenerationOperations();


        private SolutionSpecificationGenerationOperations()
        {
        }

        #endregion
    }
}
