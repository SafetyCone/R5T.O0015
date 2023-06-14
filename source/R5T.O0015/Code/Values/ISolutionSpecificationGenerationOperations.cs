using System;

using R5T.T0131;
using R5T.T0197;
using R5T.T0197.Extensions;
using R5T.T0204;
using R5T.T0207;


namespace R5T.O0015
{
    [ValuesMarker]
    public partial interface ISolutionSpecificationGenerationOperations : IValuesMarker
    {
        public WebBlazorClientAndServerSolutionSpecification Get_WebBlazorClientAndServerSolutionSpecification(
            IUnadjustedLibraryName unadjustedLibraryName,
            bool isPrivate)
        {
            var libraryName = unadjustedLibraryName.Value.ToLibraryName();

            var privacyAdjustedLibraryName = Instances.LibraryNameOperations.Adjust_LibraryNameForPrivacy(
                libraryName,
                isPrivate);

            var defaultSolutionName = Instances.LibraryNameOperator.Get_DefaultSolutionName(libraryName);

            // Get solution name.
            var solutionName = Instances.SolutionNameOperations.Adjust_SolutionNameForPrivacy(
                defaultSolutionName,
                isPrivate);

            var defaultProjectName = Instances.LibraryNameOperator.Get_DefaultProjectName(libraryName);

            // Get client project name.
            var clientProjectName = Instances.ProjectNameOperations.Get_ClientProjectName(defaultProjectName);

            // Get client project description.
            var clientProjectDescription = Instances.ProjectDescriptionOperations.Get_BlazorClientProjectDescription(defaultProjectName);

            // Get server project name.
            var serverProjectName = Instances.ProjectNameOperations.Get_ServerProjectName(defaultProjectName);

            // Get server project description.
            var serverProjectDescription = Instances.ProjectDescriptionOperations.Get_ServerForBlazorClientProjectDescription(defaultProjectName);

            var blazorClientProjectSpecification = new ProjectSpecification
            {
                ProjectName = clientProjectName,
                ProjectDescription = clientProjectDescription,
            };

            var serverProjectSpecification = new ProjectSpecification
            {
                ProjectName = serverProjectName,
                ProjectDescription = serverProjectDescription,
            };

            var output = new WebBlazorClientAndServerSolutionSpecification
            {
                SolutionName = solutionName,
                BlazorClientProjectSpecification = blazorClientProjectSpecification,
                ServerProjectSpecification = serverProjectSpecification,
            };

            return output;
        }
    }
}
