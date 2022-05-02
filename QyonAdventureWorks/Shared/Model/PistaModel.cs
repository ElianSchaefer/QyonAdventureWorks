using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Shared.Model
{
    public class PistaModel
    {
        public PistaModel(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public PistaModel()
        {

        }
    }
  
}
