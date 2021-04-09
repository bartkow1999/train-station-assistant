using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace station_app
{
    class DataAccess
    {
        public List<T> GetAllFromTable<T>(string table_name, string order, T arg)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<T>($"select * from {table_name} order by {order}").ToList();
            }
        }

        public List<T> GetSpecificFromTable<T>(string table_name, string criterium, string value, string order, T arg)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<T>($"select * from {table_name} where {criterium} like '%{value}%' order by {order}").ToList();
            }
        }

        public int GetSeqNextVal(string seq_name)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<int>($"select {seq_name}.nextval from dual").First();
            }
        }

        public string GetTableCount(string table_name, string parameter, DateTime data_od, DateTime data_do)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                //string commandText = "select count(*) from kursy where data between to_date(:data_od,'yyyy/MM/dd') and to_date(:data_do,'yyyy/MM/dd')";
                string commandText = "select count(*) from " + table_name + " where " + parameter + " between :data_od and :data_do";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("data_od", data_od));
                    command.Parameters.Add(new OracleParameter("data_do", data_do));
                    command.Connection.Open();
                    string value = command.ExecuteScalar().ToString();
                    command.Connection.Close();
                    return value;
                }
            }
        }

        public string GetTableCount(string table_name)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<string>($"select count(*) from {table_name}").First().ToString();
            }
        }

        public string GetKursyCount_function(DateTime data_od, DateTime data_do)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "select liczba_kursow(:data_od, :data_do) from dual";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("data_od", data_od));
                    command.Parameters.Add(new OracleParameter("data_do", data_do));
                    command.Connection.Open();
                    string value = command.ExecuteScalar().ToString();
                    command.Connection.Close();
                    return value;
                }
            }
        }

        public string GetAverageTime()
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                int suma = connection.Query<int>($"select sum(opoznienie) from kursy").First();
                int ilosc = connection.Query<int>($"select count(*) from kursy").First();
                double value = suma / (double)ilosc;
                double rounded = Math.Round(value, 2);
                return rounded.ToString();
            }
        }


        public void PetenciAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into petenci(id_petenta,imie,nazwisko,telefon,mail,uwagi)" +
                    " values(:id_petenta,:imie,:nazwisko,:telefon,:mail,:uwagi)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_petenta", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("imie", parameters[1]));
                    command.Parameters.Add(new OracleParameter("nazwisko", parameters[2]));
                    command.Parameters.Add(new OracleParameter("telefon", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("mail", parameters[4]));
                    command.Parameters.Add(new OracleParameter("uwagi", parameters[5]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void AsystenciAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into asystenci(id_asystenta,imie,nazwisko)" +
                    " values(:id_asystenta,:imie,:nazwisko)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_asystenta", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("imie", parameters[1]));
                    command.Parameters.Add(new OracleParameter("nazwisko", parameters[2]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void Typy_pomocyAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into typy_pomocy(ID_typu_pomocy,opis)" +
                    " values(:ID_typu_pomocy,:opis)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_typu_pomocy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("opis", parameters[1]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void Rodzaje_PociagowAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into rodzaje_pociagow(ID_rodzaju_pociagu,maksymalna_szybkosc)" +
                    " values(:ID_rodzaju_pociagu,:maksymalna_szybkosc)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_rodzaju_pociagu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("maksymalna_szybkosc", Int32.Parse(parameters[1])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void PrzewoznicyAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into przewoznicy(ID_przewoznika,nazwa,opis)" +
                    " values(:ID_przewoznika,:nazwa,:opis)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_przewoznika", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("nazwa", parameters[1]));
                    command.Parameters.Add(new OracleParameter("opis", parameters[2]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void ZestawieniaAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into zestawienia(ID_zestawienia,wagony)" +
                    " values(:ID_zestawienia,:wagony)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_zestawienia", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("wagony", Int32.Parse(parameters[1])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void RelacjeAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into relacje(ID_relacji,stacja_poczatkowa,stacja_koncowa,FK_ID_rodzaj_pociagu,FK_ID_przewoznika,FK_ID_zestawienia)" +
                    " values(:ID_relacji,:stacja_poczatkowa,:stacja_koncowa,:FK_ID_rodzaj_pociagu,:FK_ID_przewoznika,:FK_ID_zestawienia)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_relacji", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("stacja_poczatkowa", parameters[1]));
                    command.Parameters.Add(new OracleParameter("stacja_koncowa", parameters[2]));
                    command.Parameters.Add(new OracleParameter("FK_ID_rodzaj_pociagu", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("FK_ID_przewoznika", Int32.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("FK_ID_zestawienia", Int32.Parse(parameters[5])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void StacjeAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into stacje(ID_stacji,nazwa,odleglosc)" +
                    " values(:ID_stacji,:nazwa,:odleglosc)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_stacji", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("nazwa", parameters[1]));
                    command.Parameters.Add(new OracleParameter("odleglosc", parameters[2]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void TrasyAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into trasy(ID_trasy,godzina_przyjazdu,godzina_odjazdu)" +
                    " values(:ID_trasy,:godzina_przyjazdu,:godzina_odjazdu)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_trasy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("godzina_przyjazdu", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("godzina_odjazdu", DateTime.Parse(parameters[2])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void KursyAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into kursy(ID_kursu,data,stacja_poczatkowa,stacja_koncowa,godzina_odjazdu,peron,opoznienie,uwagi)" +
                    " values(:ID_kursu,:data,:stacja_poczatkowa,:stacja_koncowa,:godzina_odjazdu,:peron,:opoznienie,:uwagi)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_kursu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("stacja_poczatkowa", parameters[2]));
                    command.Parameters.Add(new OracleParameter("stacja_koncowa", parameters[3]));
                    command.Parameters.Add(new OracleParameter("godzina_odjazdu", DateTime.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("peron", parameters[5]));
                    command.Parameters.Add(new OracleParameter("opoznienie", Int32.Parse(parameters[6])));
                    command.Parameters.Add(new OracleParameter("uwagi", parameters[7]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void PomoceAdd(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into pomoce(ID_pomocy,data_zgloszenia,godzina_zgloszenia,FK_ID_kursu,FK_ID_petenta,FK_ID_asystenta,FK_ID_typu_pomocy)" +
                    " values(:ID_pomocy,:data_zgloszenia,:godzina_zgloszenia,:FK_ID_kursu,:FK_ID_petenta,:FK_ID_asystenta,:FK_ID_typu_pomocy)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_pomocy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data_zgloszenia", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("godzina_zgloszenia", DateTime.Parse(parameters[2])));
                    command.Parameters.Add(new OracleParameter("FK_ID_kursu", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("FK_ID_petenta", Int32.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("FK_ID_asystenta", Int32.Parse(parameters[5])));
                    command.Parameters.Add(new OracleParameter("FK_ID_typu_pomocy", Int32.Parse(parameters[6])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }


        public void PetenciEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update petenci set imie=:imie, nazwisko=:nazwisko, telefon=:telefon, mail=:mail, uwagi=:uwagi " +
                    "where id_petenta=:id_petenta";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_petenta", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("imie", parameters[1]));
                    command.Parameters.Add(new OracleParameter("nazwisko", parameters[2]));
                    command.Parameters.Add(new OracleParameter("telefon", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("mail", parameters[4]));
                    command.Parameters.Add(new OracleParameter("uwagi", parameters[5]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void AsystenciEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update asystenci set imie=:imie, nazwisko=:nazwisko " +
                    "where ID_asystenta=:ID_asystenta";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_asystenta", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("imie", parameters[1]));
                    command.Parameters.Add(new OracleParameter("nazwisko", parameters[2]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void Typy_pomocyEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update typy_pomocy set opis=:opis " +
                    "where ID_typu_pomocy=:ID_typu_pomocy";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_typu_pomocy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("opis", parameters[1]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void Rodzaje_pociagowEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update rodzaje_pociagow set opis=:opis " +
                    "where ID_rodzaju_pociagu=:ID_rodzaju_pociagu";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_rodzaju_pociagu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("opis", Int32.Parse(parameters[1])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void PrzewoznicyEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update przewoznicy set nazwa=:nazwa, opis=:opis " +
                    "where ID_przewoznika=:ID_przewoznika";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_przewoznika", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("nazwa", parameters[1]));
                    command.Parameters.Add(new OracleParameter("opis", parameters[2]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void ZestawieniaEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update zestawienia set wagony=:wagony " +
                    "where ID_zestawienia=:ID_zestawienia";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_zestawienia", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("wagony", Int32.Parse(parameters[1])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void RelacjeEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update relacje set stacja_poczatkowa=:stacja_poczatkowa, stacja_koncowa=:stacja_koncowa, " +
                    "FK_ID_rodzaj_pociagu=:FK_ID_rodzaj_pociagu, FK_ID_przewoznika=:FK_ID_przewoznika, FK_ID_zestawienia:=FK_ID_zestawienia " +
                    "where ID_relacji=:ID_relacji";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_relacji", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("stacja_poczatkowa", parameters[1]));
                    command.Parameters.Add(new OracleParameter("stacja_koncowa", parameters[2]));
                    command.Parameters.Add(new OracleParameter("FK_ID_rodzaj_pociagu", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("FK_ID_przewoznika", Int32.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("FK_ID_zestawienia", Int32.Parse(parameters[5])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void StacjeEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update stacje set nazwa=:nazwa, odleglosc=:odleglosc " +
                    "where ID_stacji=:ID_stacji";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_stacji", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("nazwa", parameters[1]));
                    command.Parameters.Add(new OracleParameter("odleglosc", parameters[2]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void TrasyEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update trasy set godzina_przyjazdu=:godzina_przyjazdu, godzina_odjazdu=:godzina_odjazdu " +
                    "where ID_trasy=:ID_trasy";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_trasy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("godzina_przyjazdu", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("godzina_odjazdu", DateTime.Parse(parameters[2])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void KursyEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update kursy set data=:data, stacja_poczatkowa=:stacja_poczatkowa, stacja_koncowa=:stacja_koncowa, " +
                    "godzina_odjazdu:=godzina_odjazdu, peron:=peron, opoznienie:=opoznienie, uwagi:=uwagi" +
                    "where ID_kursu=:ID_kursu";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_kursu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("stacja_poczatkowa", parameters[2]));
                    command.Parameters.Add(new OracleParameter("stacja_koncowa", parameters[3]));
                    command.Parameters.Add(new OracleParameter("godzina_odjazdu", DateTime.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("peron", parameters[5]));
                    command.Parameters.Add(new OracleParameter("opoznienie", Int32.Parse(parameters[6])));
                    command.Parameters.Add(new OracleParameter("uwagi", parameters[7]));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void PomoceEdit(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update pomoce set data_zgloszenia=:data_zgloszenia, godzina_zgloszenia=:godzina_zgloszenia, FK_ID_kursu:=FK_ID_kursu, " +
                    "FK_ID_petenta:=FK_ID_petenta, FK_ID_asystenta:=FK_ID_asystenta, FK_ID_typu_pomocy:=FK_ID_typu_pomocy " +
                    "where ID_pomocy=:ID_pomocy";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("ID_pomocy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data_zgloszenia", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("godzina_zgloszenia", DateTime.Parse(parameters[2])));
                    command.Parameters.Add(new OracleParameter("FK_ID_kursu", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("FK_ID_petenta", Int32.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("FK_ID_asystenta", Int32.Parse(parameters[5])));
                    command.Parameters.Add(new OracleParameter("FK_ID_typu_pomocy", Int32.Parse(parameters[6])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }


        public void DodajPolaczenie(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "insert into kursy(id_kursu,data,stacja_poczatkowa,stacja_koncowa,godzina_odjazdu,peron,opoznienie,uwagi,fk_id_relacji)" +
                    " values(:id_kursu,:data,:stacja_poczatkowa,:stacja_koncowa,:godzina_odjazdu,:peron,:opoznienie,:uwagi,:fk_id_relacji)";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_kursu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("stacja_poczatkowa", parameters[2]));
                    command.Parameters.Add(new OracleParameter("stacja_koncowa", parameters[3]));
                    command.Parameters.Add(new OracleParameter("godzina_odjazdu", DateTime.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("peron", parameters[5]));
                    command.Parameters.Add(new OracleParameter("opoznienie", Int32.Parse(parameters[6])));
                    command.Parameters.Add(new OracleParameter("uwagi", parameters[7]));
                    command.Parameters.Add(new OracleParameter("fk_id_relacji", Int32.Parse(parameters[8])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void EdytujPolaczenie(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update kursy set data=:data, stacja_poczatkowa=:stacja_poczatkowa, stacja_koncowa=:stacja_koncowa, godzina_odjazdu=:godzina_odjazdu," +
                    "peron=:peron, opoznienie=:opoznienie, uwagi=:uwagi, fk_id_relacji=:fk_id_relacji " +
                    "where id_kursu=:id_kursu";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_kursu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("stacja_poczatkowa", parameters[2]));
                    command.Parameters.Add(new OracleParameter("stacja_koncowa", parameters[3]));
                    command.Parameters.Add(new OracleParameter("godzina_odjazdu", DateTime.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("peron", parameters[5]));
                    command.Parameters.Add(new OracleParameter("opoznienie", Int32.Parse(parameters[6])));
                    command.Parameters.Add(new OracleParameter("uwagi", parameters[7]));
                    command.Parameters.Add(new OracleParameter("fk_id_relacji", Int32.Parse(parameters[8])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void UsunPolaczenie(string id_kursu)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "delete from kursy where id_kursu=:id_kursu";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_kursu", Int32.Parse(id_kursu)));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }






        public List<Pomoc> GetAllFromTableHelps(string table_name, string order)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<Pomoc>($"select * from {table_name} order by {order}").ToList();
            }
        }

        public List<PomoceView> GetAllFromTableHelpsView(string table_name, string order)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<PomoceView>($"select * from {table_name} order by {order}").ToList();
            }
        }

        public List<PomoceView> GetSpecificFromTableHelps(string table, string criterium, string value, string order)
        {
            if (criterium == "DATA")
            {
                criterium = "fk_id_kursu";
            }

            if (criterium == "GODZINA")
            {
                criterium = "fk_id_kursu";
            }

            if (criterium == "KURS")
            {
                criterium = "fk_id_kursu";
            }

            if (criterium == "IMIE")
            {
                criterium = "imie_petenta";
            }

            if (criterium == "NAZWISKO")
            {
                criterium = "nazwisko_petenta";
            }

            if (criterium == "ASYSTENT")
            {
                criterium = "imie_asystenta";
            }

            if (criterium == "NAZWISKO2")
            {
                criterium = "nazwisko_asystenta";
            }


            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                return connection.Query<PomoceView>($"select * from {table} where {criterium} like '%{value}%' order by {order}").ToList();
            }
        }

        public void DodajPomoc(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "BEGIN dodaj_pomoc (:id_kursu,:data_zgloszenia,:godzina_zgloszenia," +
                    ":fk_id_kursu,:fk_id_petenta,:fk_id_asystenta,:fk_id_typu_pomocy); END;";

                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_kursu", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data_zgloszenia", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("godzina_zgloszenia", DateTime.Parse(parameters[2])));
                    command.Parameters.Add(new OracleParameter("fk_id_kursu", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("fk_id_petenta", Int32.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("fk_id_asystenta", Int32.Parse(parameters[5])));
                    command.Parameters.Add(new OracleParameter("fk_id_typu_pomocy", Int32.Parse(parameters[6])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }


        public void DeleteRecord(string table_name, string criterium, string value)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "delete from " + table_name + " where " + criterium + "=:value";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("value", Int32.Parse(value)));

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }


        public void EdytujPomoc(List<string> parameters)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "update pomoce set data_zgloszenia=:data_zgloszenia, godzina_zgloszenia=:godzina_zgloszenia," +
                    "fk_id_kursu=:fk_id_kursu, fk_id_petenta=:fk_id_petenta, fk_id_asystenta=:fk_id_asystenta, fk_id_typu_pomocy=:fk_id_typu_pomocy " +
                    "where id_pomocy=:id_pomocy";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_pomocy", Int32.Parse(parameters[0])));
                    command.Parameters.Add(new OracleParameter("data_zgloszenia", DateTime.Parse(parameters[1])));
                    command.Parameters.Add(new OracleParameter("godzina_zgloszenia", DateTime.Parse(parameters[2])));
                    command.Parameters.Add(new OracleParameter("fk_id_kursu", Int32.Parse(parameters[3])));
                    command.Parameters.Add(new OracleParameter("fk_id_petenta", Int32.Parse(parameters[4])));
                    command.Parameters.Add(new OracleParameter("fk_id_asystenta", Int32.Parse(parameters[5])));
                    command.Parameters.Add(new OracleParameter("fk_id_typu_pomocy", Int32.Parse(parameters[6])));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void UsunPomoc(string id_pomocy)
        {
            using (IDbConnection connection = new OracleConnection(Helper.ConnStrVal("OracleDB")))
            {
                string commandText = "delete from pomoce where id_pomocy=:id_pomocy";
                using (OracleCommand command = new OracleCommand(commandText, (OracleConnection)connection) { BindByName = true })
                {
                    command.Parameters.Add(new OracleParameter("id_pomocy", Int32.Parse(id_pomocy)));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

    }
}
