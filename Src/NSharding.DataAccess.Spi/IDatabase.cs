using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 原生数据访问接口
    /// </summary>
    public interface IDatabase
    {
        void DataBatchImport(DataTable srcdt, string destTableName);
        void DataBatchImport(DataTable srcdt, string destTableName, Dictionary<string, string> mappingDict);
        int ExecSqlStatement(string sqlStatement);
        void ExecSqlStatement(string[] sqlStatements);
        int ExecSqlStatement(string sqlStatement, params IDbDataParameter[] dataParams);
        int ExecSqlStatement(string sqlStatement, params object[] dataParams);
        void ExecSqlStatement(string[] sqlStatements, IDbDataParameter[][] sqlsDataParams);
        DataSet ExecuteDataSet(string sqlStatement);
        DataSet ExecuteDataSet(string[] sqlStatements);
        DataSet ExecuteDataSet(string sqlStatement, IDbDataParameter[] dataParams);
        DataSet ExecuteDataSet(string sqlStatement, params object[] dataParams);
        DataSet ExecuteDataSet(string[] sqlStatements, IDbDataParameter[][] sqlsDataParams);
        DataSet ExecuteDataSetWithTableNames(string[] sqlStatements, string[] tableNames);
        IDataReader ExecuteReader(string sqlStatement);
        IDataReader ExecuteReader(string sqlStatement, IDbDataParameter[] dataParams);
        IDataReader ExecuteReader(string sqlStatement, params object[] dataParams);
        object ExecuteScalar(string sqlStatement);
        object ExecuteScalar(string sqlStatement, IDbDataParameter[] sqlDataParams);
        object ExecuteScalar(string sqlStatement, params object[] sqlDataParams);
        string GetConnectionStrings();
        DataTable GetSchema();
        DataTable GetSchema(string collectionName);
        DataTable GetSchema(string collectionName, string[] restrictionValues);
        IDbDataParameter MakeInParam(string paramName, object paramValue);
        IDbDataParameter MakeInParam(string paramName, DbDataType dataType);
        IDbDataParameter MakeInParam(string paramName, DbDataType dataType, object paramValue);
        IDbDataParameter MakeInParam(string paramName, DbDataType dataType, int size, object paramValue);
        IDbDataParameter MakeParam(string paramName, ParameterDirection direction, DbDataType dataType, int size, object paramValue);
        IDataReader RunProcGetDataReader(string procName);
        IDataReader RunProcGetDataReader(string procName, params object[] parameterValues);
        DataSet RunProcGetDataSet(string procName);
        DataSet RunProcGetDataSet(string procName, params object[] parameterValues);
        void RunProcWithNoQuery(string procName);
        void RunProcWithNoQuery(string procName, params object[] parameterValues);
    }
}
