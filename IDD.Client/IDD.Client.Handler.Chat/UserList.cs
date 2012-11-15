using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Handler.Chat
{
    public class UserList : IUserList
    {
        private List<User> _usrList = new List<User>();
        public int IndexOf(User item)
        {
            return _usrList.IndexOf(item);
        }

        public void Insert(int index, User item)
        {
            _usrList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _usrList.RemoveAt(index);
        }

        public User this[int index]
        {
            get
            {
                return _usrList[index];
            }
            set
            {
                _usrList[index] = value;
            }
        }

        public void Add(User item)
        {
            _usrList.Add(item);
        }

        public void Clear()
        {
            _usrList.Clear();
        }

        public bool Contains(User item)
        {
            return _usrList.Contains(item);
        }

        public void CopyTo(User[] array, int arrayIndex)
        {
            _usrList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _usrList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(User item)
        {
            return _usrList.Remove(item);
        }

        public IEnumerator<User> GetEnumerator()
        {
           return  _usrList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _usrList.GetEnumerator();
        }
    }
}
