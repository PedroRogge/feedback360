using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Feedback360.Models
{
    public class ComandosBancoDeDados
    {
        private string ConnectionString
        {
            get { return @"Data Source=senacturmati.database.windows.net;
                          Initial Catalog=Senac;
                          User id=senac;
                          Password=Teste123#"; }

            //get { return @"data source=.\SQLEXPRESS;
            //               initial catalog=Senac;persist security info=True; 
            //               Integrated Security=SSPI;"; }
        }
        public List<Mudar> BuscarMudarPorPessoaId(Guid pessoaID)
        {
            List<Mudar> lista = new List<Mudar>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Mudar_Andre where PessoaId = @PessoaId", con))
                {
                    command.Parameters.Add("@PessoaId", SqlDbType.UniqueIdentifier).Value = pessoaID;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mudar mudar = new Mudar();
                            mudar.PessoaId = (Guid)reader["PessoaId"];
                            mudar.MudarId = (Guid)reader["MudarId"];
                            mudar.Observacao = (string)reader["Observacao"];
                            lista.Add(mudar);
                        }
                    }
                }
            }
            return lista;
        }
        public List<Manter> BuscarManterPorPessoaId(Guid pessoaID)
        {
            List<Manter> lista = new List<Manter>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Manter_Andre where PessoaId = @PessoaId", con))
                {
                    command.Parameters.Add("@PessoaId", SqlDbType.UniqueIdentifier).Value = pessoaID;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Manter manter = new Manter();
                            manter.PessoaId = (Guid)reader["PessoaId"];
                            manter.ManterId = (Guid)reader["ManterId"];
                            manter.Observacao = (string)reader["Observacao"];
                            lista.Add(manter);
                        }
                    }
                }
            }
            return lista;
        }
        public List<Melhorar> BuscarMelhorarPorPessoaId(Guid pessoaID)
        {
            List<Melhorar> lista = new List<Melhorar>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Melhorar_Andre where PessoaId = @PessoaId", con))
                {
                    command.Parameters.Add("@PessoaId", SqlDbType.UniqueIdentifier).Value = pessoaID;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Melhorar melhorar = new Melhorar();
                            melhorar.PessoaId = (Guid)reader["PessoaId"];
                            melhorar.MelhorarId = (Guid)reader["MelhorarId"];
                            melhorar.Observacao = (string)reader["Observacao"];
                            lista.Add(melhorar);
                        }
                    }
                }
            }
            return lista;
        }
        public Pessoa BuscarPessoaPorPessoaId(Guid pessoaID)
        {
            Pessoa pessoa = new Pessoa();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Pessoa_Andre where PessoaId = @PessoaId", con))
                {
                    command.Parameters.Add("@PessoaId", SqlDbType.UniqueIdentifier).Value = pessoaID;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pessoa.PessoaId = (Guid)reader["PessoaId"];
                            pessoa.Nome = (string)reader["Nome"];
                        }
                    }
                }
            }
            return pessoa;
        }
        public List<Pessoa> BuscarPessoas()
        {
            List<Pessoa> lista = new List<Pessoa>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Pessoa_Andre", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pessoa pessoa = new Pessoa();
                            pessoa.PessoaId = (Guid)reader["PessoaId"];
                            pessoa.Nome = (string)reader["Nome"];
                            lista.Add(pessoa);
                        }
                    }
                }
            }
            return lista;
        }
        public Login BuscarUsuario(Login login)
        {
            login.UsuarioSenha = Criptografar(login.UsuarioSenha);
            Login usuario = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT top 1 * FROM UsuariosFeedback where UsuarioLogin = @UsuarioLogin and UsuarioSenha = @UsuarioSenha", con))
                {
                    command.Parameters.Add("@UsuarioLogin", SqlDbType.VarChar).Value = login.UsuarioLogin;
                    command.Parameters.Add("@UsuarioSenha", SqlDbType.VarChar).Value = login.UsuarioSenha;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new Login();
                            usuario.UsuarioLogin = (string)reader["UsuarioLogin"];
                            usuario.UsuarioSenha = (string)reader["UsuarioSenha"];
                        }
                    }
                }
            }
            return usuario;
        }

        public static string Criptografar(string valor)
        {
            string chaveCripto = "André";
            Byte[] cript = System.Text.ASCIIEncoding.ASCII.GetBytes(valor);
            chaveCripto = Convert.ToBase64String(cript);
            return chaveCripto;
        }

        public static string Descriptografar(string valor)
        {
            string chaveCripto = "André";
            Byte[] cript = Convert.FromBase64String(valor);
            chaveCripto = System.Text.ASCIIEncoding.ASCII.GetString(cript);
            return chaveCripto;
        }
    }
}
