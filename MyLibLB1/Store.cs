namespace MyLibLB1
{
    public struct Item
    {
        public string name;
        public bool laid_out;
        public Item(string name, bool laid_out)
        {
            this.name = name;
            this.laid_out = laid_out;
        }
    }

    public class Store
    {
        List<Item> list_items;
        public Store()
        {
            list_items = new List<Item>();
        }

        public void AddItem(string name)
        {
            list_items.Add(new Item(name, false));
        }

        public void DeleteItem(String name)
        {
            list_items.Remove(list_items.Find(n => n.name == name));
        }

        public bool Exists(String name)
        {
            return list_items.Exists(n => n.name == name);
        }

        public int ClearStore()
        {
            for (int i = 0; i < list_items.Count; i++)
            {
                list_items[i] = new Item(list_items[i].name, false);
            }
            return list_items.Count;
        }

        public void PutItemOnCounter(String name)
        {
            Item item = list_items.Find(n => n.name == name);
            list_items[list_items.IndexOf(item)] = new Item(item.name, true);
        }

        public int CalculateCountOnCounter()
        {
            int result = 0;
            foreach (Item i in list_items)
            {
                if (i.laid_out) result++;
            }
            return result;
        }

        public int CalculateCountNotOnCounter()
        {
            int result = list_items.Count - CalculateCountOnCounter();
            return result;
        }

        public string GetListAsText()
        {
            string text = "";
            foreach (Item i in list_items)
            {
                string status = "не выложено";
                if (i.laid_out) status = "выложено";
                text += i.name + " " + status;
                if (list_items.Count != list_items.IndexOf(i)) text += ", ";
            }
            return text;
        }

        public List<Item> Items
        {
            get { return list_items; }
            set { list_items = value; }
        }
    }
}