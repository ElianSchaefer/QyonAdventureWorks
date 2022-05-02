using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Shared.Model
{
    public class CompetidorModel
    {
        public CompetidorModel(string nome, char sexo, decimal temperaturaCorporal, decimal peso, decimal altura)
        {
            
            Nome = nome ?? throw new Exception("Nome não pode ser em branco");
            Sexo = sexo;
            TemperaturaCorporal = temperaturaCorporal;
            Peso = peso < 0 ? throw new Exception("Peso não pode ser Negativo!") : peso;
            Altura = altura < 0 ? throw new Exception("Altura não pode ser Negativa!") : altura;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public decimal TemperaturaCorporal { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }

        public CompetidorModel()
        {
        }
    }
}
