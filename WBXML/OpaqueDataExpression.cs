namespace WBXML
{
    public class OpaqueDataExpression
    {
        public OpaqueDataExpression(string name, string expression)
        {
            TagName = name;
            Expression = expression;
        }

        public string TagName { get; set; }

        public string Expression { get; set; }
    }
}