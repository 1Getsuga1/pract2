using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMas
{
    public class MyArray
    {
        private readonly Random _random = new Random();
        private int[] _array;
        public int Length => _array.Length;

        public MyArray(int length)
        {
            _array = new int[length];
        }

        public void Export(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Length);

                for (int i = 0; i < Length; i++)
                {
                    writer.WriteLine(_array[i]);
                }
            }
        }

        public void Import(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                _array = new int[int.Parse(reader.ReadLine())];

                for (int i = 0; i < Length; i++)
                {
                    _array[i] = int.Parse(reader.ReadLine());
                }
            }
        }

        public void FillplusArray_Click(int minvalue = 1, int maxvalue = 10)
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _random.Next(minvalue, maxvalue);
            }
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _array.Length; i++)
            {
                res.Columns.Add("Col" + (i + 1));
            }
            var row = res.NewRow();
            for (int i = 0; i < Length; i++)
            {
                row[i] = _array[i];
            }
            res.Rows.Add(row);
            return res;
        }

        public void FillminusArray_Click(int minvalue = -10, int maxvalue = -1)
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _random.Next(minvalue, maxvalue);
            }
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public void Clear(int minvalue = 0, int maxvalue = 0)
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _random.Next(minvalue, maxvalue);
            }
        }
    }
}
