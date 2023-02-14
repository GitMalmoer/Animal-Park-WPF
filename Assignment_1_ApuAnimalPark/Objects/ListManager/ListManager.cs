using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Assignment_2_ApuAnimalPark.Objects.ListManager
{
    public class ListManager<T> : IListManager<T>
    {
        private List<T> _list;

        public ListManager()
        {
            _list = new List<T>();
        }

        public int Count => _list.Count;

        public bool Add(T type)
        {
            if (type == null) return false;
            _list.Add(type);
            return true;

        }

        public bool ChangeAt(T type, int index)
        {
            bool changed = false;

            if (CheckIndex(index))
            {
                try
                {
                    _list.RemoveAt(index);
                    _list.Insert(index, type);
                    changed = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    changed = false;
                }
            }

            return changed;
        }

        public bool CheckIndex(int index)
        {
            if (index < 0) return false;
            return true;
        }

        public void DeleteAll()
        {
            _list.Clear();
        }

        public bool DeleteAt(int index)
        {
            if (CheckIndex(index))
            {
                _list.RemoveAt(index);
                return true;
            }
            return false;
        }

        public T GetAt(int index)
        {
            if (CheckIndex(index))
            {
                if (_list[index] != null)
                {
                    return _list[index];
                }
            }

            return default(T);
        }

        public string[] ToStringArray()
        {
            string[] stringArray = new string[_list.Count];

            for (int i = 0; i < _list.Count; i++)
            {
                stringArray[i] = _list[i].ToString();
            }
            return stringArray;
        }

        public List<string> ToStringList()
        {
            List<string> stringList = new List<string>();

            foreach (var item in _list)
            {
                stringList.Add(item.ToString());
            }
            return stringList;
        }
    }
}
