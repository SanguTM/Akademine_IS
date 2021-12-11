using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
//using WG_Utilities;

namespace Akademine_IS
{
    /// <summary>
    /// Klase skirta vykdyti SQL Stored Proceduras.
    /// Inicializavimui reikalingas t_DataHandler.
    /// </summary>
    public class t_StoredProc
    {
        /// <summary>[t_DataHandler] objektas</summary>
        protected t_DataHandler DataHandler;
        private SqlCommand Command;

        /// <summary>
        /// Dabar Nenaudojamas. Reikalingas asinchroniniam kvietimui
        /// </summary>
        private event t_DataEventDelegate OnCompleteAsyncQuery = null;
        /// <summary>
        /// Kviecia DataHandler'io OnBeforeQuery
        /// </summary>
        private event t_BeforeQueryEventDelegate OnBeforeQuery = null;
        /// <summary>
        /// Kviecia DataHandler'io OnAfterQuery
        /// </summary>
        private event t_AfterQueryEventDelegate OnAfterQuery = null;

        #region Properties
        private string FStoredProcName;
        private bool FPrepared;
        /// <summary>
        /// Nurodo Stor'os varda (gets or sets)
        /// Nustacius reikia iskviesti Prepare()
        /// </summary>
        public string StoredProcName
        {
            get
            {
                return FStoredProcName;
            }
            set
            {
                FPrepared = false;
                FStoredProcName = value;
            }
        }

        /// <summary>
        /// Grazina komandos parametru aibe (gets)
        /// </summary>
        public SqlParameterCollection Parameters
        {
            get
            {
                if (Command != null)
                    return Command.Parameters;
                else
                    return null;
            }
        }

        /// <summary>
        /// Proceduros parametru kiekis (gets)
        /// </summary>
        public int ParamCount
        {
            get
            {
                if (Command != null)
                    return Command.Parameters.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Ar pasiruosta vykdymui. Jei ne - reikia kviesti Prepare()
        /// Prepare paruosia parametru aibe.
        /// </summary>
        public bool Prepared
        {
            get
            {
                return FPrepared;
            }
        }
        #endregion

        #region Events
        /// <summary> Prieš USP vykdymą. </summary>
        public event EventHandler BeforeExecute;
        /// <summary> Po USP vykdymo. </summary>
        public event EventHandler AfterExecute;
        /// <summary> Prieš [DataTable] užpildymą duomenimis iš DB. </summary>
        public event EventHandler BeforeOpen;
        /// <summary> Po [DataTable] užpildymo duomenimis iš DB. </summary>
        public event EventHandler AfterOpen;
        #endregion

        #region Constructors
        /// <summary>
        /// Sukuria t_StoredProc Objekta. 
        /// Objekto naudojimui reikes priskirti property StoredProcName ir ivykdyti metodą Prepare.
        /// </summary>
        /// <param name="ADataHandler">DataHandler objektas per kuri ir bus vykdoma USP</param>
        public t_StoredProc(t_DataHandler ADataHandler)
        {
            DataHandler = ADataHandler;
        }

        /// <summary>
        /// Sukuria ir inicializuoja t_StoredProc Objekta, iskviecia Prepare(), todel nereikia kviesti paciam
        /// (Prepare gauna proceduros parametru sarasa)
        /// </summary>
        /// <param name="ADataHandler">DataHandler'is</param>
        /// <param name="AProcName">Proceduros pavadinimas</param>
        public t_StoredProc(t_DataHandler ADataHandler, string AProcName)
            : this(ADataHandler)
        {
            this.StoredProcName = AProcName;
            this.Prepare();
        }
        #endregion

        /// <summary>
        /// Paruosia StoredProcedure-a vykdymui (surenka jos parametru info is DB, ismeta is saraso pirmaji parametra)
        /// </summary>
        public void Prepare()
        {
            if (!Prepared)
            {
                Command = DataHandler.Connection.CreateCommand();
                Command.CommandText = StoredProcName;
                Command.CommandType = CommandType.StoredProcedure;

                SqlCommandBuilder.DeriveParameters(Command);
                Command.Parameters.RemoveAt(0);
                //Pradziai priskiriu NULL-us parametrams
                //for (int i = 0; i < Command.Parameters.Count; i++)
                //  Command.Parameters[i].Value = DBNull.Value;
                FPrepared = true;

                //Perkeliau cia, nes kai kvieciamas toks konstruktorius t_StoredProc(DataHandler), tai nesusitvarko parametrai
                OnBeforeQuery += DataHandler.CallOnBeforeQuery;
                OnAfterQuery += DataHandler.CallOnAfterQuery;
                OnCompleteAsyncQuery += DataHandler.CallOnCompleteAsyncQuery;
            }
        }

        /// <summary>
        /// Suranda ir grazina parametra pagal jo pavadinima.
        /// <pre>Jeigu parametras nerastas - null</pre>
        /// </summary>
        /// <param name="paramName">Parametro vardas</param>
        /// <returns>SqlParameter objektas (Jei nerastas - generuoja klaida).</returns>
        public SqlParameter ParamByName(string paramName)
        {
            return Command.Parameters[paramName.Trim()];
            //for (int i = 0; i < Command.Parameters.Count; i++)
            //{
            //  if (Command.Parameters[i].ParameterName.Equals(paramName.Trim(), StringComparison.InvariantCultureIgnoreCase))
            //    return Command.Parameters[i];
            //}
            //return null;
        }

        /// <summary>
        /// Vykdo SP su nustatytais parametrais.
        /// <pre>Naudojama SP NEgrąžinančioms rezultatą įrašų pavidale.</pre>
        /// <pre>DataTable vardas bus: TSP_Exec</pre>
        /// </summary>
        /// <returns>grazina 0, jei OK, -1, jei ivyko klaida</returns>
        public Int16 Execute()
        {
            return Execute("TSP_Exec");//#
        }
        /// <summary>
        /// Vykdo SP su nustatytais parametrais.
        /// <pre>Naudojama SP NEgrąžinančioms rezultatą įrašų pavidale.</pre>
        /// </summary>
        /// <param name="tableName">Grazinamos DataTable vardas</param>
        /// <returns>grazina 0, jei OK, -1, jei ivyko klaida</returns>
        public Int16 Execute(string tableName)
        {
            Int16 FReturnValue = 0;
            //
            if (BeforeExecute != null)
            {
                EventArgs ea = new EventArgs();
                BeforeExecute(this, ea);
            }
            DateTime timeStart = DateTime.Now;
            DateTime timeTemp = DateTime.Now;
            TimeSpan timeAll = TimeSpan.Zero; ;
            TimeSpan timeExec = TimeSpan.Zero; ;
            //TimeSpan timeLoad = TimeSpan.Zero; ;
            //
            if (DataHandler.Connection.State != ConnectionState.Open)
                DataHandler.Connection.Open();
            //SqlDataReader Reader;
            int recAffected = 0;

            Command.Prepare();
            Command.CommandTimeout = 15000;
            //
            if (OnBeforeQuery != null)
                OnBeforeQuery(this, new t_BeforeQueryEventArgs("EXEC " + Command.CommandText, Command, "TSP_Exec"));//#
                                                                                                                    //
            timeTemp = DateTime.Now;
            try
            {
                recAffected = Command.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                //Jei ivyko klaida - vistiek vykdau OnAfterExecute, nes tada SQL monikas rodo SP vykdymo loga
                timeExec = DateTime.Now.Subtract(timeTemp);
                timeAll = DateTime.Now.Subtract(timeStart);
                if (OnAfterQuery != null)
                    OnAfterQuery(this, new t_AfterQueryEventArgs(Command.CommandText, null, Command, recAffected, timeAll, timeExec, TimeSpan.Zero));

                FReturnValue = -1;
                throw;
            }
            timeExec = DateTime.Now.Subtract(timeTemp);
            if (AfterExecute != null)
            {
                EventArgs ea = new EventArgs();
                AfterExecute(this, ea);
            }
            timeAll = DateTime.Now.Subtract(timeStart);

            if (OnAfterQuery != null)
                OnAfterQuery(this, new t_AfterQueryEventArgs(Command.CommandText, null, Command, recAffected, timeAll, timeExec, TimeSpan.Zero));
            return FReturnValue;
        }

        /// <summary>
        /// Vykdo SP su nustatytais parametrais.
        /// <pre>Naudojama SP grąžinančioms rezultatą įrašų pavidale.</pre>
        /// <pre>DataTable vardas bus: TSP_Open</pre>
        /// </summary>
        /// <returns>Grąžina DataTable su duomenimis</returns>
        public DataTable Open()
        {
            return Open("TSP_Open");//#
        }

        /// <summary>
        /// Vykdo SP su nustatytais parametrais.
        /// <pre>Naudojama SP grąžinančioms rezultatą įrašų pavidale.</pre>
        /// <param name="tableName">Grazinamos DataTable vardas</param>
        /// </summary>
        /// <returns>Grąžina DataTable su duomenimis</returns>
        public DataTable Open(string tableName)
        {
            DataTable FReturnValue = null;
            // 
            if (BeforeOpen != null)
            {
                EventArgs ea = new EventArgs();
                BeforeOpen(this, ea);
            }
            DateTime timeStart = DateTime.Now;
            DateTime timeTemp = DateTime.Now;
            TimeSpan timeAll = TimeSpan.Zero;
            TimeSpan timeExec = TimeSpan.Zero;
            TimeSpan timeLoad = TimeSpan.Zero;
            //
            if (DataHandler.Connection.State != ConnectionState.Open)
                DataHandler.Connection.Open();
            SqlDataReader Reader;
            Command.Prepare();
            //
            if (OnBeforeQuery != null)
                OnBeforeQuery(this, new t_BeforeQueryEventArgs("EXEC " + Command.CommandText, Command, "TSP_Open"));//#
                                                                                                                    //
            int recAffected = 0;
            timeTemp = DateTime.Now;
            try
            {
                Reader = Command.ExecuteReader();
                timeExec = DateTime.Now.Subtract(timeTemp);
                //
                recAffected = Reader.RecordsAffected;
                //

                //I Log-a rasau iki SP vykdymo, nes norisi matyti SP vykdymo iniciavima ir normaliai ir ivykus klaidai

                timeTemp = DateTime.Now;
                FReturnValue = DataHandler.ReaderToTable(Reader, tableName);

                timeLoad = DateTime.Now.Subtract(timeTemp);
                Reader.Close();
            }
            catch (Exception x)
            {
                FReturnValue = null;

                throw;
            }
            timeAll = DateTime.Now.Subtract(timeStart);

            if (AfterOpen != null)
            {
                EventArgs ea = new EventArgs();
                AfterOpen(FReturnValue, ea);
            }
            if (OnAfterQuery != null)
            {
                OnAfterQuery(this, new t_AfterQueryEventArgs(Command.CommandText, FReturnValue, Command, recAffected, timeAll, timeExec, timeLoad));
            }
            return FReturnValue;
        }

        /// <summary>
        /// Grazina parametra pagal varda, parsinant visa parametru sarasa.
        /// Jei neranda - grazina null-a. Greitesnis variantas ParamByName(), bet sis negrazina null-o, o luzta, jei neranda.
        /// </summary>
        /// <param name="AParameterName"></param>
        /// <returns></returns>
        public SqlParameter GetParameter(string AParameterName)
        {
            for (int i = 0; i < Command.Parameters.Count; i++)
            {
                if (Command.Parameters[i].ParameterName.Equals(AParameterName.Trim(), StringComparison.InvariantCultureIgnoreCase))
                    return Command.Parameters[i];
            }
            return null;
        }

        /// <summary>
        /// Uzpildo Storos parametru rreiksmes pagal pateikta lenteles eilute ARow.
        /// Parametrai uzpildomi pagal lenteles koloneliu pavadinimus pridedanr @pi arba @po is priekio.
        /// Jei parametras pagal toki pavadinima nerastas - jo reiksme = DBNull.Value.
        /// </summary>
        /// <param name="ARow"></param>
        public void FillParamsFromRow(DataRow ARow)
        {
            for (int i = 0; i < ARow.Table.Columns.Count; i++)
            {
                string FFieldName = ARow.Table.Columns[i].ColumnName;
                SqlParameter FParameter = GetParameter("@pi" + FFieldName);
                if (FParameter != null)
                {
                    if (FParameter.SqlDbType == SqlDbType.VarChar || FParameter.SqlDbType == SqlDbType.NVarChar)
                    {
                        FParameter.Value = ARow[FFieldName].ToString();
                    }
                    else if (FParameter.SqlDbType == SqlDbType.Int)
                    {
                        FParameter.Value = Convert.ToInt32(ARow[FFieldName]);
                    }
                    else if (FParameter.SqlDbType == SqlDbType.Decimal)
                    {
                        FParameter.Value = Convert.ToDouble(ARow[FFieldName]);
                    }
                    else if (FParameter.SqlDbType == SqlDbType.DateTime)
                    {
                        FParameter.Value = Convert.ToDateTime(ARow[FFieldName]);
                    }
                }
                else
                {
                    FParameter = GetParameter("@po" + FFieldName);
                    if (FParameter != null)
                        FParameter.Value = ARow[FFieldName];
                }
            }
        }

    }
}
