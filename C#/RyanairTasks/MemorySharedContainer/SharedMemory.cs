using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MemorySharedContainer
{
    public class SharedMemory : ISharedMemory
    {
        const int MMF_MAX_SIZE = 1024;  // allocated memory for each memory mapped file (bytes)
        const int MMF_VIEW_SIZE = 1024; //bytes of the allocated memory that process can access
 public bool Add(IEnumerable<string> items)
        {

                var mmf = MemoryMappedFile.CreateOrOpen("sharedMemory", MMF_MAX_SIZE, MemoryMappedFileAccess.ReadWrite);
                var accessor = mmf.CreateViewAccessor(MMF_MAX_SIZE, MMF_VIEW_SIZE);
                lock (accessor)
                {
                    for (int i = 0; i < items.Count(); i++)
                    {
                        byte[] buffer = ASCIIEncoding.ASCII.GetBytes(items.ElementAt(i));
                        //write the length of the string
                        accessor.Write((i * 64), (ushort) buffer.Length);
                        //write the string
                        accessor.WriteArray((i * 64) + 2, buffer, 0, buffer.Length);
                    }
                }

                return true;
        }

        public IEnumerable<string> Get()
        {
            List<string> mappedItems = new List<string>();
            var mmf = MemoryMappedFile.CreateOrOpen("sharedMemory", MMF_MAX_SIZE, MemoryMappedFileAccess.ReadWrite);
            var accessor = mmf.CreateViewAccessor();

            lock (accessor)
            {
                ushort size = 0;
                int i = 0;
                do
                {
                    size = accessor.ReadUInt16(i * 64);
                    byte[] buffer = new byte[size];
                    accessor.ReadArray((i * 64) + 2, buffer, 0, buffer.Length);
                    mappedItems.Add(ASCIIEncoding.ASCII.GetString(buffer));
                    i++;
                } while (accessor.CanRead && size != 0);

                accessor.Dispose();
            }

            return mappedItems;
        }
    }
}