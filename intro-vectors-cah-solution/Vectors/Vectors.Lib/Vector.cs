﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Vectors.Lib
{
    /// <summary>
    /// The Vector class, to contain the items in a vector 
    /// </summary>
    /// <typeparam name="T">The type of the vector data, expected to be numeric </typeparam>
    /// n.b. we might like to limit ourselves to numeric types, but this is not easily done: 
    /// https://stackoverflow.com/questions/32664/is-there-a-constraint-that-restricts-my-generic-method-to-numeric-types/4834066#4834066 
    public class Vector<T>
        : IEquatable<Vector<T>>,    // this means we can compare two vectors for equality  
          IEnumerable<T>            // we can iterate over the vector's contents 
        where T : IEquatable<T>     // that the underlying type is itself equatable 
    {
        // the collection cannot be 
        readonly IList<T> _collection;

        public int Size => _collection.Count;

        public Vector()
        {
            _collection = new List<T>();
        }

        public Vector(IEnumerable<T> list) : this()
        {
            foreach (T item in list)
            {
                _collection.Add(item);
            }
        }

        public bool Equals(Vector<T> other)
        {
            if (Size != other.Size)
                return false;
            for (int i = 0; i < Size; ++i)
                if (!_collection[i].Equals(other._collection[i]))
                    return false;
            return true;
        }

        public Vector<T> Add(Vector<T> v2)
        {
            IList<T> res = new List<T>();
            for (int i = 0; i < Size; ++i)
            {
                // super ugly hack because you can't use the + symbol with generic types  
                dynamic value1 = _collection[i];
                dynamic value2 = v2._collection[i];
                T value = value1 + value2;
                res.Add(value);
            }
            // create a new Vector from the list 
            return new Vector<T>(res);
        }

        public void ScaleInPlace(T scalar)
        {
            for(int i = 0; i < Size; ++i)
            {
                dynamic value = _collection[i]; 
                T valueT = value * scalar;
                _collection[i] = valueT;

            }
        }
        public Vector<T> ScaleNew(T scalar)
        {
            IList<T> res = new List<T>();
            for (int i = 0; i < Size; ++i)
            {
                dynamic value = _collection[i];
                T valueT = value * scalar;
                res.Add(valueT);
            }
            return new Vector<T>(res);
        }

        public Vector<T> Multiplication(Vector<T> v2)
        {
            IList M = new List<T>();
            for (int i = 0; i < Size; ++i)
            {
                dynamic Value1 = _collection[i];
                dynamic Value2 = v2._collection[i];
                T Value = Value1 * Value2;
                M.Add(Value)
            }
            return new Vector<T>(M);
        }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _collection)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}