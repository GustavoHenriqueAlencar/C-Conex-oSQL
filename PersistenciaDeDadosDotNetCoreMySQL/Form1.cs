using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace PersistenciaDeDadosDotNetCoreMySQL
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{

			string data_source = "server=localhost;port=3306;uid=root;pwd=;database=db_agenda;}";

			string sql = "INSERT INTO contato (nome, telefone, email) VALUES (@nome, @telefone, @email)";

			try
			{
				using (MySqlConnection conexao = new MySqlConnection(data_source))
				{
					conexao.Open();
					using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
					{
						cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
						cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.Trim());
						cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

						int linhasAfetadas = cmd.ExecuteNonQuery();

						if (linhasAfetadas > 0)
						{
							MessageBox.Show("Contato salvo com sucesso!", "Sucesso",
							MessageBoxButtons.OK, MessageBoxIcon.Information);

							txtNome.Clear();
							txtTelefone.Clear();
							txtEmail.Clear();
						}
						else
						{
							MessageBox.Show("Nenhum registro foi inserido!", "Atenção",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
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
		}
	}
}