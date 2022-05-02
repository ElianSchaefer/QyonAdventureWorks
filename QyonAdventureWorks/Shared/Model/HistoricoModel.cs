using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Shared.Model
{
    public class HistoricoModel
    {
        public HistoricoModel(int id, int competidorId, int pistaId, DateTime dataCorrida, decimal tempoGasto)
        {
            Id = id;
            CompetidorId = competidorId;
            PistaId = pistaId;
            DataCorrida = dataCorrida;
            TempoGasto = tempoGasto;
        }

        public int Id { get; set; }
        public int CompetidorId { get; set; }
        public int PistaId { get; set; }
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }

        public HistoricoModel()
        {

        }

    }
  
}
