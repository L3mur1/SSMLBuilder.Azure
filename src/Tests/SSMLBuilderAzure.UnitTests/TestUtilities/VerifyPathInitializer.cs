using System.Runtime.CompilerServices;

namespace SSMLBuilderAzure.UnitTests.TestUtilities
{
    public static class VerifyPathInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            DerivePathInfo(
                (sourceFile, projectDirectory, type, method) => new PathInfo(
                    directory: Path.Combine(projectDirectory, "verify_files"),
                    typeName: type.Name,
                    methodName: method.Name));
        }
    }
}