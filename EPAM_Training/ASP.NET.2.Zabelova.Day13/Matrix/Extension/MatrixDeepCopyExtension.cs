using System;
using System.IO;
using System.Xml.Serialization;
using Matrix.Matrices;

namespace Matrix.Extension
{
    /// <summary>
    ///     Provides extension for matrix deep copy
    /// </summary>
    public static class MatrixDeepCopyExtension
    {
        /// <summary>
        ///     Creates deep copy of an element
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="matrix"></param>
        /// <param name="item">item to copy</param>
        /// <returns>deep copy of the item</returns>
        public static T DeepClone<T>(this AbstractMatrix<T> matrix, T item)
        {
            Type theType = item.GetType();
            if (ReferenceEquals(theType.GetConstructor(Type.EmptyTypes), null)) 
                throw new ArgumentException("Type is not serializable");

            var ds = new XmlSerializer(typeof(T));
            var stream = new MemoryStream();
            ds.Serialize(stream, matrix);
            stream.Position = 0;
            return (T) ds.Deserialize(stream);
        }
    }
}