using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhasFinancas.Models;

namespace MinhasFinancas.DAL
{
   public interface IFinancasDAL
    {
        IEnumerable<RelatorioDespesa> GetAllDespesas();
        IEnumerable<RelatorioDespesa> VisualizarCSV();
        IEnumerable<RelatorioDespesa> VisualizarPDF();
        IEnumerable<RelatorioDespesa> GetFiltraDespesa(string criterio);
        void AddDespesa(RelatorioDespesa despesa);
        int UpdateDespesa(RelatorioDespesa despesa);
        RelatorioDespesa GetDespesa(int id);
        void DeleteDespesa(int id);       
        Dictionary<string, decimal> CalculaDespesaPeriodo(int Periodo);
        Dictionary<string, decimal> CalculaDespesaPeriodoSemanal(int periodo);
    }
}
