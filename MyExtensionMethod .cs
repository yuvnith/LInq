namespace LINQ
{
    public static class MyExtensionMethod 
    {
        public static string MyExtensionMeth(this string name)
        {
            return name.ToUpper();
        }
    }
}