using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Persistence
{
    public interface Interface
    {
        Task<Table> LoadAsync(String path);
        Task SaveAsync(String path, Table table);
    }
}
