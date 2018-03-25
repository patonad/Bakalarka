using System;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace svetelna_tabula
{
    public class Databaza
    {
        OracleConnection con;
        public Databaza()
        {
            string conStr = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = obelix.fri.uniza.sk)(PORT = 1521)))"
                + "(CONNECT_DATA =(SERVICE_NAME = orcl2.fri.uniza.sk)));User ID=nad;Password=pato1303;";
            con = new OracleConnection(conStr);

        }
       
        public int zistiCiJaTym(string meno, string sport)
        {

            OracleCommand c = new OracleCommand("select * from tym where nazov = '" + meno + "' and sport =  '" + sport + "'", con);
            OracleDataReader reader = c.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return 0;
            }


        }
        public string zistiCiJeHrac(int id_tym, int cislo)
        {

            OracleCommand c = new OracleCommand("select * from hraci where id_tym = '" + id_tym + "' and Cislo =  '" + cislo + "'", con);
            OracleDataReader reader = c.ExecuteReader();
            if (reader.Read())
            {
                return reader["Meno"].ToString() +" "+ reader["priezvisko"].ToString();
            }
            else
            {
                return "";
            }


        }

        public List<List<string>> nacitajTop10(int id_tym)
        {
            OracleCommand c = new OracleCommand("select  meno, CISLO,PRIEZVISKO,POCET_GOLOV,POCET_ASISTENCII,(POCET_ASISTENCII + POCET_GOLOV) as"+
            " score from hraci WHERE ID_TYM = '"+id_tym+ "'order by score desc FETCH FIRST 10 ROWS ONLY", con);
            OracleDataReader reader = c.ExecuteReader();
            List<List<string>> zoznam = new List<List<string>>();
            List<string> list = new List<string>();
            list.Add("Čislo harča");
            list.Add("Meno harča");
            list.Add("Priezvisko harča");
            list.Add("Počet gólov");
            list.Add("Počet asistencii");
            list.Add("Celkove skóre");
            zoznam.Add(list);
            while (reader.Read()) {
                List<string> l = new List<string>();
                l.Add(reader["Cislo"].ToString());
                l.Add(reader["meno"].ToString());
                l.Add(reader["priezvisko"].ToString());                
                l.Add(reader["pocet_golov"].ToString());
                l.Add(reader["pocet_asistencii"].ToString());
                l.Add(reader["score"].ToString());
                zoznam.Add(l);
            }
            return zoznam;
           

        }
        public int pridajZapas(int hostia, int domaci)
        {
            String datum = "" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            OracleCommand c = new OracleCommand("select max(id_zapas) from zapas", con);
            OracleDataReader reader = c.ExecuteReader();
            int index = 0;
            if (reader.Read())
            {
                index = reader.GetInt32(0);
            }
            index++;
            c = new OracleCommand("INSERT INTO ZAPAS(DATUM, TYM_HOSTIA, TYM_DOMACI, ID_ZAPAS, GOLHOSTIA, GOLDOMACI) VALUES (TO_DATE('" + datum + "', 'YYYY-MM-DD'), '"
                + hostia + "', '" + domaci + "', '" + index + "','0','0')", con);
            c.ExecuteNonQuery();
            return index;
        }
        public void pridajZaznam(int id_zapas, int idTymu, int cislo, string cas, string typ)
        {
            OracleCommand c = new OracleCommand("INSERT INTO ZAZNAM (ID_ZAPAS, ID_TYM, CISLO, CAS, TYP_ZAZNAMU) VALUES ('" + id_zapas + 
                "', '" + idTymu + "', '" + cislo + "', '" + cas + "', '" + typ + "')", con);
            c.ExecuteNonQuery();

        }
        public void upravSkore(int id, int hostia, int domaci)
        {
            OracleCommand c = new OracleCommand("UPDATE zapas SET golHostia = "+ hostia+", golDomaci = "+domaci+" where ID_ZAPAS = "+id, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public void upravGol(int id_tym, int cislo)
        {
            OracleCommand c = new OracleCommand("select pocet_golov from hraci where id_tym = "+ id_tym+" and cislo = " + cislo, con);
            OracleDataReader reader = c.ExecuteReader();
            int pocet = 0;
            if (reader.Read())
            {
                pocet = reader.GetInt32(0);
            }
            pocet++;
            c = new OracleCommand("UPDATE hraci SET pocet_golov = " + pocet + " where id_tym = " + id_tym + " and cislo = " + cislo, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public void upravFaul(int id_tym, int cislo)
        {
            OracleCommand c = new OracleCommand("select faul from hraci where id_tym = " + id_tym + " and cislo = " + cislo, con);
            OracleDataReader reader = c.ExecuteReader();
            int pocet = 0;
            if (reader.Read())
            {
                pocet = reader.GetInt32(0);
            }
            pocet++;
            c = new OracleCommand("UPDATE hraci SET faul = " + pocet + " where id_tym = " + id_tym + " and cislo = " + cislo, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public void upravAsistencia(int id_tym, int cislo)
        {
            OracleCommand c = new OracleCommand("select pocet_asistencii from hraci where id_tym = " + id_tym + " and cislo = " + cislo, con);
            OracleDataReader reader = c.ExecuteReader();
            int pocet = 0;
            if (reader.Read())
            {
                pocet = reader.GetInt32(0);
            }
            pocet++;
            c = new OracleCommand("UPDATE hraci SET pocet_asistencii = " + pocet + " where id_tym = " + id_tym + " and cislo = " + cislo, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }

        public bool pripoj()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Nepodarilo sa pripojiť");
                return false;
            }
        }
        public void odpoj()
        {
            OracleCommand c = new OracleCommand("Commit", con);
            c.ExecuteNonQuery();
            con.Close();
        }
    }

}
