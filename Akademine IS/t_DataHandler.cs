using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
//using System.Windows.Forms;
//using WG_Utilities;

namespace Akademine_IS
{
  /// <summary>
  /// ES Cinfig lentos kintamøjø tipai.</summary>
  public enum ConfigDataTypes : short
  {
    /// <summary>Text tipas</summary>
    String = 0,
    /// <summary>DataLaikas tipas</summary>
    DateTime = 1,
    /// <summary>Slankaus kablelio skaièius</summary>
    Float = 2,
    /// <summary>Sveikas skaièius</summary>
    Integer = 3,
    /// <summary>Sveikø skaièiø sàraðas </summary>
    List_Int = 4,
    /// <summary>Text eiluèiø sàraðas</summary>
    List_Char = 5,
    /// <summary>USP pavadinimø sàraðas </summary>
    List_SP = 6
  }

  // Ziurek taip pat t_StoredProc

  /// <summary>
  /// Enumeratorius, skirtas formu redagavimo rezimo nustatymui
  /// </summary>
  public enum ViewModes : short
  {
    /// <summary>Nenustatyta</summary>
    None = -1,
    /// <summary>Áraðo perþiûra</summary>
    Perziura = 0,
    /// <summary>Naujo áraðo ávedimas</summary>
    Naujas = 1,
    /// <summary>Áraðo redagavimas</summary>
    Redagavimas = 2
  }

  /// <summary>
  /// Veiksmø su operacijà bûsenos 
  /// </summary>
  public enum OpViewModes : short
  {
    /// <summary>Nenustatyta</summary>
    None = -1,
    /// <summary>Perþiûra</summary>
    Perziura = 0,
    /// <summary>Naujos operacijos ávedimas</summary>
    Naujas = 1,
    /// <summary>Operacijos redagavimas</summary>
    Redagavimas = 2,
    /// <summary>Operacijos kûneliø redagavimas</summary>
    KuneliuRedagavimas = 3,
    /// <summary>Prekiø pasirinkimas</summary>
    PrekiuPasirinkimas = 4,
    /// <summary>Operacijos kopijavimas</summary>
    Klonavimas = 5,
    /// <summary>Operacijos kûneliø perþiûra</summary>
    KuneliuPerziura = 6
  }

  #region events

  #region t_DataEventArgs
  /// <summary>
  /// Ðie argumentai leidþia perduoti duomenis
  /// Naudojami asinchroniðkai kvieèiant SQL vykdymà ið kito proceso
  /// <see cref="t_DataHandler.AsynchronousQuery(String)"/>
  /// </summary>
  public class t_DataEventArgs : EventArgs
  {
    /// <summary>
    /// DataTable objektas su duomenimis.
    /// </summary>
    public DataTable Data;
    /// <summary>
    /// Kiek graþinta eiluèiø
    /// </summary>
    public int RowsReturned = 0;
    /// <summary>
    /// Jei buvo klaida, èia bus klaidos praneðimas
    /// </summary>
    public string FailMessage = "";

    /// <summary>
    /// Inicializavimas kai klaida
    /// </summary>
    /// <param name="Failure">Klaidos tekstas</param>
    public t_DataEventArgs(string Failure)
    {
      FailMessage = Failure;
    }
    /// <summary>
    /// Inicializavimas kai sekme
    /// </summary>
    /// <param name="dta">Grazinta lentele</param>
    public t_DataEventArgs(DataTable dta)
    {
      Data = dta;
      RowsReturned = dta.Rows.Count;
    }
  }
  #endregion

  #region t_DataEventDelegate
  /// <summary>
  /// Proceduros, kvieèianèios Eventà signatûrà. Eventas Kvieèiamas ið t_DataHandler.AsynchronousQuery
  /// </summary>
  /// <param name="sender">Sending object - most probably t_DataHandler or its descendant</param>
  /// <param name="e">Event arguments, containing Returned DataTable</param>
  public delegate void t_DataEventDelegate(object sender, t_DataEventArgs e);
  #endregion

  #region t_BeforeQueryEventArgs
  /// <summary>
  /// Ðie argumentai skirti perduoti duomenis apie uþklausà prieð jos vykdymà
  /// </summary>
  public class t_BeforeQueryEventArgs : EventArgs
  {
    /// <summary>
    /// Ishkvietimo tipas, vieta ið kurios buvo kreipimasis á DB.
    /// <para></para> <!-- Jeigu norite, kad priesh lentele buutu tuschia eilute-->
    ///<list type="table">
    ///	<listheader>
    ///		<term>Reikðme</term>
    ///		<description>iðkvietimo vieta</description>
    ///	</listheader>
    ///	<item>
    ///		<term>Q_Proc</term>
    ///		<description>QueryProcedure</description>
    ///	</item>
    ///	<item>
    ///		<term>Q_Inline</term>
    ///		<description>QueryInline</description>
    ///	</item>
    ///	<item>
    ///		<term>C_Inline</term>
    ///		<description>CommandInline</description>
    ///	</item>
    ///	<item>
    ///		<term>TSP_Exec</term>
    ///		<description>t_StoredProc.Execute</description>
    ///	</item>
    ///	<item>
    ///		<term>TSP_Open</term>
    ///		<description>t_StoredProc.Open</description>
    ///	</item>
    ///</list>
    /// </summary>
    public string Source = "N/A";  // Ishkvietimo tipas //#
    // Galimos reikshmes: (Pridekite nauja tipa, jei bus nauja ishkvietimo vieta
    /// <summary>
    /// Vykdomos komandos/scripto textas
    /// </summary>
    public string Query = "";
    /// <summary>
    /// SqlCommand objektas kuris buvo vykdomas. Vykdant sql scripta ðis parametras bus "null".
    /// </summary>
    public SqlCommand Comm = null;
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="query">SQL uþklausa</param>
    /// <param name="comm">Komandos, sukurtos ið uþklausos objektas.
    /// <pre>Naudinga nagrinëjant kvieèiamos procedûros parametrus prieð kvietimà</pre></param>
    /// <param name="source">Iðkvietimo tipas vienas ið [Q_Proc,Q_Inline,C_Inline,TSP_Exec,TSP_Open]
    /// <pre>priklauso nuo funkcijos, ið kurios buvo kvieèiama uþklausa</pre></param>
    public t_BeforeQueryEventArgs(string query, SqlCommand comm, string source)
    {
      Source = source;
      Query = query;
      Comm = comm;
    }
  }
  #endregion

  #region t_AfterQueryEventArgs
  /// <summary>
  /// Ðie argumentai skirti perduoti duomenis apie uþklausà pojos vykdymo
  /// </summary>
  public class t_AfterQueryEventArgs : EventArgs
  {
    /// <summary>
    /// SQL textas kuris buvo executinamas
    /// </summary>
    public string Result = "";
    /// <summary>
    /// Pilnas uzhklausos veikimo laikas, áskaitant pakrovimà á DataTable (jei krovimas buvo).
    /// </summary>
    public TimeSpan TimeAll = TimeSpan.Zero;
    /// <summary>
    /// Duomenis pakrovimo i DataTable laikas.
    /// </summary>
    public TimeSpan TimeLoad = TimeSpan.Zero;
    /// <summary>
    /// Proceduros/scripto vykdymo laikas.
    /// </summary>
    public TimeSpan TimeExec = TimeSpan.Zero;
    /// <summary>
    /// Kiek eiluciu grazhinta    
    /// </summary>
    public int RowsReturned = 0;
    /// <summary>
    /// Kiek stulpeliu irashe
    /// </summary>
    public int ColsReturned = 0;
    /// <summary>
    /// Klaidos praneshimas 
    /// </summary>
    public string FailMessage = "";
    /// <summary>
    /// SqlCommand objektas kuris buvo vykdomas. Vykdant sql scripta ðis parametras bus "null".
    /// </summary>
    public SqlCommand comm = null;
    /// <summary>
    /// Kiek iraðø buvo apdorota, jeigu vykdyta per READER - RecordsAffected, jeigu per COMMAND.command.ExecuteNonQuery - return'as.
    /// </summary>
    public int RecordAffected = 0;

    /// <summary>
    /// Objekto konstruktorius 
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    public t_AfterQueryEventArgs(string res)
    {
      Result = res;
    }
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    /// <param name="rows">graþintas eiluèiø kiekis</param>
    public t_AfterQueryEventArgs(string res, int rows)
      : this(res)
    {
      RowsReturned = rows;
    }
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    /// <param name="dt">graþinta lentelë</param>
    public t_AfterQueryEventArgs(string res, DataTable dt)
      : this(res)
    {
      if (dt != null)
      {
        RowsReturned = dt.Rows.Count;
        ColsReturned = dt.Columns.Count;
      }
    }
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    /// <param name="dt">graþinta lentelë</param>
    /// <param name="Command">SqlCommand objektas. Patogus, norint SQL proceduros parametrus po vykdymo</param>
    public t_AfterQueryEventArgs(string res, DataTable dt, SqlCommand Command)
      : this(res, dt)
    {
      comm = Command;
    }
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    /// <param name="dt">graþinta lentelë</param>
    /// <param name="Command">SqlCommand objektas. Patogus, norint SQL proceduros parametrus po vykdymo</param>
    /// <param name="timeAll">Pilnas vykdymo laikas</param>
    public t_AfterQueryEventArgs(string res, DataTable dt, SqlCommand Command, TimeSpan timeAll)
      : this(res, dt, Command)
    {
      TimeAll = timeAll;
    }
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    /// <param name="dt">graþinta lentelë</param>
    /// <param name="Command">SqlCommand objektas. Patogus, norint SQL proceduros parametrus po vykdymo</param>
    /// <param name="recordsAffected">Kiek áraðø buvo iterpta/pakeista.</param>
    /// <param name="timeAll">Pilnas vykdymo laikas</param>
    /// <param name="timeExec">Tik vykdymo laikas</param>
    /// <param name="timeLoad">Duomenø pakrovimo i [DataTable] laikas</param>
    public t_AfterQueryEventArgs(string res, DataTable dt, SqlCommand Command, int recordsAffected, TimeSpan timeAll, TimeSpan timeExec, TimeSpan timeLoad)
      : this(res, dt, Command, timeAll)
    {
      TimeExec = timeExec;
      TimeLoad = timeLoad;
      RecordAffected = recordsAffected;
    }
    /// <summary>
    /// Objekto konstruktorius
    /// </summary>
    /// <param name="res">SQL tekstas, kuris buvo kvieèiamas</param>
    /// <param name="dt">graþinta lentelë</param>
    /// <param name="Command">SqlCommand objektas. Patogus, norint SQL proceduros parametrus po vykdymo</param>
    /// <param name="recordsAffected">Kiek áraðø buvo iterpta/pakeista.</param>
    /// <param name="timeAll">Pilnas vykdymo laikas</param>
    /// <param name="timeExec">Tik vykdymo laikas</param>
    /// <param name="timeLoad">Duomenø pakrovimo i [DataTable] laikas</param>
    /// <param name="FailMSG">Klaidos praneðimas, ávykus klaidai</param>
    public t_AfterQueryEventArgs(string res, DataTable dt, SqlCommand Command, int recordsAffected, TimeSpan timeAll, TimeSpan timeExec, TimeSpan timeLoad, string FailMSG)
      : this(res, dt, Command, 0, timeAll, timeExec, timeLoad)
    {
      FailMessage = FailMSG;
      RecordAffected = recordsAffected;
    }
    /// <summary>
    /// Graþina true, jei ávyko klaida
    /// <pre>Vaikimo principas: tiesiog patikrina, ar Klaidos praneðimas nenulinis</pre>
    /// </summary>
    public bool Failed
    {
      get
      {
        return FailMessage.Length > 0;
      }
    }
  }
  #endregion

  #region t_BeforeQueryEventDelegate
  /// <summary>
  /// Event raising procedure signature. This type of handler is raised, when AsynchronousQuery is called
  /// </summary>
  /// <param name="sender">Sending object - most probably t_DataHandler or its descendant</param>
  /// <param name="e">Event arguments, containing query</param>
  public delegate void t_BeforeQueryEventDelegate(object sender, t_BeforeQueryEventArgs e);
  #endregion

  #region t_AfterQueryEventDelegate
  /// <summary>
  /// Event raising procedure signature. This type of handler is raised, after Query completed
  /// </summary>
  /// <param name="sender">Sending object - most probably t_DataHandler or its descendant</param>
  /// <param name="e">Event arguments, containing query, result count and possibly errors</param>
  public delegate void t_AfterQueryEventDelegate(object sender, t_AfterQueryEventArgs e);
  #endregion

  #endregion //events

  /// <summary>
  /// t_DataHandler klase. Sukurimas reikalauja SqlConnection arba ConnectionString objektu
  /// Klase sukurta, kad apdoroti duomenu operacijas
  /// Sukuria ir laiko aktyvia SqlConnection
  /// </summary>
  public class t_DataHandler
  {
    #region variables
    /// <summary>
    /// Ivyksta pasibaigus AsynchronousQuery() vykdymui.
    /// <pre>Kol kas nenaudojamas.</pre>
    /// </summary>
    public event t_DataEventDelegate OnCompleteAsyncQuery = null;
    /// <summary>
    /// Ivyksta pries SQL operacijos vykdyma
    /// </summary>
    public event t_BeforeQueryEventDelegate OnBeforeQuery = null;
    /// <summary>
    /// Ivyksta po SQL operacijos vykdymo
    /// </summary>
    public event t_AfterQueryEventDelegate OnAfterQuery = null;
    /// <summary>
    /// Taimautas SQL komandos vykdymui. Default 1800 = 30 min.
    /// </summary>
    public int COMMAND_TIMEOUT = 1800;
    private ArrayList FList_ArLeidziamaRedaguotiId = new ArrayList();
    #endregion //variables



    #region properties
    private long m_LastOpTicks;
    /// <summary>
    /// Paskutinës SQL Operacijos vykdymo laikas Tick'ais(100-nanosec intervalais). ReadOnly
    /// </summary>
    public long LastOperationTicks
    {
      get
      {
        return m_LastOpTicks;
      }
    }
        public bool HideError = false;

    /// <summary>
    /// Paskutinës SQL Operacijos Vykdymo laikas, kaip TimeSpan. ReadOnly
    /// </summary>
    public TimeSpan LastOperationTime
    {
      get
      {
        return TimeSpan.FromTicks(m_LastOpTicks);
      }
    }

    private long m_MaxRecords = 0;
    /// <summary>
    /// Áraðø kiekis graþinamas ið bazës ávykdþiøs uþklausà. Jei 0 graþins visus
    /// </summary>
    public long MaxRecords
    {
      get
      {
        return m_MaxRecords;
      }
      set
      {
        m_MaxRecords = (value > 0) ? value : 0;
      }
    }

    private long m_NotReadedRecords = 0;
    /// <summary>
    /// Áraðø kiekis negraþintas ið bazës. Jei daugiau uþ 0 reiðkia kad buvo nurodytas ribotas áraðø kiekio graþinimas
    /// </summary>
    public long NotReadedRecords
    {
      get
      {
        return m_NotReadedRecords;
      }
    }

#if (OLD_CONNECTION)
    /// <summary>
    /// privatus kintamasis - Sql Connection'as, laikomas objekte
    /// <pre>kad nekurti naujo kas kart kvieèiant procedûrà</pre>
    /// <see cref="t_DataHandler.Connection"/>
    /// </summary>
    SqlConnection m_Connection = null;
#endif

        /// <summary>
        /// Connection string - laikomas objekte
        /// privatus kintamasis, kad kreiptis naudokite "ConnectionString"
        /// <see cref="t_DataHandler.ConnectionString"/>
        /// </summary>
        string m_ConnString = ""; /*"Data Source=SRV-TESTAVIMUI;Initial Catalog=SK_ALX_Nuoma_Aktima;"//#
        + " User Id=sa; Password=0109;";*///#
    /// <summary>
    /// Graþina Connection string'à. Default connection string:
    /// Data Source=SRV-TESTAVIMUI;Initial Catalog=SK_ALX_Nuoma_Aktima; User Id=sa; Password=0109;
    /// Pakeitus ðá property'sà, susikuria naujas Connection'as, ir bando prisijungti
    /// </summary>
    public virtual string ConnectionString
    {
      get
      {
        return m_ConnString;
      }
      set
      {
        m_ConnString = value;
#if (OLD_CONNECTION)
        if (m_Connection == null)
          m_Connection = new SqlConnection(m_ConnString);
        if (m_Connection.State == ConnectionState.Open)
        {
          m_Connection.Close();
          m_Connection.ConnectionString = m_ConnString;
          m_Connection.Open();
        }
#endif
      }
    }
    /// <summary>
    /// Sql Connection'as. Naudojamas viduje
    /// <pre>Susikuria nustaèius ConnectionStringà, arba konstruktoriuje</pre>
    /// </summary>
    public virtual SqlConnection Connection
    {
      get
      {
#if (OLD_CONNECTION)
        return m_Connection;
#else
        SqlConnection c = new SqlConnection(m_ConnString);
        c.Open();
        return c;
#endif
      }
    }
    #endregion //properties

    #region Constructors

    //Kazkas ne taip su Destruktorium !
    //~t_DataHandler()
    //{
    //  if (m_Connection != null)
    //    if (m_Connection.State == ConnectionState.Open)
    //      m_Connection.Close();
    //}

    /// <summary>
    /// Klases konstruktorius. 
    /// Atidaromas einamasis objekto connection'as pagal
    /// ConnString'a ið private kintamojo m_Connection.
    /// </summary>
    public t_DataHandler()
    {
#if (OLD_CONNECTION)
      m_Connection = new SqlConnection(m_ConnString);
      m_Connection.StateChange += new StateChangeEventHandler(DoSettings);
      m_Connection.Open();
#endif
            if (m_ConnString.Trim().Equals(""))
            {
                
            }
    }

        /// <summary>
        /// Klases konstruktorius. 
        /// Atidaromas einamasis objekto connection'as pagal perduodama ConnString kintamaji.
        /// Pvz.: "Data Source=SrvVardas;Initial Catalog=DbVardas;User Id=Vartotojas; Password=slaptazodis;"
        /// </summary>
        /// <param name="ConnString">pinlas connection string'as</param>
        public t_DataHandler(string ConnString, int paramType = 0)
    {
            if (paramType == 0)
            {
                m_ConnString = ConnString;
            }
            else
            {
                if (!ConnString.Trim().Equals("") && m_ConnString.Trim().Equals(""))
                {
                    string[] ini = File.ReadAllLines(ConnString);
                    m_ConnString = ini[0];
                }
            }
#if (OLD_CONNECTION)
      m_Connection = new SqlConnection(m_ConnString);
      m_Connection.StateChange += new StateChangeEventHandler(DoSettings);
      m_Connection.Open();
#endif
        }

    /// <summary>
    /// Klases konstruktorius. 
    /// Einamasis objekto connection'as bus parametru perduotas SqlConnection objektas.
    /// </summary>
    /// <param name="sql">SqlConnection objektas</param>
    public t_DataHandler(SqlConnection sql)
    {
#if (OLD_CONNECTION)
      m_Connection = sql;
      m_Connection.StateChange += new StateChangeEventHandler(DoSettings);
#endif
      m_ConnString = sql.ConnectionString;
    }

    /// <summary>
    /// Klases konstruktorius. 
    /// Atidaromas einamasis objekto connection'as pagal perduotus parametrus.
    /// </summary>
    /// <param name="Server">DB Serverio vardas</param>
    /// <param name="DataBase">Duomenu bazes vardas</param>
    /// <param name="User">vartotojo vardas</param>
    /// <param name="Pass">slaptaþodis</param>
    public t_DataHandler(string Server, string DataBase, string User, string Pass, string AMinPoolSize, string AMaxPoolSize, string ATimeOut)
    {
      m_ConnString = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";User Id=" + User //#
          + "; Password=" + Pass + ";";//#
      Pass = ""; //#
      //ConnectionString = m_ConnString;
#if (OLD_CONNECTION)
      //Sitas kodas pakeistas zemiau esanciu, kuriame numatomas Pool-o dydis ir timeout-as
      //m_Connection = new SqlConnection(m_ConnString);
      //m_Connection.StateChange += new StateChangeEventHandler(DoSettings);
      //m_Connection.Open();
      m_Connection = new SqlConnection();
      try
      {
        m_Connection.ConnectionString = m_ConnString; //"Min Pool Size=" + AMinPoolSize + ";Max Pool Size=" + AMaxPoolSize + ";Connect Timeout=" + /*ATimeOut*/ "300" + ";Context Connection=false";
        m_Connection.StateChange += new StateChangeEventHandler(DoSettings);
        m_Connection.Open();


                
      }
      catch (Exception x)
      {
                Console.WriteLine("Nepavyko prisijungti prie duomenø bazës '" + Server + "-->" + DataBase +"'." + Environment.NewLine + "Klaida: " + x.Message);
        //if (m_Connection.State != ConnectionState.Closed) 
        //  m_Connection.Close();
        //m_Connection.ConnectionString = m_ConnString + "Pooling=false;Connect Timeout=40;";
        //m_Connection.StateChange += new StateChangeEventHandler(DoSettings);
        //m_Connection.Open();
      }
#endif
    }

    /// <summary>
    /// Ávykdo veiksmus, kuriuos reikia vykdyti prisijungiant prie Skaitos DB
    /// Kvieèia uspiLogin
    /// nustato ANSI_WARNING'us ir pan.
    /// </summary>
    public void DoSettings(
#if (OLD_CONNECTION)
      object sender, StateChangeEventArgs e
#endif
)
    {
#if (OLD_CONNECTION)
      if (e.CurrentState == ConnectionState.Broken)
      {
        m_Connection.Open();
        return;
      }
      if (!(
           ((e.OriginalState == ConnectionState.Broken) ||
            (e.OriginalState == ConnectionState.Closed) ||
            (e.OriginalState == ConnectionState.Connecting)
           ) &&
           (e.CurrentState == ConnectionState.Open)
          ))
        return;
#endif
      try
      {
        string ops =
           "SET CONCAT_NULL_YIELDS_NULL OFF\r\n" +  //#
           "SET IMPLICIT_TRANSACTIONS   OFF\r\n" +  //#
           "SET QUOTED_IDENTIFIER       OFF\r\n" +  //#
           "SET CURSOR_CLOSE_ON_COMMIT  OFF\r\n" +  //#
           "SET ANSI_WARNINGS           OFF\r\n" +  //#
           "SET ANSI_PADDING            OFF\r\n" +  //#
           "SET ANSI_NULLS              OFF\r\n" +  //#
           "SET ARITHABORT              ON";        //#
        //
        // Ateityje bus pakeista i nuskaityma is txt failo ar kazhkaip kitaip.
        //
        this.CommandInline(ops);
        //
      }
      // Backward Compatibility
      catch
      {
        throw;
      }
    }
    #endregion

    #region Connection properties
    /// <summary>
    /// Naudojama Connection String'o Parse'inimui
    /// <pre>Connection Stringe laikomos poros pavidalu "Key=Value". Paduodant Key graþinamas Value</pre>
    /// </summary>
    /// <param name="Key">Raktas connection string'e</param>
    /// <returns>Reikðmë, susijusi su raktu</returns>
    private string GetConnStrToken(string Key)
    {
      Key = Key.ToLower();
      string s = m_ConnString.ToLower();
      int i = s.IndexOf(Key);
      if (i < 0) return "";
      s = m_ConnString.Substring(i + Key.Length, s.Length - i - Key.Length);
      i = s.IndexOf(";");
      if (i > 0)
        s = s.Substring(0, i).Trim();
      i = s.IndexOf("=");
      if (i >= 0)
        s = s.Substring(i + 1, s.Length - i - 1).Trim();
      return s;
    }
    /// <summary>
    /// Graþina serverá ið Connection string'o
    /// </summary>
    public string Server
    {
      get
      {
        return GetConnStrToken("data source").ToUpper();//#
      }
    }
    /// <summary>
    /// Graþina DB ið Connection string'o
    /// </summary>
    public string DB
    {
      get
      {
        return GetConnStrToken("initial catalog");//#
      }
    }
    /// <summary>
    /// Graþina prisijungimo vartotojá ið Connection string'o
    /// </summary>
    public string DBUser
    {
      get
      {
        return GetConnStrToken("user id");//#
      }
    }
    #endregion

    /// <summary>
    /// Dabar nenaudojama. Skirta kviesti asinchroniðkai ið kit proceso. Pabaigus SQL vykdymà kvieèia Eventà "OnQueryCompleted"
    /// <pre>Á ðá Event'à patalpina graþintà lentelæ (arba klaidos praneðimà)</pre>
    /// <pre>Grazhintu duomenu DataTable vardas bus ASQ_Table</pre>
    /// </summary>
    /// <param name="SQLText">SQL uþklausa</param>
    public virtual void AsynchronousQuery(string SQLText)
    {
      AsynchronousQuery(SQLText, "ASQ_Table");//#
    }
    /// <summary>
    /// Dabar nenaudojama. Skirta kviesti asinchroniðkai ið kit proceso. Pabaigus SQL vykdymà kvieèia Eventà "OnQueryCompleted"
    /// <pre>Á ðá Event'à patalpina graþintà lentelæ (arba klaidos praneðimà)</pre>
    /// </summary>
    /// <param name="SQLText">SQL uþklausa</param>
    /// <param name="tableName">DataTable vardas</param>
    public virtual void AsynchronousQuery(string SQLText, string tableName)
    {
      DateTime dt1 = DateTime.Now;

      DataTable table = new DataTable(tableName);
#if (!OLD_CONNECTION)
      SqlConnection m_Connection = Connection;
#endif

      SqlCommand command = m_Connection.CreateCommand();
      command.CommandText = SQLText;

      try
      {
        if (m_Connection.State != ConnectionState.Open)
          m_Connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        //
        table = ReaderToTable(reader, tableName);
        // reader.Close(); <-- Jau uzhdarytas
        //
        m_LastOpTicks = DateTime.Now.Ticks - dt1.Ticks;
      }
      catch (Exception x)
      {
        if (OnCompleteAsyncQuery != null)
          OnCompleteAsyncQuery(this, new t_DataEventArgs("[t_DataHandler.QueryInline] Klaida vykdant " + SQLText + " \r\n " + x.Message));
      }
      if (OnCompleteAsyncQuery != null)
        OnCompleteAsyncQuery(this, new t_DataEventArgs(table));
#if (!OLD_CONNECTION)
      m_Connection.Close();
#endif
    }

    /// <summary>
    /// Kvieèiami prie Evento "OnBeforeQuery" prikabinti veiksmai.
    /// <pre>Sukurta suderinimui su t_StoredProc.</pre>
    /// </summary>
    /// <param name="sender">Kvietimo objektas</param>
    /// <param name="x">Argumentai</param>
    public void CallOnBeforeQuery(object sender, t_BeforeQueryEventArgs x)
    {
      if (OnBeforeQuery != null)
        OnBeforeQuery(sender, x);
    }
    /// <summary>
    /// Kvieèiami prie Evento "OnAfterQuery" prikabinti veiksmai
    /// <pre>Sukurta suderinimui su t_StoredProc.</pre>
    /// </summary>
    /// <param name="sender">Kvietimo objektas</param>
    /// <param name="x">Argumentai</param>
    public void CallOnAfterQuery(object sender, t_AfterQueryEventArgs x)
    {
      if (OnAfterQuery != null)
        OnAfterQuery(sender, x);
    }

    /// <summary>
    /// Kvieèiami prie Evento "OnCompleteAsyncQuery" prikabinti veiksmai
    /// <pre>Sukurta suderinimui su t_StoredProc.</pre>
    /// </summary>
    /// <param name="sender">Kvietimo objektas</param>
    /// <param name="x">Argumentai</param>
    public void CallOnCompleteAsyncQuery(object sender, t_DataEventArgs x)
    {
      if (OnCompleteAsyncQuery != null)
        OnCompleteAsyncQuery(sender, x);
    }

    /// <summary>
    /// Vykdoma SQL komanda graþinant rezultatà (DataTable) ið DB.
    /// <pre>Graþinamos DataTable vardas bus tableInline</pre>
    /// </summary>
    /// <param name="SQLText">SQL komanda: SELECT, EXEC SP ir t.t.</param>
    /// <returns>DataTable kaip vykdymo rezultatas.</returns>
    public virtual DataTable QueryInline(string SQLText)
    {
      return (QueryInline(SQLText, "tableInline"));
    }

    /// <summary>
    /// Vykdoma SQL komanda graþinant rezultatà(DataTable).
    /// </summary>
    /// <param name="SQLText">SQL komanda: SELECT, EXEC SP ir t.t.</param>
    /// <param name="tableName">graþinamos DataTable vardas</param>
    /// <returns>DataTable kaip vykdymo rezultatas.</returns>
    /*
     * Ivykdzius uzhklausa, jeigu buvo kviesta USP. Pvz.: EXEC USP_Test @piPirmas = 1, @piAntras = "Textas"
     * Nuimti parametrus per command.Parameters neimanoma!
     * 
     * t_BeforeQueryEventArgs kviechiamas su tuschiu [paramsInfo] 
     *
    */
    public virtual DataTable QueryInline(string SQLText, string tableName)
    {
      DataTable table = new DataTable();

      //t_HandlerSingleton.LogHandler.AddEntry("Query", SQLText);//#
      if (OnBeforeQuery != null)
        OnBeforeQuery(this, new t_BeforeQueryEventArgs(SQLText, null, "Q_Inline"));//#

#if (!OLD_CONNECTION)
      SqlConnection m_Connection = Connection;
#endif
      DateTime timeStart = DateTime.Now;
      DateTime timeTemp = DateTime.Now;
      TimeSpan timeAll = TimeSpan.Zero;
      TimeSpan timeExec = TimeSpan.Zero;
      TimeSpan timeLoad = TimeSpan.Zero;
      //
      SqlCommand command = m_Connection.CreateCommand();
      command.CommandText = SQLText;
      int recAffected = 0;
      //
      try
      {
        if (m_Connection.State != ConnectionState.Open)
          m_Connection.Open();
        SqlDataReader reader;
        command.CommandTimeout = COMMAND_TIMEOUT;
        command.Prepare();
        timeTemp = DateTime.Now;

        try
        {
          reader = command.ExecuteReader();
        }
        catch (InvalidOperationException ex)
        {
#if (!OLD_CONNECTION)
          m_Connection.Close();
#endif
          //There is already an open DataReader associated with this Command which must be closed first
          if (ex.Message.StartsWith("Pirmà reikia uþdaryti DataReader, kuris yra susietas su ðia komanda"))
            return null;
          else
            throw ex;
        }
        // Kiek laiko vykde
        timeExec = DateTime.Now.Subtract(timeTemp);
        timeTemp = DateTime.Now;
        //
        table = ReaderToTable(reader, tableName);
        // Kiek laiko krove
        timeLoad = DateTime.Now.Subtract(timeTemp);
        recAffected = reader.RecordsAffected;
        // reader.Close();   <-- Jau uzhdarytas
        //
        timeAll = DateTime.Now.Subtract(timeStart);
        m_LastOpTicks = timeAll.Ticks;
        if (OnAfterQuery != null)
        {
          int Count = (table == null) ? 0 : (table.Rows.Count);
          //
          OnAfterQuery(this, new t_AfterQueryEventArgs(SQLText, table, command, recAffected, timeAll, timeExec, timeLoad));
        }
      }
      catch (SqlException x)
      {
#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
        throw x;
      }
      catch (Exception x)
      {
#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
        //t_HandlerSingleton.LogHandler.AddEntry("QueryError", SQLText);//#
        if (OnAfterQuery != null)
          OnAfterQuery(this, new t_AfterQueryEventArgs(SQLText, null, null, recAffected, timeAll, timeExec, timeLoad, x.Message));
                if (!HideError)
                {
                    throw new Exception("[t_DataHandler.QueryInline] Klaida vykdant " + SQLText + " \r\n " + x.Message, x);
                }
      }
#if (!OLD_CONNECTION)
      m_Connection.Close();
#endif
      return table;
    }

    /// <summary>
    /// Vykdoma SQL komanda negraþinant rezultato ið DB.
    /// </summary>
    /// <param name="SQLText">SQL sakinys</param>
    public virtual void CommandInline(string SQLText)
    {
      if (OnBeforeQuery != null)
        OnBeforeQuery(this, new t_BeforeQueryEventArgs(SQLText, null, "C_Inline"));//#

#if (!OLD_CONNECTION)
      SqlConnection m_Connection = Connection;
#endif
      //
      DateTime timeStart = DateTime.Now;
      DateTime timeTemp = DateTime.Now;
      TimeSpan timeAll = TimeSpan.Zero; ;
      TimeSpan timeExec = TimeSpan.Zero; ;
      TimeSpan timeLoad = TimeSpan.Zero; ;
            //
            //t_HandlerSingleton.LogHandler.AddEntry("Query", SQLText);//#
            using (SqlCommand command = m_Connection.CreateCommand())
            {
                command.CommandTimeout = COMMAND_TIMEOUT;
                command.CommandText = SQLText;
                timeTemp = DateTime.Now;
                try
                {
                    if (m_Connection.State != ConnectionState.Open)
                        m_Connection.Open();

                    int recAffected = command.ExecuteNonQuery();
                    //
                    timeExec = DateTime.Now.Subtract(timeTemp);
                    //
                    timeAll = DateTime.Now.Subtract(timeStart);
                    m_LastOpTicks = timeAll.Ticks;
                    if (OnAfterQuery != null)
                        OnAfterQuery(this, new t_AfterQueryEventArgs(SQLText, null, command, recAffected, timeAll, timeExec, TimeSpan.Zero));
                }
                catch (Exception x)
                {

#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
                    //t_HandlerSingleton.LogHandler.AddEntry("QueryError", SQLText);//#
                    if (!HideError)
                    {
                        throw new Exception("[t_DataHandler.CommandInline] Klaida vykdant " + SQLText + " \r\n " + x.Message, x);
                    }
                }
            }
#if (!OLD_CONNECTION)
      m_Connection.Close();
#endif
    }

    /// <summary>
    /// Nurodykite ViewName. Ekvivalentiska QueryInline("SELECT * FROM "+Name)
    /// </summary>
    /// <param name="Name">Kvieciamo View'o pavadinimas</param>
    /// <returns>Lentelæ, graþinta po vykdymo</returns>
    public virtual DataTable QueryView(string Name)
    {
      return QueryTable(Name);
    }
    /// <summary>
    /// Nieko nesiskiria nuo QueryView. Ekvivalentiska QueryInline("SELECT * FROM " + Name)
    /// </summary>
    /// <param name="Name">Kvieèiamos lentelës pavadinimas</param>
    /// <returns>Lentelæ graþinta po vykdymo</returns>
    public virtual DataTable QueryTable(string Name)
    {
      return QueryInline("SELECT * FROM " + Name);
    }

    /// <summary>
    /// Si funkcija buvo skirta kviesti procedura, kai toji grazina kazkokias reiksmes parametruose
    /// <pre>Turi buti suformuotas parametras - masyvas is SqlParameter tipo reiksmiu.</pre>
    /// <pre>DataTable vardas bus QP_Table.</pre>
    /// </summary>
    /// <param name="Name">Procedure Name, e.g. "usp_SampleTableData"</param>
    /// <param name="coll"> SqlParameter reiksmiu masyvas (pvz. SqlParameter[] params = new SqlParameter[arrayLength])
    /// I ji grazinamos reiksmes, kai procedura baigia darba</param>
    /// <returns> Lentele, kuria grazina procedura, jei tokia yra</returns>
    public virtual DataTable QueryProcedure(string Name, ref SqlParameter[] coll)
    {
      return QueryProcedure(Name, ref coll, "QP_Table");
    }

    /// <summary>
    /// Si funkcija buvo skirta kviesti procedura, kai toji grazina kazkokias reiksmes parametruose
    /// Turi buti suformuotas parametras - masyvas is SqlParameter tipo reiksmiu
    /// </summary>
    /// <param name="Name">Procedure Name, e.g. "usp_SampleTableData"</param>
    /// <param name="coll"> SqlParameter reiksmiu masyvas (pvz. SqlParameter[] params = new SqlParameter[arrayLength])
    /// I ji grazinamos reiksmes, kai procedura baigia darba</param>
    /// <param name="tableName">DataTable vardas</param>
    /// <returns> Lentele, kuria grazina procedura, jei tokia yra</returns>
    public virtual DataTable QueryProcedure(string Name, ref SqlParameter[] coll, string tableName)
    {
      DateTime timeStart = DateTime.Now;
      DateTime timeTemp = DateTime.Now;
      TimeSpan timeAll = TimeSpan.Zero;
      TimeSpan timeExec = TimeSpan.Zero;
      TimeSpan timeLoad = TimeSpan.Zero;
      //
      DataTable table = new DataTable();
      //
      //t_HandlerSingleton.LogHandler.AddEntry("QueryProcedure", Name); //#
      //
#if (!OLD_CONNECTION)
      SqlConnection m_Connection = Connection;
#endif

      SqlCommand comm = m_Connection.CreateCommand();
      comm.CommandText = Name;
      comm.CommandType = CommandType.StoredProcedure;
      //
      SqlCommandBuilder.DeriveParameters(comm);
      comm.Parameters.RemoveAt(0);
      // Uzh'null'iname parametrus
      for (int i = 0; i < comm.Parameters.Count; i++)
        comm.Parameters[i].Value = DBNull.Value;
      //
      // Parametrams kurie buvo perduoti i procedura.
      // Kreipiames i parametra pagal varda, nes perduotu parametru eilishkumas
      // gali nesutapti su ishtrauktais pagal metoda 
      for (int i = 0; i < coll.Length; i++)
        comm.Parameters[coll[i].ParameterName].Value = coll[i].Value;
      //
      if (OnBeforeQuery != null)
        OnBeforeQuery(this, new t_BeforeQueryEventArgs("EXEC " + comm.CommandText, comm, "Q_Proc"));//#
      //
      int recAffected = 0;
      try
      {
        if (m_Connection.State != ConnectionState.Open)
          m_Connection.Open();
        SqlDataReader reader;
        comm.CommandTimeout = COMMAND_TIMEOUT;
        comm.Prepare();
        //
        timeTemp = DateTime.Now;
        try
        {
          reader = comm.ExecuteReader();
        }
        catch (InvalidOperationException ex)
        {
#if (!OLD_CONNECTION)
          m_Connection.Close();
#endif
          if (ex.Message.StartsWith("There is already an open DataReader associated with this Command which must be closed first"))//#
            return null;
          else
            throw ex;
        }
        // Kiek vykde
        timeExec = DateTime.Now.Subtract(timeTemp);
        //
        timeTemp = DateTime.Now;
        table = ReaderToTable(reader, tableName);
        // Kiek krove
        timeLoad = DateTime.Now.Subtract(timeTemp);
        //
        recAffected = reader.RecordsAffected;

        if (coll.Length != comm.Parameters.Count)
        {
          try
          {
            coll = new SqlParameter[comm.Parameters.Count];
          }
          catch
          { ; }
        }
        try
        {
          comm.Parameters.CopyTo(coll, 0);// CopyTo(coll, 0);
        }
        catch
        { ; }
        timeAll = DateTime.Now.Subtract(timeStart);
        m_LastOpTicks = timeAll.Ticks;
        if (OnAfterQuery != null)
          OnAfterQuery(this, new t_AfterQueryEventArgs(Name, table, comm, recAffected, timeAll, timeExec, timeLoad));
      }
      catch (SqlException x)
      {
#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
        throw x;
      }
      catch (Exception x)
      {
#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
        //t_HandlerSingleton.LogHandler.AddEntry("QueryError", Name);//#
        if (OnAfterQuery != null)
          OnAfterQuery(this, new t_AfterQueryEventArgs(Name, null, null, recAffected, timeAll, timeExec, timeLoad, "Klaida vykdant " + Name + ": " + x.Message));
        throw new Exception("[t_DataHandler.QueryInline] Klaida vykdant procedura " + Name + " \r\n " + x.Message, x);
      }
#if (!OLD_CONNECTION)
      m_Connection.Close();
#endif
      return table;
    }

    /// <summary>
    /// Isvalomi Eventai "OnBeforeQuery"
    /// Atskira funkcija sukurta todel, kad C# tai galima padaryti tik klases viduje
    /// </summary>
    public void ClearBeforeEvents()
    {
      OnBeforeQuery = null;
    }

    /// <summary>
    /// Isvalomi Eventai "OnAfterQuery"
    /// Atskira funkcija sukurta todel, kad C# tai galima padaryti tik klases viduje
    /// </summary>
    public void ClearAfterEvents()
    {
      OnAfterQuery = null;
    }

    #region ReaderToTable : protected virtual DataTable ReaderToTable(SqlDataReader dr)

    /// <summary>
    ///  SqlDataReader duomenis permeta á DataTable.
    /// </summary>
    /// <param name="tableName">>Graþinamos DataTable vardas</param>
    /// <param name="dr">SqlDataReader. Daþniausiai SqlCommand.ExecuteReader() metodo rezultatas.</param>
    /// <returns>DataTable su duomenimis</returns>
    public virtual DataTable ReaderToTable(SqlDataReader dr, string tableName)
    {
      string[] Empty = { };
      return ReaderToTable(tableName, dr, Empty);
    }

    /// <summary>
    ///  SqlDataReader duomenis permeta á DataTable.
    ///  <pre>Gràþinamos DataTable vardas bus tableRS</pre>
    /// </summary>
    /// <param name="dr">SqlDataReader. Daþniausiai SqlCommand.ExecuteReader() metodo rezultatas.</param>
    /// <returns>DataTable su duomenimis</returns>
    public virtual DataTable ReaderToTable(SqlDataReader dr)
    {
      string[] Empty = { };
      return ReaderToTable("tableRS", dr, Empty);//#
    }

    #endregion

    /// <summary>
    /// SqlDataReader duomenis permeta á DataTable
    /// <pre>Gautas DataTable turi tik columns'us apibrëþtus masyve Columns</pre>
    /// <pre>Kai Columns = null - graþinami VISI columns'ai ið SqlDataReader'io</pre>
    /// <pre>Gràþinamos DataTable vardas bus tableRS</pre>
    /// </summary>
    /// <param name="dr">SqlDataReader. Daþniausiai SqlCommand.ExecuteReader() metodo rezultatas.</param>
    /// <param name="Columns">Columns'ø pavadinimø masyvas. Raidþiø dydis nesvarbus (Case ignored).</param>
    /// <returns>DataTable su duomenimis</returns>
    public virtual DataTable ReaderToTable(SqlDataReader dr, string[] Columns)
    {
      return ReaderToTable("tableRSC", dr, Columns);//#
    }

    #region ReaderToTable : protected virtual DataTable ReaderToTable(string tableName, SqlDataReader dr, string[] Columns)
    /// <summary>
    /// SqlDataReader duomenis permeta á DataTable
    /// <pre>Gautas DataTable turi tik columns'us apibrëþtus masyve Columns</pre>
    /// <pre>Kai Columns = null - graþinami VISI columns'ai ið SqlDataReader'io</pre>
    /// </summary>
    /// <param name="tableName">SqlDataReader su duomenimis</param>
    /// <param name="dr">SqlDataReader. Daþniausiai SqlCommand.ExecuteReader() metodo rezultatas.</param>
    /// <param name="Columns">Columns'ø pavadinimø masyvas. Nesvarbus raidþiø dydis(Case ignored)</param>
    /// <returns>DataTable su duomenimis</returns>
    public virtual DataTable ReaderToTable(string tableName, SqlDataReader dr, string[] Columns)
    {
      try
      {
        if (dr == null)
          throw new Exception("Parameter SqlDataReader dr is null");
        DataTable dt = new DataTable(tableName);
        long wId;
        wId = 0;

        int[] ColIndexes = { };
        // Calculating required indexes once is faster
        // than seeking column by name every time.
        ColIndexes = PopulateColIndexes(Columns, dr);
        //
        // Sukuriame DataTable 
        //
        for (int i = 0; i < ColIndexes.Length; i++)
        {
          if (ColIndexes[i] < 0) // Tegul paaishkina Andrejus!
          {
            dt.Columns.Add(Columns[i] + "_NODATA");
            dt.Columns[i + 1].DataType = typeof(string);
          }
          else
          {
            string Name = dr.GetName(ColIndexes[i]);
            // this decreases performance
            while (dt.Columns.Contains(Name))
              Name = Name + "_";
            // ToUpper(), kad tiktu layoutai
            dt.Columns.Add(Name.ToUpper());
            dt.Columns[i].DataType = dr.GetFieldType(ColIndexes[i]);
          }
        }

        // Nustatau I#D lauko indeksa - paskutinis. dt.Columns.Count, nes laukai indeksuojami nuo 0'lio.
        int idIndex = dt.Columns.Count;
        // Pridedu musu pseudo Inkrement lauka.
        dt.Columns.Add("I#D", typeof(long));
        //

        m_NotReadedRecords = 0;

        while (dr.Read())
        {
          if ((m_MaxRecords > 0) ? dt.Rows.Count < m_MaxRecords : true)
          {
            DataRow row = dt.NewRow();
            //wId = ++wId;
            row[idIndex] = wId++;
            for (int i = 0; i < ColIndexes.Length; i++)
            {
              if (ColIndexes[i] >= 0)
                row[i] = dr.GetValue(ColIndexes[i]);
            }
            dt.Rows.Add(row);
            row = null;
          }
          else m_NotReadedRecords++;
        }
        //
        dr.Close();
        dr.Dispose();
        return dt;
      }
      catch (Exception x)
      {
        throw new Exception("\r\n[t_DataHandler.ReaderToTable] Klaida: " + x.Message, x);
      }
    }
    #endregion

    /// <summary>
    /// Atlieka SQL uzklausa, o jos rezultata - lentele, suraso i nurodyta byla
    /// </summary>
    /// <param name="SQLText">SQL uzklausa</param>
    /// <param name="FileName">Iseities bylos pavadinimas</param>
    public void QueryInlineToFile(string SQLText, string FileName)
    {
      DateTime dt1 = DateTime.Now;
      DataTable table = new DataTable();

#if (!OLD_CONNECTION)
      SqlConnection m_Connection = Connection;
#endif

      SqlCommand command = m_Connection.CreateCommand();
      command.CommandText = SQLText;

      try
      {
        if (m_Connection.State != ConnectionState.Open)
          m_Connection.Open();
        SqlDataReader reader;
        command.CommandTimeout = COMMAND_TIMEOUT;
        command.Prepare();

        reader = command.ExecuteReader();

        ReaderToFile(reader, FileName);

        m_LastOpTicks = DateTime.Now.Ticks - dt1.Ticks;
      }
      catch (SqlException x)
      {
#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
        throw x;
      }
      catch (Exception x)
      {
#if (!OLD_CONNECTION)
        m_Connection.Close();
#endif
        throw new Exception("[t_DataHandler.QueryInline] Klaida vykdant " + SQLText + " \r\n " + x.Message, x);
      }
#if (!OLD_CONNECTION)
      m_Connection.Close();
#endif
    }

    /// <summary>
    /// Konvertuoja Data i Delphi uzkoduota (Float skaiciumi) data
    /// </summary>
    /// <param name="ADate">Data konvertavimui</param>
    /// <returns>Delphi stiliumi uzkoduota data(Float skaicius string pavidalu)</returns>
    private string CountDate(DateTime ADate)
    {
      DateTime StartDate = new DateTime(1899, 12, 30, 0, 0, 0);
      TimeSpan sv = ADate - StartDate;
      int svint = (int)sv.TotalDays;
      DateTime dtt = new DateTime(ADate.Year, ADate.Month, ADate.Day);
      TimeSpan tr = ADate - dtt;
      int trint = (int)(tr.TotalSeconds * 0.000011574074074);
      return svint.ToString() + "." + trint.ToString();
    }

    #region ReaderToFile : protected virtual DataTable ReaderToFile(SqlDataReader dr, string FileName)
    /// <summary>
    /// Konvertuoja SqlDataReader á byla (failà)
    /// Gautas DataTable turi tik columns'us apibrëþtus masyve Columns
    /// Kai Columns yra null - graþinami VISI columns'ai
    /// </summary>
    /// <param name="dr">SqlDataReader su data </param>
    /// <param name="FileName">Failo vardas (pilnas kelias) á kurá bus iraðyti duomenys.</param>
    /// <returns>iðgautas DataTable</returns>
    public virtual DataTable ReaderToFile(SqlDataReader dr, string FileName)
    {
      try
      {
        if (dr == null)
          throw new Exception("Parameter SqlDataReader dr is null");
        DataTable dt = new DataTable("Rows");
        //long wId;
        //wId = 0;

        int[] ColIndexes = { };
        // Calculating required indexes once is faster
        // than seeking column by name every time.
        string[] Columns = { };
        ColIndexes = PopulateColIndexes(Columns, dr);

        DataTable TT = dr.GetSchemaTable();
        for (int i = 0; i < ColIndexes.Length; i++)
        {
          if (ColIndexes[i] < 0)
          {
            dt.Columns.Add(Columns[i] + "_NODATA");
            dt.Columns[i + 1].DataType = typeof(string);
          }
          else
          {
            string Name = dr.GetName(ColIndexes[i]);
            // this decreases performance
            while (dt.Columns.Contains(Name))
              Name = Name + "_";
            dt.Columns.Add(Name);
            dt.Columns[i].DataType = dr.GetFieldType(ColIndexes[i]);
            if (dt.Columns[i].DataType.Name == "String")
            {
              int size = (int)TT.Rows[i]["ColumnSize"];
              dt.Columns[i].MaxLength = size;
            }
          }
        }

        string path = @FileName;
        if (File.Exists(path))
          File.Delete(path);


        using (StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("windows-1257")))
        {
          string S = "";
          while (dr.Read())
          {
            DataRow row = dt.NewRow();
            //float F = 0;

            for (int i = 0; i < ColIndexes.Length; i++)
            {
              if (ColIndexes[i] >= 0)
              {
                row[i] = dr.GetValue(ColIndexes[i]);

                if (!dr.IsDBNull(ColIndexes[i]) && dt.Columns[i].DataType.Name == "DateTime")
                {
                  S = S + CountDate(dr.GetDateTime(ColIndexes[i])) + (char)9;
                }
                else
                  S = S + row[i].ToString() + (char)9;
              }
            }
            sw.WriteLine(S);

            S = "";
            row = null;
          }
        }

        dr.Close();
        dr.Dispose();
        return dt;
      }
      catch (Exception x)
      {
        throw new Exception("\r\n[t_DataHandler.ReaderToTable] Klaida: " + x.Message, x);
      }
    }
    #endregion

    /// <summary>
    /// Paieskos lenteleje procedura. Grazina RowIndex, jei irasas surastas, -1 jei nerastas.
    /// </summary>
    /// <param name="ATable">Lentele, kurioje vykdoma paieska</param>
    /// <param name="AColName">Stulpelis, kuriame vykdomapaieska</param>
    /// <param name="AValue">Jieskoma reiksme</param>
    /// <param name="AAttributes">paieskos atributai: 0-CaseInsensitive, 1-CaseSensitive</param>
    /// <returns></returns>
    public int Locate(DataTable ATable, string AColName, object AValue, Int16 AAttributes)
    {
      StringComparison FSC = AAttributes == 0 ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      for (int i = 0; i < ATable.Rows.Count; i++)
      {
        if (ATable.Rows[i][AColName] != DBNull.Value)
        {
          if (ATable.Columns[AColName].DataType.Name.ToString().Equals("string", StringComparison.OrdinalIgnoreCase))
          {
            if (ATable.Rows[i][AColName].ToString().Equals(AValue.ToString(), FSC))
              return i;
          }
          else if (ATable.Columns[AColName].DataType.Name.ToString().Equals("Int16", StringComparison.OrdinalIgnoreCase))
          {
            if (Convert.ToInt16(ATable.Rows[i][AColName]).Equals(Convert.ToInt16(AValue)))
              return i;
          }
          else if (ATable.Columns[AColName].DataType.Name.ToString().Equals("Int32", StringComparison.OrdinalIgnoreCase))
          {
            if (Convert.ToInt32(ATable.Rows[i][AColName]).Equals(Convert.ToInt32(AValue)))
              return i;
          }
          else if (ATable.Columns[AColName].DataType.Name.ToString().Equals("Int64", StringComparison.OrdinalIgnoreCase))
          {
            if (Convert.ToInt64(ATable.Rows[i][AColName]).Equals(Convert.ToInt64(AValue)))
              return i;
          }
          else if (ATable.Columns[AColName].DataType.Name.ToString().Equals("int", StringComparison.OrdinalIgnoreCase))
          {
            if (Convert.ToInt32(ATable.Rows[i][AColName]).Equals(Convert.ToInt32(AValue)))
              return i;
          }
          else if (ATable.Columns[AColName].DataType.Name.ToString().Equals("Double", StringComparison.OrdinalIgnoreCase))
          {
            if (Convert.ToDouble(ATable.Rows[i][AColName]).Equals(Convert.ToDouble(AValue)))
              return i;
          }
          else if (ATable.Columns[AColName].DataType.Name.ToString().Equals("DateTime", StringComparison.OrdinalIgnoreCase))
          {
            if (Convert.ToDateTime(ATable.Rows[i][AColName]).Equals(Convert.ToDateTime(AValue)))
              return i;
          }
        }
      }
      return -1;
    }

    /// <summary>
    /// Paieskos lenteleje procedura. Grazina RowIndex, jei irasas surastas, -1 jei nerastas. Skirta tikrinti vienu metu kelias stulpeliu reiksmes
    /// </summary>
    /// <param name="ATable">Lentele, kurioje vykdoma paieska</param>
    /// <param name="AColumnNames">Stulpeliø masyvas, kuriame vykdomapaieska</param>
    /// <param name="AValues">Jieskoma reiksmiu masyvas. Elementu kiekis turi buti vienodas ieskomu stulpeliu kiekiui</param>
    /// <param name="AAttributes">paieskos atributai: 0-CaseInsensitive, 1-CaseSensitive</param>
    /// <returns></returns>
    public int Locate(DataTable ATable, string[] AColumnNames, object[] AValues, Int16 AAttributes)
    {
      int Result = -1;
      bool Radau = false;
      StringComparison FSC = AAttributes == 0 ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
      for (int i = 0; i < ATable.Rows.Count; i++)
      {
        Radau = true;
        for (int ColumnIndex = 0; ColumnIndex < AColumnNames.Length; ColumnIndex++)
        {
          if (ATable.Rows[i][AColumnNames[ColumnIndex]] != DBNull.Value)
          {
            if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("string", StringComparison.OrdinalIgnoreCase))
            {
              if (ATable.Rows[i][AColumnNames[ColumnIndex]].ToString().Equals(AValues[ColumnIndex].ToString(), FSC))
              {
                Result = i;
              }
              else Radau = false;
            }
            else if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("Int16", StringComparison.OrdinalIgnoreCase))
            {
              if (Convert.ToInt16(ATable.Rows[i][AColumnNames[ColumnIndex]]).Equals(Convert.ToInt16(AValues[ColumnIndex])))
              {
                Result = i;
              }
              else Radau = false;
            }
            else if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("Int32", StringComparison.OrdinalIgnoreCase))
            {
              if (Convert.ToInt32(ATable.Rows[i][AColumnNames[ColumnIndex]]).Equals(Convert.ToInt32(AValues[ColumnIndex])))
              {
                Result = i;
              }
              else Radau = false;
            }
            else if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("Int64", StringComparison.OrdinalIgnoreCase))
            {
              if (Convert.ToInt64(ATable.Rows[i][AColumnNames[ColumnIndex]]).Equals(Convert.ToInt64(AValues[ColumnIndex])))
              {
                Result = i;
              }
              else Radau = false;
            }
            else if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("int", StringComparison.OrdinalIgnoreCase))
            {
              if (Convert.ToInt32(ATable.Rows[i][AColumnNames[ColumnIndex]]).Equals(Convert.ToInt32(AValues[ColumnIndex])))
              {
                Result = i;
              }
              else Radau = false;
            }
            else if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("Double", StringComparison.OrdinalIgnoreCase))
            {
              if (Convert.ToDouble(ATable.Rows[i][AColumnNames[ColumnIndex]]).Equals(Convert.ToDouble(AValues[ColumnIndex])))
              {
                Result = i;
              }
              else Radau = false;
            }
            else if (ATable.Columns[AColumnNames[ColumnIndex]].DataType.Name.ToString().Equals("DateTime", StringComparison.OrdinalIgnoreCase))
            {
              if (Convert.ToDateTime(ATable.Rows[i][AColumnNames[ColumnIndex]]).Equals(Convert.ToDateTime(AValues[ColumnIndex])))
              {
                Result = i;
              }
              else Radau = false;
            }
          }
          else Radau = false;
        }
        if (Radau) break;
      }
      return Radau ? Result : -1;
    }

    /// <summary>
    /// Isvalo FList_ArLeidziamaRedaguoti sarasa tam, kad butu atsizvelgiama i pasikeitusias salygas (pvz. pasikeite periodo statusas)
    /// </summary>
    public void ClearArLeidziamaRedaguoti()
    {
      FList_ArLeidziamaRedaguotiId.Clear();
    }

    /// <summary>
    /// <pre>Used internally.</pre>
    /// Creates Array of Indexes, which indicates at what positions in DataReader 
    /// are Columns whose names are provided in ColNames string array.
    /// Null DataRow generates exception.
    /// </summary>
    /// <param name="ColNames">String array with Column Names. Null ir zero Array give alll columns</param>
    /// <param name="dr">SqlDataReader instance, which already performed a read operation</param>
    /// <returns>Array of indexes with columns positions in DataRow</returns>
    protected virtual int[] PopulateColIndexes(string[] ColNames, SqlDataReader dr)
    {
      try
      {
        if (dr == null)
          throw new Exception("Parameter SqlDataReader dr is null");
        bool AllCols = (ColNames == null);
        if (!AllCols)
          AllCols = (ColNames.Length == 0);

        int[] Result;
        if (AllCols)
          Result = new int[dr.FieldCount];
        else
          Result = new int[ColNames.Length];

        for (int i = 0; i < Result.Length; i++)
        {
          if (AllCols)
            Result[i] = i;
          else
          {
            Result[i] = -1;
            string ColName = ColNames[i].ToLower();
            for (int j = 0; j < dr.FieldCount; j++)
            {
              if (ColName.Equals(dr.GetName(j).ToLower()))
              {
                Result[i] = j;
                break;
              }
            }
          }
        }
        return Result;
      }
      catch (Exception x)
      {
        throw new Exception("\r\n[t_DataHandler.PopulateColIndexes] Klaida: " + x.Message, x);
      }
    }

    /// <summary>
    /// Destruktorius, uþdaro Connection'à rankomis.
    /// </summary>
    public void Close()
    {
#if (CLOSE_CONNECTION)
      if (m_Connection != null)
        if (m_Connection.State == ConnectionState.Open)
          m_Connection.Close();
      GC.Collect();
#endif
    }

  }

}
