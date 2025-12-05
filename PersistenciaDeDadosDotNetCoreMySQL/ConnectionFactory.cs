using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

public class ConectionFactory
{
    public MySqlConnection ConectaDB()
    {
        string data_source = "server=localhost;port=3310;uid=root;pwd=;database=db_agenda;";
        MySqlConnection conexao = null;

        try
        {
            using (conexao = new MySqlConnection(data_source))
            {
                conexao.Open();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro no banco de dados: " + ex.Message, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro inesperado: " + ex.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return conexao;
    }
}
