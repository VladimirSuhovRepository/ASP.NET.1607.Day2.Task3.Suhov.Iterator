using ASP.NET._1607.Day2.Task3.Suhov.Iterator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day2.Task3.Suhov.Iterator
{
    public class CustomQueue<T>
    {
        #region Private Fields
        private T[] _container;
        private int _head;       // First valid element in the queue 
        private int _tail;       // Last valid element in the queue
        private int _size;
        #endregion
        /// <summary>
        /// Default constructor without parameters
        /// </summary>
        public CustomQueue() { }
        /// <summary>
        /// Constructor with parameter array
        /// </summary>
        public CustomQueue(T[] array)
        {
            _container = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                Enqueue(array[i]);
        }
        /// <summary>
        /// Returns the number of elements in queue
        /// </summary>
        public int Count { get { return _container.Length; } }
        /// <summary>
        /// Indexer to go throw queue
        /// </summary>
        public T this[int index]
        {
            get { return _container[index]; }
            set { _container[index] = value; }
        }
        /// <summary>
        /// Iterator returns the instance of iterator class
        /// </summary>
        public CustomQueueIterator<T> Iterator()
        {
            return new CustomQueueIterator<T>(this);
        }
        /// <summary>
        /// Enumerator returns the instance of iterator class
        /// </summary>
        public CustomQueueIterator<T> GetEnumerator()
        {
            return new CustomQueueIterator<T>(this);
        }
        /// <summary>
        /// Adds item to the tail of the queue
        /// </summary>
        public void Enqueue(T item)
        {
            if (_size == _container.Length)
            {
                int newcapacity = _size + 1;
                SetCapacity(newcapacity);
            }
            _container[_tail] = item;
            _tail = (_tail + 1) % _container.Length;
            _size++;
        }
        /// <summary>
        /// Removes the object at the head of the queue and returns it
        /// </summary>
        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            T removed = _container[_head];
            _container[_head] = default(T);
            _head = (_head + 1) % _container.Length;
            _size--;
            return removed;
        }
        /// <summary>
        /// Returns the object at the head of the queue
        /// </summary
        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            return _container[_head];
        }
        #region Private Methods
        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_container, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_container, _head, newarray, 0, _container.Length - _head);
                    Array.Copy(_container, 0, newarray, _container.Length - _head, _tail);
                }
            }
            _container = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
        }
        #endregion

        #region Internal Class
        public class CustomQueueIterator<T>
        {
            #region Private Fields
            private readonly CustomQueue<T> _collection;
            private int _currentIndex;
            #endregion
            /// <summary>
            /// Default constructor without parameters
            /// </summary
            public CustomQueueIterator() { }
            /// <summary>
            /// Constructor with parameter
            /// </summary
            public CustomQueueIterator(CustomQueue<T> collection)
            {
                _currentIndex = -1;
                _collection = collection;
            }
            /// <summary>
            /// Returns the current item from collection
            /// </summary>
            public T Current
            {
                get
                {
                    if (_currentIndex == -1 || _currentIndex == _collection.Count || _collection[_currentIndex] == null || _currentIndex >= _collection.Count)
                        throw new ArgumentOutOfRangeException("index", _currentIndex, "The index is out of range"); ;
                    return _collection[_currentIndex];
                }
            }
            /// <summary>
            /// Set the index to default value
            /// </summary>
            public void Reset()
            {
                _currentIndex = -1;
            }
            /// <summary>
            /// Return true if there are more items to iterate
            /// </summary>
            public bool MoveNext()
            {
                return ++_currentIndex < _collection.Count;
            }
        }
        #endregion
    }
}

