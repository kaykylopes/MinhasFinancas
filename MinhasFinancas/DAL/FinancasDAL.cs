using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Models;

namespace MinhasFinancas.DAL
{
    public class FinancasDAL:IFinancasDAL
    {
        public FinancasDAL() { }
        private readonly AppDbContext db;
        public FinancasDAL(AppDbContext context)
        {
            db = context;
        }

        
         public IEnumerable<RelatorioDespesa> VisualizarCSV()
        {
            try
            {
                return db.RelatorioDespesas.ToList();
            }
            catch { throw; }
        }

        public IEnumerable<RelatorioDespesa> VisualizarPDF()
        {
            try
            {
                return db.RelatorioDespesas.ToList();
            }
            catch { throw; }
        }

        public IEnumerable<RelatorioDespesa> GetAllDespesas()
        {
            try
            {
                return db.RelatorioDespesas.ToList();
            }
            catch { throw; }
        }
        // Filtra os registros com base na string de busca
        public IEnumerable<RelatorioDespesa> GetFiltraDespesa(string criterio)
        {
            List<RelatorioDespesa> desp = new List<RelatorioDespesa>();
            try
            {
                desp = GetAllDespesas().ToList();
                return desp.Where(x => x.ItemNome.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch { throw; }
        }
        //Adicionar uma nova despesas
        public void AddDespesa(RelatorioDespesa despesa)
        {
            try
            {
                db.RelatorioDespesas.Add(despesa);
                db.SaveChanges();
            }
            catch { throw; }
        }
        //atualizar uma despesa    
        public int UpdateDespesa(RelatorioDespesa despesa)
        {
            try
            {
                db.Entry(despesa).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch { throw; }
        }
        //Obter uma despesa pelo seu id
        public RelatorioDespesa GetDespesa(int id)
        {
            try
            {
                RelatorioDespesa despesa = db.RelatorioDespesas.Find(id);
                return despesa;
            }
            catch { throw; }
        }
        //Deletar uma despesa
        public void DeleteDespesa(int id)
        {
            try
            {
                RelatorioDespesa desp = db.RelatorioDespesas.Find(id);
                db.RelatorioDespesas.Remove(desp);
                db.SaveChanges();
            }
            catch { throw; }
        }
        //Calcula despesa semestral
        public Dictionary<string, decimal> CalculaDespesaPeriodo(int periodo)
        {
            Dictionary<string, decimal> SomaDespesasPeriodo = new Dictionary<string, decimal>();
            decimal despAlimentacao = db.RelatorioDespesas.Where
                                (cat => cat.Categoria == "Alimentacao" && (cat.DataDespesa >
                                 DateTime.Now.AddMonths(-periodo)))
                                .Select(cat => cat.Valor)
                                .Sum();
                                decimal despCompras = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Compras" && (cat.DataDespesa >
                                DateTime.Now.AddMonths(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despTransporte = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Transporte" && (cat.DataDespesa >
                                DateTime.Now.AddMonths(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despSaude = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Saude" && (cat.DataDespesa >
                                DateTime.Now.AddMonths(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despMoradia = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Moradia" && (cat.DataDespesa >
                                DateTime.Now.AddMonths(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despLazer = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Lazer" && (cat.DataDespesa >
                                DateTime.Now.AddMonths(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                SomaDespesasPeriodo.Add("Alimentacao", despAlimentacao);
                                SomaDespesasPeriodo.Add("Compras", despCompras);
                                SomaDespesasPeriodo.Add("Transporte", despTransporte);
                                SomaDespesasPeriodo.Add("Saude", despSaude);
                                SomaDespesasPeriodo.Add("Moradia", despMoradia);
                                SomaDespesasPeriodo.Add("Lazer", despLazer);

            return SomaDespesasPeriodo;
        }
        //Calcula despesa mensal
        public Dictionary<string, decimal> CalculaDespesaPeriodoSemanal(int periodo)
        {
            Dictionary<string, decimal> SomaDespesasPeriodoSemanal = new Dictionary<string, decimal>();
            decimal despAlimentacao = db.RelatorioDespesas.Where
                                (cat => cat.Categoria == "Alimentacao" && (cat.DataDespesa >
                                DateTime.Now.AddDays(-periodo)))
                                .Select(cat => cat.Valor)
                                .Sum();
                                decimal despCompras = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Compras" && (cat.DataDespesa >
                                DateTime.Now.AddDays(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despTransporte = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Transporte" && (cat.DataDespesa >
                                DateTime.Now.AddDays(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despSaude = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Saude" && (cat.DataDespesa >
                                DateTime.Now.AddDays(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despMoradia = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Moradia" && (cat.DataDespesa >
                                DateTime.Now.AddDays(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
                                decimal despLazer = db.RelatorioDespesas.Where
                               (cat => cat.Categoria == "Lazer" && (cat.DataDespesa >
                                DateTime.Now.AddDays(-periodo)))
                               .Select(cat => cat.Valor)
                               .Sum();
            SomaDespesasPeriodoSemanal.Add("Alimentacao", despAlimentacao);
            SomaDespesasPeriodoSemanal.Add("Compras", despCompras);
            SomaDespesasPeriodoSemanal.Add("Transporte", despTransporte);
            SomaDespesasPeriodoSemanal.Add("Saude", despSaude);
            SomaDespesasPeriodoSemanal.Add("Moradia", despMoradia);
            SomaDespesasPeriodoSemanal.Add("Lazer", despLazer);
            return SomaDespesasPeriodoSemanal;
        }
    }
}
