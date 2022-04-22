﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class AsyncIEnumerableExtensions
    {
        /// <summary>
        /// Projects each element of an async-enumerable sequence into a new form by applying
        /// an asynchronous selector function to each member of the source sequence and awaiting
        /// the result.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements in the source sequence</typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements in the result sequence, obtained by running the selector
        /// function for each element in the source sequence and awaiting the result.
        /// </typeparam>
        /// <param name="source">A sequence of elements to invoke a transform function on</param>
        /// <param name="predicate">An asynchronous transform function to apply to each source element</param>
        /// <returns>
        /// An async-enumerable sequence whose elements are the result of invoking the transform
        /// function on each element of the source sequence and awaiting the result
        /// </returns>
        public static IAsyncEnumerable<TResult> SelectAwait<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, ValueTask<TResult>> predicate)
        {            
            return source.ToAsyncEnumerable().SelectAwait(predicate); 
        }

        /// <summary>
        /// Creates a list from an async-enumerable sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence</typeparam>
        /// <param name="source">The source async-enumerable sequence to get a list of elements for</param>
        /// <returns>
        /// An async-enumerable sequence containing a single element with a list containing
        /// all the elements of the source sequence
        /// </returns>
        /// <returns>A task that represents the asynchronous operation</returns>
        
        public static Task<List<TSource>> ToListAsync<TSource>(this IEnumerable<TSource>  source)
        {
            return source.ToAsyncEnumerable().ToListAsync().AsTask();
        }
    }
}
