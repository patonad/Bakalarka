
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
       
        public int ZistiCiJeTim(string meno, string sport)
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
        public string ZistiCiJeHrac(int id_tim, int cislo)
        {

            OracleCommand c = new OracleCommand("select * from hraci where id_tym = '" + id_tim + "' and Cislo =  '" + cislo + "'", con);
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
        public List<List<string>> NacitajOdohrateZapasy(int id_timHostia, int id_timDomaci)
        {
            OracleCommand c = new OracleCommand("select zapas.ID_ZAPAS, zapas.GOLHOSTIA, zapas.GOLDOMACI,zapas.DATUM, dom.NAZOV as domaci, hos.NaZOV as hostia "+
            "from zapas join tym dom on (zapas.TYM_DOMACI = dom.ID_TYM) join tym hos on (zapas.TYM_HOSTIA = hos.ID_TYM)"+
             "where TYM_DOMACI = '"+ id_timHostia + "' or TYM_HOSTIA = '"+id_timHostia+"' order by id_zapas desc FETCH FIRST 10 ROWS ONLY", con);
            OracleDataReader reader1 = c.ExecuteReader();
            c = new OracleCommand("select zapas.ID_ZAPAS, zapas.GOLHOSTIA, zapas.GOLDOMACI,zapas.DATUM, dom.NAZOV as domaci, hos.NaZOV as hostia " +
            "from zapas join tym dom on (zapas.TYM_DOMACI = dom.ID_TYM) join tym hos on (zapas.TYM_HOSTIA = hos.ID_TYM)" +
             "where TYM_DOMACI = '" + id_timDomaci + "' or TYM_HOSTIA = '" + id_timDomaci + "' order by id_zapas desc FETCH FIRST 10 ROWS ONLY", con);
            OracleDataReader reader2 = c.ExecuteReader();
            List<List<string>> zoznam = new List<List<string>>();
            List<string> list = new List<string>();
            list.Add("Nazov tímu");
            list.Add("Skóre");
            list.Add("Nazov tímu");
            list.Add("Nazov tímu");
            list.Add("Skóre");
            list.Add("Nazov tímu");
            zoznam.Add(list);
            while (reader1.Read() && reader2.Read())
            {
                List<string> l = new List<string>();
                l.Add(reader1["domaci"].ToString());
                l.Add(reader1["GOLDOMACI"].ToString() +" : "+ reader1["GOLHOSTIA"].ToString());
                l.Add(reader1["hostia"].ToString());
                l.Add(reader2["domaci"].ToString());
                l.Add(reader2["GOLDOMACI"].ToString() + " : " + reader2["GOLHOSTIA"].ToString());
                l.Add(reader2["hostia"].ToString());
                zoznam.Add(l);
            }
            return zoznam;


        }
        public List<List<string>> NacitajTop10Celkovo(string sport)
        {
            OracleCommand c = new OracleCommand("select  meno, CISLO,PRIEZVISKO,POCET_GOLOV,POCET_ASISTENCII,(POCET_ASISTENCII + POCET_GOLOV) as" +
            " score, tym.NAZOV from hraci join tym using(id_tym) WHERE sport = '" + sport + "'order by score desc FETCH FIRST 10 ROWS ONLY", con);
            OracleDataReader reader = c.ExecuteReader();
            List<List<string>> zoznam = new List<List<string>>();
            List<string> list = new List<string>();
            list.Add("Čislo harča");
            list.Add("Meno harča");
            list.Add("Priezvisko hráča");
            list.Add("Počet gólov");
            list.Add("Počet asistencii");
            list.Add("Celkove skóre");
            list.Add("Názov tímu");
            zoznam.Add(list);
            while (reader.Read())
            {
                List<string> l = new List<string>();
                l.Add(reader["Cislo"].ToString());
                l.Add(reader["meno"].ToString());
                l.Add(reader["priezvisko"].ToString());
                l.Add(reader["pocet_golov"].ToString());
                l.Add(reader["pocet_asistencii"].ToString());
                l.Add(reader["score"].ToString());
                l.Add(reader["nazov"].ToString());
                zoznam.Add(l);
            }
            return zoznam;


        }
        public List<List<string>> NacitajTop10(int id_tim)
        {
            OracleCommand c = new OracleCommand("select  meno, CISLO,PRIEZVISKO,POCET_GOLOV,POCET_ASISTENCII,(POCET_ASISTENCII + POCET_GOLOV) as"+
            " score from hraci WHERE ID_TYM = '"+id_tim+ "'order by score desc FETCH FIRST 10 ROWS ONLY", con);
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
        public int PridajZapas(int hostia, int domaci)
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
        public void PridajZaznam(int id_zapas, int idTimu, int cislo, string cas, string typ)
        {
            OracleCommand c = new OracleCommand("INSERT INTO ZAZNAM (ID_ZAPAS, ID_TYM, CISLO, CAS, TYP_ZAZNAMU) VALUES ('" + id_zapas + 
                "', '" + idTimu + "', '" + cislo + "', '" + cas + "', '" + typ + "')", con);
            c.ExecuteNonQuery();

        }
        public void UpravSkore(int id, int hostia, int domaci)
        {
            OracleCommand c = new OracleCommand("UPDATE zapas SET golHostia = "+ hostia+", golDomaci = "+domaci+" where ID_ZAPAS = "+id, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public void UpravGol(int id_tim, int cislo)
        {
            OracleCommand c = new OracleCommand("select pocet_golov from hraci where id_tym = "+ id_tim+" and cislo = " + cislo, con);
            OracleDataReader reader = c.ExecuteReader();
            int pocet = 0;
            if (reader.Read())
            {
                pocet = reader.GetInt32(0);
            }
            pocet++;
            c = new OracleCommand("UPDATE hraci SET pocet_golov = " + pocet + " where id_tym = " + id_tim + " and cislo = " + cislo, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public void UpravFaul(int id_tim, int cislo)
        {
            OracleCommand c = new OracleCommand("select faul from hraci where id_tym = " + id_tim + " and cislo = " + cislo, con);
            OracleDataReader reader = c.ExecuteReader();
            int pocet = 0;
            if (reader.Read())
            {
                pocet = reader.GetInt32(0);
            }
            pocet++;
            c = new OracleCommand("UPDATE hraci SET faul = " + pocet + " where id_tym = " + id_tim + " and cislo = " + cislo, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public void UpravAsistencia(int id_tim, int cislo)
        {
            OracleCommand c = new OracleCommand("select pocet_asistencii from hraci where id_tym = " + id_tim + " and cislo = " + cislo, con);
            OracleDataReader reader = c.ExecuteReader();
            int pocet = 0;
            if (reader.Read())
            {
                pocet = reader.GetInt32(0);
            }
            pocet++;
            c = new OracleCommand("UPDATE hraci SET pocet_asistencii = " + pocet + " where id_tym = " + id_tim + " and cislo = " + cislo, con);
            c.ExecuteNonQuery();
            c = new OracleCommand("commit", con);
            c.ExecuteNonQuery();
        }
        public bool Pripoj()
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
        public void Odpoj()
        {
            OracleCommand c = new OracleCommand("Commit", con);
            c.ExecuteNonQuery();
            con.Close();
        }
    }

}
