using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0162;
using R5T.T0212.F000;
using R5T.T0215;
using R5T.T0218;


namespace R5T.F0141
{
    [FunctionalityMarker]
    public partial interface IDotnetPackOperator : IFunctionalityMarker
    {
        public async Task<IDictionary<IIdentityName, MemberDocumentation>> Get_MemberDocumentationsByIdentityName(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var documentationXmlFilePaths = Instances.DotnetPackPathOperator.Get_DocumentationXmlFilePaths(
                dotnetPackName,
                targetFrameworkMoniker);

            var documentationTarget = new DotnetFrameworkTarget()
            {
                TargetFrameworkMoniker = targetFrameworkMoniker,
            };

            var memberDocumentationsByIdentityName = await Instances.DocumentationFileOperator.Get_MemberDocumentationsByIdentityName(
                documentationXmlFilePaths,
                documentationTarget);

            return memberDocumentationsByIdentityName;
        }
    }
}
