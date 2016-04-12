using System;
using System.Collections.Generic;
using System.Data;
using Common.Exceptions;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{

    /// <summary>
    /// Cette classe contient des méthodes génériques pour la sélection et la modification des
    /// enregistrements de la base de données. Internal pour limiter l'accès à cet Assembly.
    /// </summary>
    /// <typeparam name="T">
    /// Chaque table de la base de données a sa classe associée. Pour la liste des classes
    /// (tables de la base de données), consulter la bibliothèque de classes DataTransferObject.
    /// </typeparam>
    internal static class HelperDal<T> where T : class, new()
    {

        /// <summary>
        /// Retourne un objet du type T de la base de données à partir de la requête spécifiée.
        /// </summary>
        /// <param name="query">
        /// Requête SELECT permettant de sélectionner un enregistrement.
        /// </param>
        /// <returns>
        /// Retourne un objet du type T spécifié correspondant à un enregistrement de la base de données ou null si
        /// aucun enregistrement n'a été trouvé.
        /// </returns>
        public static T Load(String query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conn_str))
                using (MySqlDataAdapter data_adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);
                    switch (data_table.Rows.Count)
                    {
                        case 1:
                            T obj = new T();
                            SetObjectValues(obj, data_table.Rows[0]);
                            return obj;
                        case 0:
                            return null;
                        default:
                            throw new UnmanagedException("La requête SELECT utilisée a retournée plus d'un enregistrement.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.Parse(ex, query);
                return null;
            }
        }

        /// <summary>
        /// Retourne une liste d'objet du type T de la base de données à partir de la requête spécifiée.
        /// </summary>
        /// <param name="query">
        /// Requête SELECT permettant de sélectionner les enregistrements.
        /// </param>
        /// <returns>
        /// Retoune une liste d'objet du type T spécifié correspondant aux enregistrements de la base de données.
        /// </returns>
        public static List<T> LoadAll(String query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conn_str))
                using (MySqlDataAdapter data_adapter = new MySqlDataAdapter(query, conn))
                {
                    T obj;
                    List<T> list_obj = new List<T>();
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);
                    foreach (DataRow data_row in data_table.Rows)
                    {
                        obj = new T();
                        SetObjectValues(obj, data_row);
                        list_obj.Add(obj);
                    }
                    return list_obj;
                }
            }
            catch (Exception ex)
            {
                ExHandler.Parse(ex, query);
                return null;
            }
        }

        /// <summary>
        /// Met à jour un enregistrement du type T de la base de données avec l'objet spécifié.
        /// </summary>
        /// <param name="obj">
        /// Objet contenant les donnée de l'enregistement à mettre à jour.
        /// </param>
        /// <param name="query">
        /// Requête SELECT permettant de sélectionner l'enregistrement à mettre à jour.
        /// </param>
        /// <returns>
        /// Retourne true si l'enregistrement a été mis à jour ou false dans le cas contraire.
        /// </returns>
        public static bool Update(T obj, String query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conn_str))
                using (MySqlDataAdapter data_adapter = new MySqlDataAdapter(query, conn))
                using (MySqlCommandBuilder cmd_builder = new MySqlCommandBuilder(data_adapter))
                {
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);
                    switch (data_table.Rows.Count)
                    {
                        case 1:
                            SetDataRowValues(data_table.Rows[0], obj);
                            return (data_adapter.Update(data_table) == 1);
                        case 0:
                            return false;
                        default:
                            throw new UnmanagedException("La requête SELECT utilisée a retournée plus d'un enregistrement.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.Parse(ex, query);
                return false;
            }
        }

        /// <summary>
        /// Insère un enregistrement du type T de la base de données avec l'objet spécifié.
        /// </summary>
        /// <param name="obj">
        /// Objet contenant les donnée de l'enregistement à insérer.
        /// </param>
        /// <param name="query">
        /// Requête SELECT permettant de sélectionner la table où les données seront insérées. La
        /// sélection peut ne retourner aucun résultat. C'est la sélection de celle-ci qui importe.
        /// </param>
        /// <returns>
        /// Retourne le ID de la clé primaire du nouvel l'enregistrement. Si l'enregistrement n'a
        /// pas été ajouté ou s'il n'y a pas de ID auto-incrémenté la valeur retournée est 0.
        /// </returns>
        public static UInt32 Insert(T obj, String query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_conn_str))
                using (MySqlDataAdapter data_adapter = new MySqlDataAdapter(query, conn))
                using (MySqlCommandBuilder cmd_builder = new MySqlCommandBuilder(data_adapter))
                {
                    UInt32 ret_id = 0;
                    DataTable data_table = new DataTable();
                    data_adapter.InsertCommand = cmd_builder.GetInsertCommand();
                    data_adapter.Fill(data_table);
                    DataRow data_row = data_table.NewRow();
                    SetDataRowValues(data_row, obj);
                    data_table.Rows.Add(data_row);
                    if (data_adapter.Update(data_table) == 1)
                    {
                        ret_id = Convert.ToUInt32(data_adapter.InsertCommand.LastInsertedId);
                    }
                    return ret_id;
                }
            }
            catch (Exception ex)
            {
                ExHandler.Parse(ex, query);
                return 0;
            }
        }

        /// <summary>
        /// Supprime le ou les enregistrements sélectionnés par la requête SQL. Cette suppression
        /// est fait avec une transaction pour assurer l'intégrité des données en cas de problèmes.
        /// Si une exception est déclenchée un rollback est fait pour ne rien modifier.
        /// </summary>
        /// <param name="query">
        /// Requête DELETE permettant de sélectionner le ou les enregistrements à supprimer.
        /// </param>
        public static void Delete(String query)
        {
            MySqlConnection conn = null;
            MySqlTransaction trans = null;
            MySqlCommand cmd = null;
            try
            {
                conn = new MySqlConnection(_conn_str);
                conn.Open();
                trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) { trans.Rollback(); }
                ExHandler.Parse(ex, query);
                return;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (trans != null) { trans.Dispose(); }
                if (conn != null) { conn.Dispose(); }
            }
        }

        /// <summary>
        /// Supprime le ou les enregistrements sélectionnés par la requête SQL. Cette suppression
        /// est fait avec une transaction pour assurer l'intégrité des données en cas de problèmes.
        /// Si une exception est déclenchée un rollback est fait pour ne rien modifier.
        /// </summary>
        /// <param name="queries">
        /// Tableau de requête DELETE permettant de sélectionner le ou les enregistrements à
        /// supprimer. Les requêtes sont exécutées dans l'ordre où elle sont dans le tableau
        /// ce qui est important lors de la suppression de données dans des tables master/detail.
        /// </param>
        public static void Delete(String[] queries)
        {
            MySqlConnection conn = null;
            MySqlTransaction trans = null;
            MySqlCommand cmd = null;
            try
            {
                conn = new MySqlConnection(_conn_str);
                conn.Open();
                trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd = conn.CreateCommand();
                foreach (String query in queries)
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) { trans.Rollback(); }
                ExHandler.Parse(ex, String.Join(" | ", queries));
                return;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (trans != null) { trans.Dispose(); }
                if (conn != null) { conn.Dispose(); }
            }
        }

        /// <summary>
        /// Modifie les valeurs de l'objet à partir des valeurs du DataRow spécifié. Il est
        /// primordial que le nom des attributs dans les deux cas soit de correspondance 1:1
        /// pour que le mapping se fasse car c'est le nom des attributs de l'objet qui sont lus.
        /// </summary>
        /// <param name="obj">
        /// Objet pour lequel les valeurs doivent être modifiées.
        /// </param>
        /// <param name="data_row">
        /// DataRow contenant les valeurs à être assignées.
        /// </param>
        private static void SetObjectValues(T obj, DataRow data_row)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                prop.SetValue(obj, data_row[prop.Name], null);
            }
        }

        /// <summary>
        /// Modifie les valeurs du DataRow à partir des valeurs de l'objet spécifié. Il est
        /// primordial que le nom des attributs dans les deux cas soit de correspondance 1:1
        /// pour que le mapping se fasse car c'est le nom des attributs de l'objet qui sont lus.
        /// </summary>
        /// <param name="data_row">
        /// DataRow pour lequel les valeurs doivent être modifiées.
        /// </param>
        /// <param name="obj">
        /// Objet contenant les valeurs à être assignées.
        /// </param>
        private static void SetDataRowValues(DataRow data_row, T obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (!IsAutoIncrementedColumn(data_row, prop.Name))
                {
                    data_row[prop.Name] = prop.GetValue(obj, null);
                }
            }
        }

        /// <summary>
        /// Permet de vérifier si dans un DataRow la colonne spécifiée est auto-incrémenté.
        /// </summary>
        /// <param name="data_row">
        /// DataRow pour lequel on vérifie si la colonne spécifiée est auto-incrémenté.
        /// </param>
        /// <param name="column_name">
        /// Nom de la colonne à évaluer.
        /// </param>
        /// <returns>
        /// Retourne true si la colonne est auto-incrémenté ou false dans le cas contraire.
        /// </returns>
        private static bool IsAutoIncrementedColumn(DataRow data_row, String column_name)
        {
            foreach (DataColumn data_column in data_row.Table.Columns)
            {
                if (data_column.ColumnName.Equals(column_name))
                {
                    if (data_column.AutoIncrement) return true;
                    break;
                }
            }
            return false;
        }

        /// <summary>
        /// La chaîne de connexion à la base de données.
        /// TODO : Il n'est pas très judicieux de hardcodé cette valeur quand elle pourrait être
        /// dans un fichier de paramètres comme app.config ou web.config.
        /// </summary>
        private static readonly string _conn_str = "Server=localhost;Database=map;Uid=root;Pwd=;";

    }

}
