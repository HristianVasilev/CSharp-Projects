using System;
using System.Collections;
using System.Collections.Generic;

namespace List.Models.Classes
{
    public class CList<T> : IList<T>

    {
        private T[] array;
        private int currentIndex;

        public CList()
        {
            this.array = new T[4];
            this.currentIndex = 0;
        }

        public T this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }

        public int Count => this.array.Length;

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Adds an object to the end of the List<T>.
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            ResizeArray();

            this.array[this.currentIndex] = item;
            this.currentIndex++;
        }


        /// <summary>
        /// Removes all elements from the List<T>.
        /// </summary>
        public void Clear()
        {
            this.array = new T[4];
            this.currentIndex = 0;
        }


        /// <summary>
        /// Determines whether an element is in the List<T>.
        /// </summary>
        /// <param name="item">The element</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                if (array[i].Equals( item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }



        private void ResizeArray()
        {
            if (this.currentIndex < this.array.Length)
            {
                return;
            }

            T[] newArray = new T[array.Length * 2];

            this.array.CopyTo(newArray, 0);
            this.array = newArray;
        }
    }
}
