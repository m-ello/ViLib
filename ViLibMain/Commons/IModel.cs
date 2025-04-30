using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IModel
    {
        bool Add(Book book);
        int BookCount
        {
            get;
        }
        bool DataExists();
        bool Delete(string title);
        bool Exists(string title);
        void InitializeData();
        string ListAll();
        bool SaveData();
        Book Search(string title);
    }

}
