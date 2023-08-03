﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Unified.Services.Code
{
    /// <summary>
    /// 实现XML序列化与反序列化的包装工具类
    /// </summary>
    public static class XmlHelper
    {

        private static void XmlSerializeInternal(Stream stream, object o, Encoding encoding)
        {
            if (o == null)
                throw new ArgumentNullException("o");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            XmlSerializer serializer = new XmlSerializer(o.GetType());

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineChars = "\r\n",
                Encoding = encoding,
                IndentChars = "    "
            };
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, o, ns);
            }
        }


        /// <summary>
        /// 将一个对象序列化为XML字符串
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>序列化产生的XML字符串</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202")]
        public static string XmlSerialize(object o, Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream())
            {

                XmlSerializeInternal(stream, o, encoding);

                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        /// <summary>
        /// 将一个对象按XML序列化的方式写入到一个文件
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="encoding">编码方式</param>
        public static void XmlSerializeToFile(object o, string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializeInternal(file, o, encoding);
            }
        }


        /// <summary>
        /// 从XML字符串流中反序列化对象
        /// </summary>
        /// <param name="stream">包含对象的XML字符串流</param>
        /// <param name="destType">要序列化的目标类型</param>
        /// <returns>反序列化得到的对象</returns>
        public static object XmlDeserialize(Stream stream, Type destType)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (destType == null)
                throw new ArgumentNullException("destType");

            XmlSerializer mySerializer = new XmlSerializer(destType);

            using (StreamReader sr = new StreamReader(stream))
            {
                return mySerializer.Deserialize(sr);
            }
        }

        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="destType">要序列化的目标类型</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static object XmlDeserialize(string s, Type destType, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");
            if (destType == null)
                throw new ArgumentNullException("destType");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
            {
                return XmlDeserialize(ms, destType);
            }
        }


        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s)
        {
            return (T)XmlDeserialize(s, typeof(T), Encoding.UTF8);
        }



        /// <summary>
        /// 读入一个文件，并按XML的方式反序列化对象。
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="path">文件路径</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserializeFromFile<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    return (T)XmlDeserialize(fs, typeof(T));
                }
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("XML反序列失败，当前文件：" + path, ex);
            }
        }

        /// <summary>
        /// 去除xml声明标签
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ObjectToXmlSerializer(Object Obj, Encoding encoding)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineChars = "\r\n",
                Encoding = encoding,
                IndentChars = "    ",
                OmitXmlDeclaration = true
            };
            System.IO.MemoryStream mem = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(mem, settings))
            {
                //去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer formatter = new XmlSerializer(Obj.GetType());
                formatter.Serialize(writer, Obj, ns);
            }
            return encoding.GetString(mem.ToArray());

        }
        /// <summary>
        /// 暂时解决q1:序列化的问题
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string RootToXmlSerializer(Object Obj, Encoding encoding)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineChars = "\r\n",
                Encoding = encoding,
                IndentChars = "    ",
                //OmitXmlDeclaration = true
            };
            System.IO.MemoryStream mem = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(mem, settings))
            {
                //去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "http://www.chinapop.gov.cn/dataspec");
                XmlSerializer formatter = new XmlSerializer(Obj.GetType());
                formatter.Serialize(writer, Obj, ns);
            }
            return encoding.GetString(mem.ToArray());

        }
    }
}
