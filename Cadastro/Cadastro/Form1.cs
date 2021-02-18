using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Cadastro
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDa;
        SqlDataReader sqlDr;

        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }


       
        private void btnNovo_Click(object sender, EventArgs e)
        {

            

            try
            {
                // String de conexão
                conexao = new SqlConnection(@"Server=DESKTOP-AVNQA5V\SQLEXPRESS; Database=Cliente; Trusted_Connection=True");

                // Insert
                strSQL = "INSERT INTO CAD_CLIENTE (NOME, CPF, TELEFONE) VALUES(@NOME, @CPF, @TELEFONE)";

                sqlCommand = new SqlCommand(strSQL, conexao);

                // Adicionando os parametros
                sqlCommand.Parameters.AddWithValue("@NOME", txtNome.Text);
                sqlCommand.Parameters.AddWithValue("@CPF", mktCpf.Text);
                sqlCommand.Parameters.AddWithValue("@TELEFONE", mktTelefone.Text);

                // Abre a conexão 
                conexao.Open();

                // Executa o Comando
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }finally
            {
                conexao.Close();
                conexao = null;
                sqlCommand = null;
                
            }

            LimparCampos();


        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                // String de conexão
                conexao = new SqlConnection(@"Server=DESKTOP-AVNQA5V\SQLEXPRESS; Database=Cliente; Trusted_Connection=True");

                // Select
                strSQL = "SELECT * FROM CAD_CLIENTE";

                // Cria o novo DataSet
                DataSet ds = new DataSet();

                sqlDa = new SqlDataAdapter(strSQL, conexao);
                
                
                // Abre a conexão 
                conexao.Open();

                // Preenche o dataset
                sqlDa.Fill(ds);

                // Exibe no dataGridView
                dgvDados.DataSource = ds.Tables[0];


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                sqlCommand = null;

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // String de conexão
                conexao = new SqlConnection(@"Server=DESKTOP-AVNQA5V\SQLEXPRESS; Database=Cliente; Trusted_Connection=True");

                // Consulta
                strSQL = "SELECT * FROM CAD_CLIENTE WHERE ID = @ID";

                sqlCommand = new SqlCommand(strSQL, conexao);

                // Adicionando o parametro
                sqlCommand.Parameters.AddWithValue("@ID", txtId.Text);
                
                // Abre a conexão 
                conexao.Open();

                // Executa o Comando
                sqlDr = sqlCommand.ExecuteReader();

                
                while (sqlDr.Read())
                {
                    txtNome.Text = (string) sqlDr["nome"];
                    mktCpf.Text = (string)sqlDr["cpf"];
                    mktTelefone.Text = (string)sqlDr["telefone"];
                    // txtNumero.Text = Convert.ToString( sqlDr["numero"]); Caso de número inteiro
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                sqlCommand = null;

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // String de conexão
                conexao = new SqlConnection(@"Server=DESKTOP-AVNQA5V\SQLEXPRESS; Database=Cliente; Trusted_Connection=True");

                // Update
                strSQL = "UPDATE CAD_CLIENTE SET NOME = @NOME, CPF = @CPF, TELEFONE = @TELEFONE WHERE ID = @ID";

                sqlCommand = new SqlCommand(strSQL, conexao);

                // Adicionando os parametros
                sqlCommand.Parameters.AddWithValue("@ID", txtId.Text);
                sqlCommand.Parameters.AddWithValue("@NOME", txtNome.Text);
                sqlCommand.Parameters.AddWithValue("@CPF", mktCpf.Text);
                sqlCommand.Parameters.AddWithValue("@TELEFONE", mktTelefone.Text);

                // Abre a conexão 
                conexao.Open();
                // Executa o Comando
                sqlCommand.ExecuteNonQuery();
                LimparCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                sqlCommand = null;

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                // String de conexão
                conexao = new SqlConnection(@"Server=DESKTOP-AVNQA5V\SQLEXPRESS; Database=Cliente; Trusted_Connection=True");

                // Delete
                strSQL = "DELETE CAD_CLIENTE WHERE ID = @ID";

                sqlCommand = new SqlCommand(strSQL, conexao);

                // Adicionando os parametros
                sqlCommand.Parameters.AddWithValue("@ID", txtId.Text);

                // Abre a conexão 
                conexao.Open();

                // Executa o Comando
                sqlCommand.ExecuteNonQuery();
                LimparCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                sqlCommand = null;

            }
        }
        public void LimparCampos()
        {
            txtNome.Text = string.Empty;
            mktCpf.Text = string.Empty;
            mktTelefone.Text = string.Empty;
        }

        
    }
}
