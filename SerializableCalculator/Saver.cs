using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace SerializableCalculator
{
        class Saver:IDisposable
        {
                 

                bool disposed = false;
                SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


                public void SaveToXml(ObservableCollection<Operation> collection, string path)
                {
                        if (collection.Count == 0) return;

                        XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Operation>));

                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                                xs.Serialize(fs, collection);
                        }
                }

                public void SaveToText(ObservableCollection<Operation> collection, string path)
                {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                                foreach (Operation op in collection)
                                {
                                        sw.WriteLine(op.ToString());
                                }
                        }
                }

                public void Dispose()
                {
                        Dispose(true);
                        GC.SuppressFinalize(this);
                }

                protected virtual void Dispose(bool disposing)
                {
                        if (disposed) return;

                        if (disposing)
                        {
                                handle.Dispose();
                        }

                        disposed = true;

                }
        }
}
