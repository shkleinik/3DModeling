//-----------------------------------------------------------------------
// <copyright file="Serializator.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Windows.Forms;
    using Shapes;

    /// <summary>
    /// Privides tools to serialize and deserialize 3D Shape collection. Able to serialize collection of derived types.
    /// </summary>
    public static class Serializator
    {
        /// <summary>
        /// Collection of types derived from BaseShape.
        /// </summary>
        private static readonly List<Type> extraTypes = new List<Type> { typeof(Cone), typeof(Cube), typeof(Pyramid), typeof(CoordinateAxises) };

        /// <summary>
        /// Serialize collection of shapes.
        /// </summary>
        /// <param name="path">Specifies the path where collection will be serialized.</param>
        /// <param name="shapes">Collection of shapes to serialize.</param>
        public static void SerializeShapes(string path, List<BaseShape> shapes)
        {
            Stream writer = new FileStream(path, FileMode.Create);
            try
            {
                var serializer = new DataContractSerializer(typeof(List<BaseShape>), extraTypes.ToArray());
                serializer.WriteObject(writer, shapes);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Deserializes collection of shapes from well-formed xml file. If file does not exists returns null.
        /// </summary>
        /// <param name="path">Specifies path to serialized collection of 3D shapes.</param>
        /// <returns>Deserialized collection of 3d shapes or null, if specified file does not exist or was formed incorrect.</returns>
        public static List<BaseShape> DeserializeShapes(string path)
        {
            Stream reader = null;
            try
            {
                reader = new FileStream(path, FileMode.Open, FileAccess.Read);
                var serializer = new DataContractSerializer(typeof(List<BaseShape>), extraTypes.ToArray());
                return (List<BaseShape>)serializer.ReadObject(reader);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}