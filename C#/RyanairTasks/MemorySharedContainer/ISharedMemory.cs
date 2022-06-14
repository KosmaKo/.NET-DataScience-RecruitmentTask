using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MemorySharedContainer
{
    public interface ISharedMemory
    {
        /// <summary>
        /// Adds items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        bool Add(IEnumerable<string> items);
        /// <summary>
        /// removes and returns items, preserves orders of added items
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Get();
    }
}