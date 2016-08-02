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
        public int Count { get { return _container.Length; } }
        public T this[int index]
        {
            get { return _container[index]; }
            set { _container[index] = value; }
        }
        public CustomQueue(T[] array)
        {
            _container = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                Enqueue(array[i]);
        }
        public CustomQueue() { }
        public CustomQueueIterator<T> Iterator()
        {
            return new CustomQueueIterator<T>(this);
        }
        public CustomQueueIterator<T> GetEnumerator()
        {
            return new CustomQueueIterator<T>(this);
        }
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
    }
}

