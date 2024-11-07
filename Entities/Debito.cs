using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Models
    {
    internal class Debito
        {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set;}
        public double Valor {  get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Boolean Pago { get; set; }
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        public Debito ( ) { }
        public Debito ( string codigoBarras, string descricao, double valor, DateTime dataEmissao, DateTime dataVencimento,Boolean pago ,Aluno aluno )
            {
            CodigoBarras = codigoBarras;
            Descricao = descricao;
            Valor = valor;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Pago = pago;
            Aluno = aluno;
            AlunoId = aluno.Id;
            }
        public Debito (int id, string codigoBarras,  string descricao, double valor, DateTime dataEmissao, DateTime dataVencimento,Boolean pago, Aluno aluno) 
            {
            Id = id;
            CodigoBarras = codigoBarras;
            Descricao = descricao;
            Valor = valor;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Pago = pago;
            Aluno = aluno;
            AlunoId = aluno.Id;
            }

        public override string ToString ( )
            {
            return "Codigo de Barras: " + CodigoBarras
                //+ "\nNome: " + Aluno.Nome
                + "\nDescricao: " + Descricao
                + "\nValor: " + Valor
                + "\nPago: " + (Pago?"Pago":"Aberto") 
                + "\nData emissão: " + DataEmissao
                + "\nData vencimento: " + DataVencimento;
            }

        }
    }
