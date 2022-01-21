using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tetris.Model;

namespace Tetris.Persistence
{
    class DataAccess : Interface
    {
        public async Task SaveAsync(String path, Table table)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(table._size.x + " " + table._size.y + " ");
                    writer.Write(table._tick + " ");


                    await writer.WriteLineAsync();

                    for (Int32 i = 0; i < table._size.x; i++)
                    {
                        for (Int32 j = 0; j < table._size.y; j++)
                        {
                            await writer.WriteAsync(table.GetValue(i, j) + " ");
                        }
                        await writer.WriteLineAsync();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Table> LoadAsync(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String line = await reader.ReadLineAsync();
                    String[] numbers = line.Split(' ');
                    Pair tableSize = new Pair(int.Parse(numbers[0]), int.Parse(numbers[1]));
                    Table table = new Table(tableSize.x);
                    table._tick = int.Parse(numbers[2]);

                    for (int i = 0; i < tableSize.x; i++)
                    {
                        line = await reader.ReadLineAsync();
                        numbers = line.Split(' ');

                        for (int j = 0; j < tableSize.y; j++)
                        {
                            table._table[i, j] = int.Parse(numbers[j]);
                        }
                    }

                    return table;

                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}