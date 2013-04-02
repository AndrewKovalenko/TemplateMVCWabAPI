using System.Web.Optimization;

namespace ProjectTemplate.Web.App_Start
{
    public static class LessBundleFactory
    {
        public static Bundle CreateLessBundle(string bundleName, params string[] files)
        {
            Bundle lessBundle = new StyleBundle(bundleName)
                .Include(files);
            lessBundle.Transforms.Add(new LessTransformation());
            lessBundle.Transforms.Add(new CssMinify());
            return lessBundle;
        }
    }
}