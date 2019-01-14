using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WindowsFormsControlLibrary1
{
    class DBConnect
    {
        private SqlConnection Con;
        private readonly string connectionString = "Data Source=den1.mssql8.gear.host;Initial Catalog=inviktusdatabase; User Id=inviktusdatabase;Password=Vd23hHD_4?T3";

        public void Connectar()
        {
            Con = new SqlConnection(connectionString);
            Con.Open();
        }

        private void TancarConnexio()
        {
            Con.Close();
        }

        public DataSet PortarTaula(string nomTaula)
        {
            string consulta = "SELECT * FROM " + nomTaula;
            return PortarPerConsulta(consulta);
        }

        public DataSet PortarPerConsulta(string query)
        {
            DataSet dataSet = new DataSet();
            FillDataSet(dataSet, query);

            return dataSet;
        }
        public DataSet PortarPerConsulta(string query, string nomTaula)
        {
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet, query, nomTaula);

            return dataSet;
        }

        public void FillDataSet(DataSet dataSet, string query, string nomTaula = "")
        {
            Connectar();
            SqlDataAdapter DP = new SqlDataAdapter(query, Con);
            if (nomTaula != "")
            {
                DP.Fill(dataSet, nomTaula);
            }
            else
            {
                DP.Fill(dataSet);
            }

            TancarConnexio();
        }

        public void Actualitzar(string queryOriginal, DataSet dataSet)
        {
            Connectar();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryOriginal, Con);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);

            dataAdapter.Update(dataSet.Tables[0]);
            TancarConnexio();
        }

        public int Executa(string query)
        {
            Connectar();
            SqlCommand sql = new SqlCommand(query, Con);
            int resultat = sql.ExecuteNonQuery();
            TancarConnexio();
            return resultat;
        }
    }
}
