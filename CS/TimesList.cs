using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace just_try
{
    public class TimesList
    {
        private List<TimeItem> items = new List<TimeItem>();

        public void Add(TimeItem item)
        {
            items.Add(item);
        }

        public void Save(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, items);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка в сериализации! {e.StackTrace}");
                Console.WriteLine(e.Message);
            }
        }

        public void Load(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    items = formatter.Deserialize(fs) as List<TimeItem>;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка в десериализации! {e.StackTrace}");
                Console.WriteLine(e.Message);
            }
        }

        #region override
        public override string ToString()
        {
            StringBuilder myString = new StringBuilder();
            foreach (var item in items)
                myString.Append(item);

            return myString.ToString();
        }
        #endregion
    }
}