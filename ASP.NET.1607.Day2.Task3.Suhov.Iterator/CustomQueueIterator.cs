using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day2.Task3.Suhov.Iterator
{
    public class CustomQueueIterator<T>
    {
        #region Private Fields
        private readonly CustomQueue<T> _collection;
        private int _currentIndex;
        #endregion
        /// <summary>
        /// Default constructor without parameters
        /// </summary
        public CustomQueueIterator(){ }
        /// <summary>
        /// Constructor with parameter
        /// </summary
        public CustomQueueIterator(CustomQueue<T> collection)
        {
            _currentIndex = -1;
            _collection = GetCollection(collection);
        }
        /// <summary>
        /// Returns the current item from collection
        /// </summary
        public T Current
        {
            get
            {
                if (_currentIndex == -1 || _currentIndex == _collection.Count|| _collection[_currentIndex]==null|| _currentIndex>=_collection.Count)
                    throw new ArgumentOutOfRangeException("index", _currentIndex, "The index is out of range"); ;
                return _collection[_currentIndex];
            }
        }
        /// <summary>
        /// Set the index to default value
        /// </summary
        public void Reset()
        {
            _currentIndex = -1;
        }
        /// <summary>
        /// Return true if there are more items to iterate
        /// </summary
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
