namespace WBXML
{
    public class StringTableItem
    {
        private readonly int index;
        private readonly string itemValue;

        public StringTableItem(int index, string itemValue)
        {
            this.index = index;
            this.itemValue = itemValue;
        }

        public int Index
        {
            get { return index; }
        }

        public string Value
        {
            get { return itemValue; }
        }
    }
}