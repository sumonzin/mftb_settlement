using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;

namespace ACE.Banking.MPU.DataAccess
{
    public class DataControllerBase
    {
        protected Database OrclDB;
        protected DbCommand Orcl_Command;
        protected DbConnection Orcl_Connection;
        protected DbTransaction Orcl_Transaction;

        protected Database DB;
        protected DbCommand Command;
        protected DbConnection Connection;
        protected DbTransaction Transaction;

        protected Database T_DB;
        protected DbCommand T_Command;
        protected DbConnection T_Connection;
        protected DbTransaction T_Transaction;

        protected Database S_DB;
        protected DbCommand S_Command;
        protected DbConnection S_Connection;
        protected DbTransaction S_Transaction;

        #region Properties ...
        private bool _useTransaction;

        public bool UseTransaction
        {
            get { return _useTransaction; }
        }

        public static string MainDBConnectionStringName
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MAINDB"].Name;
                return connectionString;
            }
        }

        public static string OrclDBConnectionStringName
        {
            get
            {
                string connectionString = ConfigurationManager.AppSettings["OrclConnection"];
                return connectionString;
            }
        }

        #endregion

        #region Constructor ...
      

        public DataControllerBase()
        {
            DB = DatabaseFactory.CreateDatabase(MainDBConnectionStringName);
            Connection = DB.CreateConnection();
           
        }
        #endregion

        #region OrclConnection Control Methods.....

        public void OrclStartTransaction()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            Transaction = Connection.BeginTransaction();
            _useTransaction = true;
        }

        public void OrclRollbackTransaction()
        {
            if (Transaction == null)
                return;

            Transaction.Rollback();
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            _useTransaction = false;
        }

        public void OrclCommitTransaction()
        {
            if (Transaction == null)
                return;

            Transaction.Commit();
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            _useTransaction = false;
        }
        #endregion 

        #region Transactional Control Methods...

        public void StartTransaction()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            Transaction = Connection.BeginTransaction();
            _useTransaction = true;
        }

        public void RollbackTransaction()
        {
            if (Transaction == null)
                return;

            Transaction.Rollback();
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            _useTransaction = false;
        }

        public void CommitTransaction()
        {
            if (Transaction == null)
                return;

            Transaction.Commit();
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            _useTransaction = false;
        }

        #endregion

        #region Properties ...
        private bool _TuseTransaction;

        public bool T_UseTransaction
        {
            get { return _TuseTransaction; }
        }

        public static string T_MainDBConnectionStringName
        {
            get
            {
                return string.Empty;
            }
        }

        private bool _SuseTransaction;

        public bool S_UseTransaction
        {
            get { return _SuseTransaction; }
        }

        public static string S_MainDBConnectionStringName
        {
            get
            {
                return string.Empty;
            }
        }
        #endregion

        #region Transactional Control Methods...

        public void T_StartTransaction()
        {
            if (T_Connection.State == ConnectionState.Closed)
                T_Connection.Open();
            T_Transaction = T_Connection.BeginTransaction();
            _TuseTransaction = true;
        }

        public void T_RollbackTransaction()
        {
            if (T_Transaction == null)
                return;

            T_Transaction.Rollback();
            if (T_Connection.State == ConnectionState.Open)
                T_Connection.Close();
            _TuseTransaction = false;
        }

        public void T_CommitTransaction()
        {
            if (T_Transaction == null)
                return;

            T_Transaction.Commit();
            if (T_Connection.State == ConnectionState.Open)
                T_Connection.Close();
            _TuseTransaction = false;
        }

        #endregion

        #region STransactional Control Methods...

        public void S_StartTransaction()
        {
            if (S_Connection.State == ConnectionState.Closed)
                S_Connection.Open();
            S_Transaction = S_Connection.BeginTransaction();
            _SuseTransaction = true;
        }

        public void S_RollbackTransaction()
        {
            if (S_Transaction == null)
                return;
            S_Transaction.Rollback();
            if (S_Connection.State == ConnectionState.Open)
                S_Connection.Close();
            _SuseTransaction = false;
        }

        public void S_CommitTransaction()
        {
            if (S_Transaction == null)
                return;

            S_Transaction.Commit();
            if (S_Connection.State == ConnectionState.Open)
                S_Connection.Close();
            _SuseTransaction = false;
        }

        #endregion

        #region Helper Methods ...
        protected virtual object GetNull(object obj)
        {
            // ...
            if (obj is String && obj.ToString() == "")
                obj = DBNull.Value;
            if (obj is int && ((int)obj) == int.MinValue)
                obj = DBNull.Value;
            else if (obj is float && ((float)obj) == float.MinValue)
                obj = DBNull.Value;
            else if (obj is decimal && ((decimal)obj) == decimal.MinValue)
                obj = DBNull.Value;
            else if (obj is double && ((double)obj) == double.MinValue)
                obj = DBNull.Value;
            else if (obj is DateTime && ((DateTime)obj) == DateTime.MinValue)
                obj = DBNull.Value;

            return obj;
        }
        #endregion
    }
}
