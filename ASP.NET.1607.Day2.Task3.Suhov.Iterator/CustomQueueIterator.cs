using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day2.Task3.Suhov.Iterator
{
    public class CustomQueueIterator<T>
    {
        private readonly CustomQueue<T> _collection;
        private int _currentIndex;
        public CustomQueueIterator(CustomQueue<T> collection)
        {
            _currentIndex = -1;
            _collection = GetCollection(collection);
        }
        public T Current
        {
            get
            {
                if (_currentIndex == -1 || _currentIndex == _collection.Count|| _collection[_currentIndex]==null|| _currentIndex>=_collection.Count)
                    throw new ArgumentOutOfRangeException("index", _currentIndex, "The index is out of range"); ;
                return _collection[_currentIndex];
            }
        }
        public void Reset()
        {
            _currentIndex = -1;
        }
        public bool MoveNext()
        {
            return ++_currentIndex < _collection.Count;
        }
        #region Private Methods
        private CustomQueue<T> GetCollection(CustomQueue<T> collection)
        {
            CustomQueue<T> result = new CustomQueue<T>();
            result = collection;
            return result;
        }
        #endregion
    }
}
