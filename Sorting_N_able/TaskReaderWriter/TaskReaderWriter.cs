using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorting_N_able.TaskReaderWriter
{
    public class TaskReaderWriter<T>
    {
        private List<T> _data;
        private int _writerCount;
        private int _readerCount;
        private bool isWriterWorking;

        public TaskReaderWriter()
        {
            _data = new List<T>();
            this._writerCount = 0;
            this._readerCount = 0;
            this.isWriterWorking = false;
        }

        public int Read(int index)
        {

            Monitor.Enter(_data);
            {
                while (_writerCount > 0 || isWriterWorking)
                    Monitor.Wait(_data);
                _readerCount++;
            }
            Monitor.Exit(_data);

            // thread read something
            Console.WriteLine("\tReader: " + index + " _readers:" + _readerCount + " _writers:" + _writerCount);

            Monitor.Enter(_data);
            {
                _readerCount--;
                if (_readerCount == 0)
                    Monitor.PulseAll(_data);
            }
            Monitor.Exit(_data);

            return index;
        }

        public void Write(int n)
        {
            try
            {
                Monitor.Enter(_data);
                {
                    while (_readerCount > 0 || isWriterWorking)
                        Monitor.Wait(_data);
                    _writerCount++;
                    isWriterWorking = true;
                }

                // thread write somthing
                Console.WriteLine("Writer: " + n + " _readers:" + _readerCount + " _writers:" + _writerCount);

            }
            finally
            {
                _writerCount--;
                isWriterWorking = false;
                Monitor.PulseAll(_data);
                Monitor.Exit(_data);
            }
        }

       
    }
}

