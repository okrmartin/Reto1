using System.Collections.Generic;

namespace reto1.Bl
{

    /// <summary>
    /// This class is useful to iterate in a list
    /// </summary>
    public class Iterator
    {
        private IList<InputClass> _list;
        private int _current;


        /// <summary>
        /// Initializes a new instance of the <see cref="Iterator"/> class.
        /// </summary>
        /// <param name="list">The list to iterate.</param>
        public Iterator(IList<InputClass> list)
        {
            this._list = list;
            this._current = 0;
        }


        /// <summary>
        /// Returns the next element in the iteration.
        /// </summary>
        /// <returns>The next element in the iteration</returns>
        public InputClass Next()
        {
            var retObj = new InputClass { Codigo = 0 };

            if (this._current < this._list.Count)
            {
                retObj = this._list[this._current];
                this._current++;
            }
            return retObj;
        }
    }
}
