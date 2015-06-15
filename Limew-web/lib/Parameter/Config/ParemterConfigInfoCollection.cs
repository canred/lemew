using System;
using System.Collections;

namespace Limew.Parameter.Config
{
    [Serializable]
    public class ParemterConfigInfoCollection : CollectionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> class.
        /// </summary>
        public ParemterConfigInfoCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> class containing the elements of the specified source collection.
        /// </summary>
        /// <param name="value">A <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> with which to initialize the collection.</param>
        public ParemterConfigInfoCollection(ParemterConfigInfoCollection value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> class containing the specified array of <see cref="ParemterConfigInfo">ParemterConfigInfo</see> Components.
        /// </summary>
        /// <param name="value">An array of <see cref="ParemterConfigInfo">ParemterConfigInfo</see> Components with which to initialize the collection. </param>
        public ParemterConfigInfoCollection(ParemterConfigInfo[] value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Gets the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> at the specified index in the collection.
        /// <para>
        /// In C#, this property is the indexer for the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> class.
        /// </para>
        /// </summary>
        public ParemterConfigInfo this[int index]
        {
            get { return ((ParemterConfigInfo)(List[index])); }
        }

        public int Add(ParemterConfigInfo value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Copies the elements of the specified <see cref="ParemterConfigInfo">ParemterConfigInfo</see> array to the end of the collection.
        /// </summary>
        /// <param name="value">An array of type <see cref="ParemterConfigInfo">ParemterConfigInfo</see> containing the Components to add to the collection.</param>
        public void AddRange(ParemterConfigInfo[] value)
        {
            for (int i = 0; (i < value.Length); i = (i + 1))
            {
                Add(value[i]);
            }
        }

        /// <summary>
        /// Adds the contents of another <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> to the end of the collection.
        /// </summary>
        /// <param name="value">A <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> containing the Components to add to the collection. </param>
        public void AddRange(ParemterConfigInfoCollection value)
        {
            for (int i = 0; (i < value.Count); i = (i + 1))
            {
                Add((ParemterConfigInfo)value.List[i]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection contains the specified <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see>.
        /// </summary>
        /// <param name="value">The <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> to search for in the collection.</param>
        /// <returns><b>true</b> if the collection contains the specified object; otherwise, <b>false</b>.</returns>
        public bool Contains(ParemterConfigInfo value)
        {
            return List.Contains(value);
        }

        /// <summary>
        /// Copies the collection Components to a one-dimensional <see cref="T:System.Array">Array</see> instance beginning at the specified index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array">Array</see> that is the destination of the values copied from the collection.</param>
        /// <param name="index">The index of the array at which to begin inserting.</param>
        public void CopyTo(ParemterConfigInfo[] array, int index)
        {
            List.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the index in the collection of the specified <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see>, if it exists in the collection.
        /// </summary>
        /// <param name="value">The <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> to locate in the collection.</param>
        /// <returns>The index in the collection of the specified object, if found; otherwise, -1.</returns>
        public int IndexOf(ParemterConfigInfo value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, ParemterConfigInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(ParemterConfigInfo value)
        {
            List.Remove(value);
        }

        /// <summary>
        /// Returns an enumerator that can iterate through the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> instance.
        /// </summary>
        /// <returns>An <see cref="BaseConfigInfoCollectionEnumerator">BaseConfigInfoCollectionEnumerator</see> for the <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> instance.</returns>
        public new ParemterConfigInfoCollectionEnumerator GetEnumerator()
        {
            return new ParemterConfigInfoCollectionEnumerator(this);
        }

        #region Nested type: ParemterConfigInfoCollectionEnumerator

        /// <summary>
        /// Supports a simple iteration over a <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see>.
        /// </summary>
        public class ParemterConfigInfoCollectionEnumerator : IEnumerator
        {
            private readonly IEnumerator _enumerator;
            private readonly IEnumerable _temp;

            /// <summary>
            /// Initializes a new instance of the <see cref="BaseConfigInfoCollectionEnumerator">BaseConfigInfoCollectionEnumerator</see> class referencing the specified <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> object.
            /// </summary>
            /// <param name="mappings">The <see cref="ParemterConfigInfoCollection">ParemterConfigInfoCollection</see> to enumerate.</param>
            public ParemterConfigInfoCollectionEnumerator(ParemterConfigInfoCollection mappings)
            {
                _temp = ((mappings));
                _enumerator = _temp.GetEnumerator();
            }

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            public ParemterConfigInfo Current
            {
                get { return ((ParemterConfigInfo)(_enumerator.Current)); }
            }

            #region IEnumerator Members

            object IEnumerator.Current
            {
                get { return _enumerator.Current; }
            }

            bool IEnumerator.MoveNext()
            {
                return _enumerator.MoveNext();
            }

            void IEnumerator.Reset()
            {
                _enumerator.Reset();
            }

            #endregion

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns><b>true</b> if the enumerator was successfully advanced to the next element; <b>false</b> if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                _enumerator.Reset();
            }
        }

        #endregion
    }
}