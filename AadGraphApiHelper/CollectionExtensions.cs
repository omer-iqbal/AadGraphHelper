 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AadGraphApiHelper
{
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Casts down each item in the provided enumerable to create a collection that is strongly typed.
        /// </summary>
        /// <param name="enumerable">The enumeration to convert.</param>
        /// <param name="convertedObject">An enumeration that has items converted to one of the supported types.</param>
        /// <returns>true if the conversion succeeded, false otherwise.</returns>
        /// <remarks>
        ///   <para>There are cases when a enuerable of typed objects is contains in a non-generic enumerable or an enumerable of objects. For
        ///         example, a collection of strings { "a", "b" } may be available as an <see cref="IEnumerable"/> or <see cref="IEnumerable{Object}"/>.
        ///         This method iterates through every item in the collection and attempts to cast it down to the type of the items if possible.
        ///         Thus, { "a", "b" } will be created as a <see cref="Collection{String}"/> and returned. If all items are not of the same
        ///         type, then the conversion is not performed and the method returns false.</para>
        /// </remarks>
        public static bool TryConvertToTypedCollection(this IEnumerable enumerable, out ICollection convertedObject)
        {
            if (enumerable == null)
            {
                convertedObject = null;
                return false;
            }

            ICollection objectCollection = (ICollection) enumerable as Collection<object> ??
                                           (ICollection) enumerable.Cast<object>().ToList();

            if (objectCollection.Count == 0)
            {
                convertedObject = objectCollection;
                return true;
            }

            Type firstItemType = null;
            IList typedCollection = null;

            foreach (object item in objectCollection)
            {
                try
                {
                    if (firstItemType == null)
                    {
                        // Create a list of the type of the first item
                        firstItemType = item.GetType();
                        Type genericType = typeof(List<>).MakeGenericType(new[] {firstItemType});
                        typedCollection = (IList) Activator.CreateInstance(genericType);
                    }
                    else if (item.GetType() != firstItemType)
                    {
                        // Essentially we're dealing with a collection that has items with different types, e.g. { "name", 2, true }.
                        // Instead of casting this out to object type, we just do not cast since the purpose of the method is to cast down.
                        convertedObject = null;
                        return false;
                    }

                    typedCollection.Add(Convert.ChangeType(item, firstItemType));
                }
                catch (InvalidCastException)
                {
                    convertedObject = null;
                    return false;
                }
            }

            convertedObject = typedCollection;
            return true;
        }
    }
}
